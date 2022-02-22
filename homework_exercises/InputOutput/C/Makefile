all : Out.txt
	cat Out.txt

Out.txt : main.exe
	mono main.exe -input:input.txt -output:Out.txt	

main.exe : main.cs
	mcs  main.cs

clean :
	rm -f main.exe Out.txt