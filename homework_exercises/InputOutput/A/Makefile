all : Out.txt
	cat Out.txt

Out.txt : main.exe
	echo 7 2 4 5 1 > input.txt
	mono main.exe < input.txt > Out.txt	

main.exe : main.cs
	mcs  main.cs

clean :
	rm -f main.exe Out.txt