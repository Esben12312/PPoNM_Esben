all:fit_plot.png Service_message.txt
	make fit_plot.png
	cat Service_message.txt

fit_plot.png:out.txt fit_plot.gpi
	pyxplot fit_plot.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs LSQ.dll matrix.dll vec.dll
	mcs -t:exe -r:LSQ.dll -r:matrix.dll -r:vec.dll $<

LSQ.dll:LSQ.cs QRGS.dll matrix.dll vec.dll
	mcs -t:library -r:QRGS.dll -r:matrix.dll -r:vec.dll $<

QRGS.dll:QRGS.cs matrix.dll vec.dll
	mcs -t:library -r:matrix.dll -r:vec.dll $<

matrix.dll:matrix.cs vec.dll
	mcs -t:library -r:vec.dll $<

vec.dll:vec.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll