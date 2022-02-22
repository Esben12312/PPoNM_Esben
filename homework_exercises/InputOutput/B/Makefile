all : Out.txt
	cat Out.txt

Out.txt : main.exe
	mono main.exe 7 2 4 5 1 > Out.txt	

main.exe : main.cs
	mcs  main.cs

clean :
	rm -f main.exe Out.txt