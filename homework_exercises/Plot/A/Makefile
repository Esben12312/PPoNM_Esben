erf.pyxplot.png: out.erf.txt tab.erf.txt
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "erf($$x$$)" ;\
	set title "Error function" ;\
	set grid ;\
	set key left top ;\
	plot [-2:2] [-1:1] "$<" index 0 using 1:2 with lines title "erf($$x$$)",\
	"tab.erf.txt" using 1:2 with points pointtype 17 title "Tabulated data" \
	'| tee log.pyx.gpi | pyxplot

out.erf.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $< -target:exe

clean:
	rm -r *.png log* out* *.exe
