all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs Monte_Carlo.dll vec.dll
	mcs $< -target:exe -reference:Monte_Carlo.dll,vec.dll

Monte_Carlo.dll: Monte_Carlo.cs vec.dll
	mcs $< -target:library -reference:vec.dll

vec.dll: vec.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt