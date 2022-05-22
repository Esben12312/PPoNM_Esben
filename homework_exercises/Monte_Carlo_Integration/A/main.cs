using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		WriteLine("Testing the Monte-Carlo integrator on some known integrals\n");


		WriteLine("Integrating x^2*y^2 from x = -1 to 1, y = -1 to 1");
		Func<vector,double> f1 = x => x[0]*x[0]*x[1]*x[1];
		vector a1 = new double[2] {-1,-1};
		vector b1 = new double[2] {1,1};
		var res1 = Monte_Carlo_Inte.MCInt(f1, a1, b1, 50000);
		WriteLine($" Monte-Carlo integrator returns {res1.Item1} with error {res1.Item2}");
		WriteLine("Result should be 4*1^6/9 = 0.44...");

		WriteLine("\nIntegrating (x + sin(y) + 1) dx dy, x = 0..2, y = -pi..pi");
		Func<vector,double> f2 = x => x[0] + Sin(x[1]) + 1;
		vector a2 = new double[2] {0,-PI};
		vector b2 = new double[2] {2,PI};
		var res2 = Monte_Carlo_Inte.MCInt(f2, a2, b2, 50000);
		WriteLine($"Monte-Carlo integrator returns {res2.Item1} with error {res2.Item2}");
		WriteLine("Result should be 8*pi = 25.133");

		WriteLine("\nIntegrating 1/([1 - cos(x)*cos(y)*cos(z)]*pi^3) dx dy dz, x = 0..pi, y = 0..pi, z = 0..pi");
		Func<vector,double> f3 = x => 1/((1 - Cos(x[0])*Cos(x[1])*Cos(x[2]))*Pow(PI,3));
		vector a3 = new double[3] {0,0,0};
		vector b3 = new double[3] {PI, PI, PI};
		var res3 = Monte_Carlo_Inte.MCInt(f3, a3, b3, 50000);
		WriteLine($"Monte-Carlo integrator returns {res3.Item1} with error {res3.Item2}");
		WriteLine("Result should be 1.393203");
		

	}

}
