using System;
using System.Linq;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		double[] time = new double[] {1,2,3,4,6,9,10,13,15};
		double[] activity = new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1};
		double[] dy = new double[] {5,5,5,5,5,1,1,1,1};
		
		for(int i=0; i<time.Length; i++){	
			// Used for plotting
			WriteLine($"{time[i]} {activity[i]} {dy[i]}");
		}
		WriteLine("\n");
	
		for(int i=0; i<activity.Length; i++){
			dy[i] = dy[i]/activity[i];
			activity[i] = Math.Log(activity[i]);
		}
				
		var fs = new Func<double,double>[] {z => 1.0, z => z};
                
		(var c, matrix S) = LSQ.lsfit(fs, time, activity, dy);
 

		double res=0;
		double res_p=0;
		double res_m=0;
		for(double t=0; t<=time.Max(); t+=1.0/8){
			res_m = 0;
			res_p = 0;
			res = 0;
			for(int j=0; j<fs.Length; j++){
				double dc = Sqrt(S[j,j]);
				res_m += (c[j]-dc)*fs[j](t);
				res += c[j]*fs[j](t);
				res_p += (c[j]+dc)*fs[j](t);
				
			}
			
			res = Exp(res);
			res_m = Exp(res_m);
			res_p = Exp(res_p);
			WriteLine($"{t} {res} {res_m} {res_p}");
		}	
		WriteLine("\n");

		using(var outstream = new System.IO.StreamWriter("Service_message.txt")){
			outstream.WriteLine();
			outstream.WriteLine($"The plot with uncertianty limits is plotted in fit_plot.PNG");
			outstream.WriteLine();
		}
	}
}