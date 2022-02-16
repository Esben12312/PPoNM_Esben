WPR : Out.txt
	cat Out.txt	
	cat test.txt



Out.txt : main.exe
	mono main.exe  > Out.txt

main.exe : main.cs vec.dll vectest.dll
	mcs -reference:vectest.dll -reference:vec.dll  main.cs

vectest.dll : vectest.cs vec.dll
	mcs -reference:vec.dll -target:library vectest.cs

vec.dll : vec.cs
	mcs -target:library vec.cs

clean :
	rm -f main.exe Out.txt test.txt vectest.dll vec.dll