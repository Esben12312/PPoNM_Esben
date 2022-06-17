using static System.Math;
using System;

public class roots{
	private static double eps = Pow(2,-26);

	public static (vector, int) newton(Func<vector,vector> f, vector x, double eps=1e-2){
		for(int i=0; i<x.size; i++){
			if(x[i] == 0) {x[i] = 1e-5;}
		}

		int n = x.size;
		matrix J = new matrix(n,n); 
		double d = 0;
		vector v = new vector(n);
		vector u = new vector(n);
		int k=0;
		bool r1 = true;
		
		while(r1){
			k++;
			vector fx = f(x);
			for(int i=0; i<n; i++){ 
				d = Abs(x[i])*Pow(2,-26);
				x[i] += d;

				for(int j=0; j<n; j++){
					J[j,i] = (f(x)[j]-fx[j])/d;
				}
				x[i] -= d;
			}

		matrix R = new matrix(n,n);
		matrix Q = J.copy();
		QRGS.QRGSdecomp(Q,R);
		vector Dx = QRGS.QRGSsolve(Q,R,-fx); 
		
		double lambda = 2.0;

		bool r2 = true; 
		while(r2){
			k++;
			lambda /= 2; 
			u = x+lambda*Dx; 
			v = f(u);
			if(v.norm() < (1-lambda/2.0)*fx.norm() || lambda < 1.0/64){
				r2 = false;
			}
		}
		
		x = u;
		fx = v;
		if(Dx.norm() < d || fx.norm() < eps){
			r1 = false;
		}
		
		}
		
		return (x, k);
		
	}

}