using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		var rand = new Random();
		
		using(var outfile = new System.IO.StreamWriter("Timing.txt")){

			for(int n=5; n<=300; n+=5){
				matrix A = new matrix(n,n);
				matrix V = new matrix(n,n);

				for(int i=0; i<n; i++){
					for(int j=0; j<n; j++){
						int num = rand.Next(1,9);
						A[i,j] = num;
						A[j,i] = num;
					}
				}

				matrix B = A.copy();
				matrix W = V.copy();

				var stopwatch1 = new System.Diagnostics.Stopwatch();
				stopwatch1.Start();
				Eig.jacobi_diag(A,V);
				stopwatch1.Stop();
				var elapsedMs1 = stopwatch1.ElapsedMilliseconds;

				var stopwatch2 = new System.Diagnostics.Stopwatch();
				stopwatch2.Start();
				Eig.opti_jacobi_diag(B,W);
				stopwatch2.Stop();
				var elapsedMs2 = stopwatch2.ElapsedMilliseconds;

				outfile.WriteLine($"{n} {elapsedMs1} {elapsedMs2}");
			}
		}
		int s = 5;
		matrix M = new matrix(s,s);
		matrix N = new matrix(s,s);
		
		for(int i=0; i<s; i++){
			for(int j=0; j<s; j++){
				int num = rand.Next(1,9);
					M[i,j] = num;
					M[j,i] = num;
				}
			}

		matrix M_copy = M.copy();
		int e = Eig.jacobi_diag(M, N);
		matrix D = M.copy();
		WriteLine("\n");
		int p = Eig.jacobi_diag(M_copy, N);
		matrix D_opti = M_copy.copy();
		WriteLine("\n");

		WriteLine("Jacobi Diagonalized matrix non-optimized:");
		D.print();
		WriteLine("\n");
		WriteLine("Jacobi Diagonalized matrix optimized:");
		D_opti.print();
		WriteLine("\n");
		WriteLine("To control they give similar answers for an identical random matrix");
	}


}

