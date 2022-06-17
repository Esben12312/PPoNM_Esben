using System;
using System.Linq;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		
		WriteLine("Testing O(N^2) operations through timing, see plot Timing.png for result.");
		
		var rand = new Random();
		
		for(int n = 3; n<=150;n+=2){
			matrix D = new matrix(n,n);
			vector u = new vector(n);
			matrix V = new matrix(n,n);
			int p = rand.Next(n);

					for(int i=0; i<n; i++){
					for(int j=0; j<=i; j++){
					D[i,i] = rand.Next(10*n)+1;
					if(i == p) u[i] = 0;
					else u[i] = (rand.Next(10)+1);

				}
			}
			matrix A = Symeig.AMatrix(D, u, p);

			matrix B = A.copy();

			var stopwatch1 = new System.Diagnostics.Stopwatch();
			var stopwatch2 = new System.Diagnostics.Stopwatch();
			stopwatch1.Start();
			Symeig.EigDet(A, p);
			stopwatch2.Stop();
			var elapsedMs1 = stopwatch1.ElapsedMilliseconds;
				stopwatch2.Start();
				Eig.opti_jacobi_diag(B,V);
				stopwatch2.Stop();
				var elapsedMs2 = stopwatch2.ElapsedMilliseconds;

			Error.WriteLine($"{n} {elapsedMs1}, {elapsedMs2}");
		}
		
	}
}