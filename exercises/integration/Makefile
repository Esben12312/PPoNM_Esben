all: Out.Integral.txt gamma.png
	cat $<

gamma.png: err.pyxplot.gpi Out.txt
	pyxplot err.pyxplot.gpi

Out.txt: numint.exe
	mono $< > $@

Out.plot.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -out:main.exe -target:exe -reference:matlib.dll

numint.exe: numint.cs matlib.dll
	mcs $< -out:numint.exe -target:exe -reference:matlib.dll

matlib.dll:matlib.cs
	mcs -target:library $<

clean:
	rm -r *.exe *.txt *.plot.txt *.png *.dll

upload:
    rm -r *.exe *.plot.txt *.dll