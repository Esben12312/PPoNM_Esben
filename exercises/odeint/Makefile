all: ode.png

ode.png: Out.txt ode.pyxplot.gpi
	pyxplot ode.pyxplot.gpi

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -out:main.exe -target:exe -reference:matlib.dll

clean:
	rm -r *.txt *.exe *.png
