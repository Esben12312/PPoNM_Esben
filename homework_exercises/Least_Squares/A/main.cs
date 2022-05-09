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
                
		var c  = LSQ.lsfit(fs, time, activity, dy);
 
		double res=0;
		for(double t=0; t<=time.Max(); t+=1.0/8){
			res = 0;
			for(int j=0; j<fs.Length; j++){
				res += c[j]*fs[j](t);
				
			}
			//Exponentiating since fit is made in linear form
			res = Exp(res);
			WriteLine($"{t} {res}");
		}	
		WriteLine("\n");

		using(var outstream = new System.IO.StreamWriter("fitvals.txt")){
			outstream.WriteLine();
			outstream.WriteLine($"Fit parameters: a = {c[0]}, lambda = {c[1]}");
			outstream.WriteLine($"Half-life estimated as {Log(2)/(-c[1])} days");
			outstream.WriteLine("Modern table value is 3.63 days");
			outstream.WriteLine();
			outstream.WriteLine("Here a small difference is seen between table value and fit.");
			outstream.WriteLine("So lets determine the uncertianties in folder B");
		}
	}
}
