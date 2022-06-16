all: out.txt
	cat $<
	make Timing.png

Timing.png: Timing.gpi times.txt
	pyxplot $<

out.txt: main.exe
	mono $< 1> out.txt 2> times.txt

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