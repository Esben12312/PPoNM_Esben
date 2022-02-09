using static System.Console;
using static System.Math;
	public static class math {
		static void Main(){

		double sqrt2 = Sqrt(2.0);
		Write($"sqrt(2)={sqrt2} \n");
		Write($"sqrt(2)*sqrt(2) = {sqrt2*sqrt2} (should be equal 2)\n ");

		double epi = Pow(E, PI);
		Write($"e^pi = {epi} (should be approx 23.14)\n");		
		
		double pie = Pow(PI, E);
		Write($"pi^e = {pie} (should be approx 22.46)\n");
		}
	}
