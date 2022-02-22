all : Out.txt
	cat Out.txt

Out.txt : main.exe
	#echo -7.10 2.95 \t 4.12 \n \t 5.42 \t \t 1.23 \t 234.1 > input.txt
	mono main.exe < input.txt > Out.txt	

main.exe : main.cs genlist.dll
	mcs -reference:genlist.dll main.cs

genlist.dll : genlist.cs
	mcs -target:library genlist.cs

clean :
	rm -f *.exe Out.txt *.dll