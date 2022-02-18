using static System.Console;
using static System.Math;
using static vectest;
using static vec;
class main {
	
	static void Main() {
		bool show = true;
		vec a = new vec(1, -1, 1);
		vec b = new vec(-1, 2, 3);
		vec c = new vec(-3, -2, 1);
		vec d = new vec();
		vec e = new vec(10000, -10, 0);
		vec f = new vec(-10000, -99999, 750);
		double g = 5;

		startTest();
		// test creation/vector properties
		WriteLine("Testing that new vec() and new vec (0, 0, 0).");
		test(new vec(0, 0, 0), d, show);
		WriteLine("Testing the test method without operators, a==a, a!=b, 0==0.");
		test(a, a, show);
		negativeTest(a, b, show);
		test(0, 0, show);
		WriteLine("Testing the test method for vectors and doubles, vec()!=0, vec(1,0,0)!=1.");
		negativeTest(new vec(1, 0, 0), 1, show);
		negativeTest(d, 0, show);

		// test standart operations
		WriteLine("Testing the vector operators, addition.");
		test(d+a, a, show);		
		negativeTest(a+b, 0, show);
		WriteLine("Testing the vector operators, subtraction.");
		test(c-a, new vec(-4, -1, 0), show);
		negativeTest(b-a, a-b, show);
		test(f-f, new vec(), show);
		WriteLine("Testing the vector operators, multiplication with double.");
		test(g*c, new vec(-15, -10, 5), show);
		test(g*c, c*g, show);
		test(1*a, a, show);
		WriteLine("Testing the vector operators, minus vec.");
		negativeTest(a, -a, show);
		test(d-e, -e, show);
		test(d,-d,show);
		WriteLine("Testing the vector operators, Combinations of tested operators.");
		test(d+a-a, new vec(), show);
		test(5*b-2*b, 3*(b), show);
		test(1*b-4*b, 3*(-b), show);

	

		// test Norm
		WriteLine("Testing the vector operators, Norm.");
		test(Norm(a), Sqrt(3), show);
		test(Norm(f), Sqrt(10100362501), show);
		test(Norm(d),  0, show);
		// test dot
		WriteLine("Testing the vector operators, Dot product.");
		test(Dot(c, b), 2, show);
		test(Dot(a, b), 0, show);
		test(Dot(e, f), Dot(f, e), show);
		// test cross
		WriteLine("Testing the vector operators, cross product.");
		test(Cross(a, e), new vec(10, 10000, 9990), show);
		negativeTest(Cross(b,c), Cross(c,b), show);
		// test approx
		WriteLine("Testing the vector operators, approximation.");
		approxTest(a.approx(a*1e-9), true, show);
		approxTest((b*1e16).approx(b*1e15), true, show);
		endTest();

		WriteLine("Program succesfully executed.\n");
	}
}