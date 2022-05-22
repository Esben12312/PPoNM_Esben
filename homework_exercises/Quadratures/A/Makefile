all: out.txt
	cat out.txt
	make ErrorFunction.png

ErrorFunction.png: ErrorFunction.gpi Erf.txt table_Erf.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs AdaptiveIntegrator.dll
	mcs $< -reference:AdaptiveIntegrator.dll

AdaptiveIntegrator.dll: AdaptiveIntegrator.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png