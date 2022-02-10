Write : Out.txt
	cat Out.txt	

Test : test.txt
	cat test.txt

Out.txt : epsilon.exe
	mono epsilon.exe  > Out.txt

epsilon.exe : epsilon.cs machineEpsilon.dll
	mcs -reference:machineEpsilon.dll epsilon.cs

machineEpsilon.dll : machineEpsilon.cs
	mcs -target:library  machineEpsilon.cs

clean :
	rm -f epsilon.exe Out.txt test.txt machineEpsilon.dll
