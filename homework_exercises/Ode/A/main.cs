using System;
using static System.Console;
using static System.Math;
class main {
	public static void Main() {
		WriteLine();
		WriteLine("Solving the ODE from SciPy");
		WriteLine("The result is illustrated in Ode45.png");
		WriteLine();
		double b=0.25, c=5.0;
		Func<double,vector,vector> f = delegate(double t, vector y){
			double theta=y[0], omega=y[1];
			return new vector(omega, -b*omega-c*Sin(theta));
		};

		double start=0, stop=10;
		vector y0 = new vector(PI-0.1, 0.0);
		
			RungeKutta.driver(f, start, y0, stop);
		
	}
}