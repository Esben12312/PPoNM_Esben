all : Out.txt
	cat Out.txt #Writing results

Out.txt : math.exe
	mono math.exe > Out.txt

math.exe : math.cs
	mcs math.cs

clean :
	rm -f Out.txt math.exe
