all: Out.Integral.txt gamma.png
	cat $<

gamma.png: err.pyxplot.gpi Out.txt
	pyxplot err.pyxplot.gpi

Out.Integral.txt: numint.exe
	mono $< > $@

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -out:main.exe -target:exe -reference:matlib.dll

numint.exe: numint.cs matlib.dll
	mcs $< -out:numint.exe -target:exe -reference:matlib.dll

clean:
	rm -r *.exe *.txt *.png
