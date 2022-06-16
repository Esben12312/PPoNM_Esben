using System;
using System.Linq;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		int p = 4;
		int n = 9;
		matrix D = new matrix(n,n);
		vector u = new vector(n);
		var rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<=i; j++){
				D[i,i] = rand.Next(100)+1;
				if(i == p) u[i] = 0;
				else u[i] = (rand.Next(10)+1);

			}
		}
		
		WriteLine($"Generating a Random {n} by {n} symmetric diagonal matrix D:");
		D.print();
		WriteLine("\n");
		WriteLine($"Generating a Random {n} vector with u_p = 0");
		u.print();
		matrix A = Symeig.AMatrix(D, u, p);
		WriteLine("\n");

		WriteLine("Determined A matrix:");
		A.print();
		WriteLine("\n");

		WriteLine("Calculating Eigenvalues");
		vector e = Symeig.EigDet(A, p);
		e.print();
		WriteLine("\n");

		vector res = Symeig.EigValtest(A, e, p);

		WriteLine($"Testing that Eigenvalues returns approx 0-vector: {res.approx(new vector(n))}");
		WriteLine("\n");
		res.print();
		

	}
}

