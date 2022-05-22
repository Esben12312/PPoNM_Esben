all: out.txt
	cat $<
	make Optimized_Ode45.png

Optimized_Ode45.png: Ode45.gpi Optimized_Ode45.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs vec.dll RungeKutta.dll genlist.dll
	mcs $< -reference:RungeKutta.dll,vec.dll,genlist.dll

RungeKutta.dll: RungeKutta.cs vec.dll genlist.dll
	mcs $< -target:library -reference:vec.dll,genlist.dll

vec.dll: vec.cs
	mcs $< -target:library

genlist.dll: genlist.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png