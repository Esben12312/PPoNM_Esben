using static System.Console;
using static System.Math;
using static machineEpsilon;
using System.IO;

class epsilon {
	private static StreamWriter _boo;

	static void Main(){
		maxint();
		minint();

		Machine();
		summing();
				
		test();
	}
	private static void maxint(){
		int i = 1;
		while(i+1>i) {i++;}
		
		Write($"My max int = {i}\n");
		Write($"System max int = {int.MaxValue} \n");
	}
	private static void minint() {
		int i=1;
		while(i-1<i) {i=i-1;}
		
		Write("My min int = {0}\n", i);
		Write("System min int = {0}\n", int.MinValue);
	}

	private static void test() {
		File.Create("test.txt").Dispose();
		_boo = new StreamWriter("test.txt");	
		int i = 1; double j = 1; float k = 1F;
		int g = -1; double h = 2; float t = 2F;

		double tiny = Pow(2, -53); double huge = Pow(2, 21);
	
	if(machineEpsilon.approx((double) i, (double) i)) {
	_boo.WriteLine( $"approx returns true for (int) {i}, (int) {i}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (int) {i}, (int) {i}" );
	}

	if(machineEpsilon.approx((double) i, (double) g)) {
	_boo.WriteLine( $"approx returns true for (int) {i}, (int) {g}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (int) {i}, (int) {g}" );
	}

	if(machineEpsilon.approx((double) j, (double) i)) {
	_boo.WriteLine( $"approx returns true for (double) {j}, (int) {i}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (double) {j}, (int) {i}" );
	}

	if(machineEpsilon.approx((double) j, (double) k)) {
	_boo.WriteLine( $"approx returns true for (double) {j}, (float) {k}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (double) {j}, (float) {k}" );
	}

		if(machineEpsilon.approx((double) h, (double) t)) {
	_boo.WriteLine( $"approx returns true for (double) {h}, (float) {t}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (double) {h}, (float) {t}" );
	}

		if(machineEpsilon.approx((double) tiny, (double) Pow(10, 5)*tiny)) {
	_boo.WriteLine( $"approx returns true for (double) {tiny}, (double) {Pow(10, 5)*tiny}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (double) {tiny}, (double) {Pow(10, 5)*tiny}" );
	}

		if(machineEpsilon.approx((double) huge, (double) huge-2)) {
	_boo.WriteLine( $"approx returns true for (double) {huge}, (double) {huge-2}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (double) {huge}, (double) {huge-2}" );
	}

		if(machineEpsilon.approx((double) Pow(9,11)*huge, (double) Pow(9,11)*huge-2)) {
	_boo.WriteLine( $"approx returns true for (double) {Pow(9,11)*huge}, (double) {Pow(9,10)*huge-2}" );
	}
	else {
	_boo.WriteLine( $"approx returns false for (double) {Pow(9,11)*huge}, (double) {Pow(9,10)*huge-2}" );
	}

	_boo.Flush();
	_boo.Close();
	}
}
