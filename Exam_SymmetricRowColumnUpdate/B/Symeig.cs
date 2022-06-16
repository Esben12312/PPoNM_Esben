using static System.Math;
using static System.Console;
using System;
public class Symeig{
	

	public static matrix AMatrix(matrix D, vector u, int p){ 
		int n = D.size1;
		matrix A = new matrix(n, n);
		if(n != D.size2){WriteLine("D must be symmetric"); return A;}
		
		for(int i=0; i<n; i++){
				A[i,i] = D[i,i];
			}

		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				if(i == p){
					A[i,j] = A[i,j]+u[j];
				}
				if(j == p){
					A[i,j] = A[i,j]+u[i];
				}
			
			}
		}
		return A;
	}

	public static vector EigDet(matrix A, int p){
		int n = A.size1;
		vector eig = new vector(n);
		int maxiter = 100; //maximum iterations
		double eps = 1E-9;
		double f = 0;
		double df = 0;
		double eig0;
		var rand = new Random();
		int r = 0;
		int Rmax = 1500; //maximum random starting guesses
		for(int i=0; i<n; i++){
			eig[i]=A[i,i]+0.1;
		}
		


		for(int i=0; i<n; i++){
			r=0;
			for(int j = 0; j<maxiter; j++){
					f=0;
					df=0;
					for(int k=0; k<n; k++){ //Determining f
						if(k == p) f = f - (A[p, p]-eig[i]);
						else f = f + A[k, p]*A[k, p]/(A[k, k]-eig[i]);
					}
		
					for(int k=0; k<n; k++){ //Determining df
						if(k == p) df = df + 1;
						else df = df + A[k, p]*A[k, p]/((A[k, k]-eig[i])*(A[k, k]-eig[i]));
					}
					
					eig0 = eig[i];

						if(Abs(f) < eps) { //test for valid solution
							for(int k=1; k<=i;k++){ //test if solution is already found
								if(eig[i] < eig[i-k]+0.5 && eig[i] > eig[i-k]-0.5){
									if(r < Rmax/2){ eig[i]=A[i,i]+rand.Next(100)/10; j=0; r++;}
									else {eig[i]=A[i,i]-rand.Next(100)/10; j=0; r++;}
								}
							}
							if(eig0 == eig[i]){	//test for valid solution
							break;
							}
						}

					
					eig[i] = (eig[i] - f/df); //Newton-Raphson method
				
					
					
					if(double.IsNaN(eig[i])){ //Testing if random division by zero if eig(i) == A(k,k)
						eig[i]=rand.Next(100);
						 j=0;
						 r++;
					}

					if(j==maxiter-2){eig[i]=rand.Next(100); //No unique solution found within iterations 100 iterations
						 j=0;
						 r++;}
					
					if(r>Rmax){eig[i]=eig[i-1]; break;} // no unique solution found with 1000 starting guesses
			}		
		} 
		return eig;
	}

	public static vector EigValtest(matrix A, vector eig, int p) {
		int n = A.size1;
		vector res = new vector(n);
		for(int j=0; j<n; j++){
		for(int k=0; k<n; k++){
			if(k == p) res[j] = res[j]-(A[p, p]-eig[j]);
			else res[j] = res[j] + A[k, p]*A[k, p]/(A[k, k]-eig[j]);
		} 
	}
		return res;
	}


	public static (double, vector) PowerIt(matrix A) {
		int iter = 10000;
		int n = A.size1;
		double eig;
		var rand = new Random();
		vector v = new vector(n);
			for(int i=0; i<n;i++){
				v[i]=rand.NextDouble();
				A[i,i]=A[i,i];
			}
			for(int i=0; i<iter;i++){
				vector v1 = A*v;
				eig = v1.norm();
				v = v1/v1.norm();
			}
    	return (eig, v);      
    }

}