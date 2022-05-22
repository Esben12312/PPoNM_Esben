all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll vec.dll Eig.dll
	mcs $< -reference:matrix.dll,vec.dll,Eig.dll

Eig.dll: Eig.cs vec.dll matrix.dll
	mcs $< -target:library -reference:vec.dll,matrix.dll

matrix.dll: matrix.cs vec.dll
	mcs $< -target:library -reference:vec.dll

vec.dll: vec.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt