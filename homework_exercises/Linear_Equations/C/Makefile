Runtime_plot.png: Timer_plot.gpi out.txt
	pyxplot $<

out.txt:main.exe
	mono $< > $@

main.exe:main.cs matrix.dll vec.dll QRGS.dll 
	mcs -target:exe -reference:matrix.dll -reference:QRGS.dll -reference:vec.dll $<

QRGS.dll:QRGS.cs matrix.dll vec.dll
	mcs -target:library -reference:matrix.dll -reference:vec.dll $<

matrix.dll:matrix.cs vec.dll
	mcs -target:library -reference:vec.dll $<

vec.dll:vec.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.txt