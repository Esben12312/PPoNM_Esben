lnspline.png:out.txt spline.gpi
	pyxplot spline.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs Splines.dll
	mcs -target:exe -reference:Splines.dll $<

Splines.dll:Splines.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll *.png