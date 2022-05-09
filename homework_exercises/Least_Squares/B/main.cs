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
			outstream.WriteLine("The covariance-matrix is:");

			//S.print from matrix
			outstream.WriteLine("");
			for(int ir=0;ir<S.size1;ir++){
			for(int ic=0;ic<S.size2;ic++)
			outstream.Write("{0,10:g3} ", S[ir,ic]);
			outstream.WriteLine();
		}
	
		outstream.WriteLine($"\n lambda is fitted to a value of {-c[1]} +/- {Math.Sqrt(S[1,1])}");
		outstream.WriteLine($"This corresponds to a half-life of {Math.Log(2)/(-c[1])} +/- {Math.Sqrt(S[1,1])*Math.Log(2)/(-c[1])} days"); // Error propagation!
		outstream.WriteLine("half-life tabulated at 3.63 days uncertainties unknown");
		outstream.WriteLine("The estimated uncertainties illustrates a large discrepancy from the tabulated half-life");
		
		
		}		
		}
	}	