all: out.txt
	cat $<
	make Convergence.png

Convergence.png: Convergence.gpi Convergence.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll vec.dll Symeig.dll
	mcs $< -reference:matrix.dll,vec.dll,Symeig.dll

Symeig.dll: Symeig.cs vec.dll matrix.dll
	mcs $< -target:library -reference:vec.dll,matrix.dll

matrix.dll: matrix.cs vec.dll
	mcs $< -target:library -reference:vec.dll

vec.dll: vec.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt