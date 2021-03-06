using System;
using static System.Console;
using static System.Math;

public class RungeKutta {
		public static (vector, vector) step(Func<double, vector, vector> f, double x, vector y, double h) {
			vector V1 = h*f(x,y);
			vector V2 = h*f(x + 1.0/4*h, y + 1.0/4*V1);
			vector V3 = h*f(x + 3.0/8*h, y + 3.0/32*V1 + 9.0/32*V2);
			vector V4 = h*f(x + 12.0/13*h, y + 1932.0/2197*V1 + (-7200.0/2197)*V2 + 7296.0/2197*V3);
			vector V5 = h*f(x + h, y + 439.0/216*V1 + (-8.0)*V2 + 3680.0/513*V3 + (-845.0/4104)*V4);
			vector V6 = h*f(x + 1.0/2*h, y + (-8.0/27)*V1 + 2.0*V2 + (-3544.0/2565)*V3 + 1859.0/4104*V4 + (-11.0/40)*V5);

			vector yh = y + 16.0/135*V1 + 0.0*V2 + 6656.0/12825*V3 + 28561.0/56430*V4 + (-9.0/50)*V5 + 2.0/55*V6;
			vector error = (16.0/135-25.0/216)*V1 + (0.0-0.0)*V2 + (6656.0/12825-1408.0/2565)*V3 + (28561.0/56430-2197.0/4104)*V4 + (-9.0/50+1.0/5)*V5 + (2.0/55-0)*V6;

			return (yh, error);
		} 

		public static vector driver(Func<double,vector,vector> f, double a, vector ya, double b, double h=0.01, double acc=1e-8, double eps=1e-8){
		if(a>b) {throw new Exception("Cannot drive since a>b");}
		double x = a;
		vector y = ya;
		var outfile = new System.IO.StreamWriter("ode45.txt");
		do{

			if(x>=b) {return y;}
			if(x+h>b) {h=b-x;}

			var (yh,err_vec) = step(f, x, y, h);
			double tol = Max(acc, yh.norm()*eps)*Sqrt(h/(b-a));
			double err = err_vec.norm();
			if(err<=tol){
				x += h; y=yh;
				outfile.Write($"{x}");
				for(int i=0; i<yh.size; i++){outfile.Write($" {yh[i]}");}
				outfile.WriteLine();
			}
			h = h*Min(Pow(tol/err, 0.25)*0.95, 2);
		} while(true);
	}
}