all : Out.txt
	cat Out.txt

Out.txt : main.exe
	mono main.exe < input.txt > Out.txt	

main.exe : main.cs genlist.dll
	mcs -reference:genlist.dll main.cs

genlist.dll : genlist.cs
	mcs -target:library genlist.cs

clean :
	rm -f *.exe Out.txt *.dll