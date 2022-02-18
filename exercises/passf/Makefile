all : Out.txt
	cat Out.txt


Out.txt : main.exe
	mono main.exe  > Out.txt

main.exe : main.cs passf.dll
	mcs -reference:passf.dll main.cs

passf.dll : passf.cs
	mcs -target:library passf.cs

clean :
	rm -f *.exe *.txt *.dll 