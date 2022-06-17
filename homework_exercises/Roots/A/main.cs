using System;
using static System.Console;
using static System.Math;

class main {
	public static void Main() {
		var rand=new Random();
		WriteLine("Minimization using newton method.");
		WriteLine();


		WriteLine("Initial testing: f(x)=x-5, f(x)=(x^2-2).");

		Func<vector,vector> f1 = xs => new vector(xs[0]-5);

		Func<vector,vector> f2 = xs => new vector(Pow(xs[0],2)-2);
		double acc = 1e-2;

		vector x01 = new vector(1);
		for(int i=0;i<1;i++){
			x01[i]=rand.Next(10);;
		}

		(vector x1, int s1) = roots.newton(f1, x01, acc); 
		(vector x2, int s2) = roots.newton(f2, x01, acc); 		
		WriteLine($"\nTest function Roots found at ({x1[0]}), ({x2[0]}), Expected: (5), (sqrt(2)).");
		WriteLine($"With randomized ininital starting quess ({x01[0]}), in {s1} and {s2} steps respectively.");

		WriteLine();
		WriteLine();

		
		WriteLine("Determining roots for Rosenbrock's valley function, f(x,y)=(1-x)^2+100(y-x^2)^2.");
		
		Func<vector,vector> rosenbrock = xs => new vector(Pow(1-xs[0],2),100*Pow(xs[1]-Pow(xs[0],2),2));
		

		vector x0 = new vector(2);
		for(int i=0;i<2;i++){
			x0[i]=rand.Next(10);;
		}
		(vector x, int s) = roots.newton(rosenbrock, x0, acc); 	
		WriteLine($"\nRosenbrock root at ({x[0]},{x[1]}) found after {s} steps.");
		WriteLine($"With randomized ininital starting quess ({x0[0]},{x0[1]}).");

		WriteLine("Expected root at (1,1).");
	}
}