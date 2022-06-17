using System;
using static System.Console;
using static System.Math;

class main {
	public static void Main() {
		var rand=new Random();
		WriteLine("Minimization using quasi-newton method");
		WriteLine("Determining minimum for Rosenbrock's valley function, f(x,y)=(1-x)^2+100(y-x^2)^2");
		
		Func<vector,double> rosenbrock = delegate(vector args){
			return (1-args[0])*(1-args[0]) +100*(args[1]-args[0]*args[0])*(args[1]-args[0]*args[0]);
		};	

		vector x0 = new vector(2);
		for(int i=0;i<2;i++){
			x0[i]=rand.Next(10);;
		}
		double acc = 1e-5;
		(vector x, int s) = mini.qnewton(rosenbrock, x0, acc); 	
		WriteLine($"\nRosenbrock minimum at ({x[0]},{x[1]}) found after {s} steps");
		WriteLine($"With randomized ininital starting quess ({x0[0]},{x0[1]})");

		WriteLine("Expected minimum at (1,1)");


		WriteLine("Determining minimum for Himmelblau's function, f(x,y)=(x^2+y-11)^2+(x+y^2-7)^2.");
		Func<vector,double> himmelblau = delegate(vector args){
			return (args[0]*args[0]+args[1]-11)*(args[0]*args[0]+args[1]-11) + (args[0]+args[1]*args[1]-7)*(args[0]+args[1]*args[1]-7);
		};
		x0 = new vector(2);
		for(int i=0;i<2;i++){
			x0[i]=rand.Next(15);
		}
		(x, s) = mini.qnewton(himmelblau, x0, acc); 	
		WriteLine($"\nHimmelblau minimum at ({x[0]},{x[1]}) found after {s} steps");
		WriteLine($"With randomized ininital starting quess ({x0[0]},{x0[1]})");
		WriteLine("Expected minimum at either (3,2), (-3.78,-3.28), (-2.81, 3.13),(3.58,-1.85). \n This depends on randomized starting guesses");
	}
}