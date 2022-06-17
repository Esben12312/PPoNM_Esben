all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs vec.dll matrix.dll roots.dll QRGS.dll
	mcs $< -reference:matrix.dll,vec.dll,roots.dll,QRGS.dll

roots.dll: roots.cs vec.dll matrix.dll QRGS.dll
	mcs $< -target:library -reference:vec.dll,matrix.dll,QRGS.dll

QRGS.dll: QRGS.cs vec.dll matrix.dll
	mcs $< -target:library -reference:vec.dll,matrix.dll

matrix.dll: matrix.cs vec.dll
	mcs $< -target:library -reference:vec.dll

vec.dll: vec.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png