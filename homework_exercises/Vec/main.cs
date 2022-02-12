using static System.Console;
using static System.Math;
using static vectest;
using static vec;
class main {
	
	static void Main() {
		bool show = false;
		vec a = new vec(1, -1, 1);
		vec b = new vec(-1, 2, 3);
		vec c = new vec(-3, -2, 1);
		vec d = new vec();
		vec e = new vec(10000, -10, 0);
		vec f = new vec(-10000, -99999, 750);
		double g = 5;

		startTest();
		test(Norm(a), Sqrt(3), show);
		test(d+a, a, show);
		test(Cross(a, e), new vec(10, 10000, 9990), show);
		test(Dot(c,d), 0, show);
		negativeTest(a+b, 0, show);
		test(g*c, new vec(-15, -10, 5), show);
		test(d+a-a, new vec(), show);
		test(Norm(f), Sqrt(10100362501), show);
		approxTest(a.approx(a*1e-9), true, show);
		approxTest((b*1e16).approx(b*1e15), true, show);
		endTest();

		WriteLine("Program succesfully executed.\n");
	}
}