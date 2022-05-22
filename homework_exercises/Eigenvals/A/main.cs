using System;
using System.Linq;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		int n = 5;
		int m = n;
		matrix A = new matrix(n,m);
		matrix V = new matrix(n,n);
		var rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<=i; j++){
				A[i,j] = rand.Next(11);
				A[j,i] = A[i,j];
			}
		}
		
		WriteLine($"Generating a Random {n} by {m} symmetric matrix:");
		A.print();
		WriteLine("\n");
		
		int e;
		matrix A_copy = A.copy();
		e = Eig.jacobi_diag(A, V);
		matrix D = A.copy();
		WriteLine("\n");

		WriteLine("Jacobi Diagonalized matrix:");
		D.print();
		WriteLine("\n");

		WriteLine("Determined Eigenvectors:");
		WriteLine($"Number of sweeps {e}");
		WriteLine("Eigenvectors:");
		V.print();
		WriteLine("\n");

		matrix VTV = (V.transpose())*V;
		WriteLine("V^TV:");
		VTV.print();
		WriteLine("\n");

		matrix VVT = V*(V.transpose());
		WriteLine("VV^T:");
		VVT.print();
		WriteLine("\n");

		WriteLine($"V^T A V equals Diagonalized matrix: {(V.transpose()*A_copy*V).approx(D)}");
		WriteLine("\n");

		WriteLine($"V D V^T equals Original matrix: {(V*D*(V.transpose())).approx(A_copy)}");
		WriteLine("\n");
	}
}

