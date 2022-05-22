all: out.txt
	cat $<
	make Ode45.png

Ode45.png: Ode45.gpi ode45.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs vec.dll RungeKutta.dll
	mcs $< -reference:RungeKutta.dll,vec.dll

RungeKutta.dll: RungeKutta.cs vec.dll
	mcs $< -target:library -reference:vec.dll

vec.dll: vec.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png