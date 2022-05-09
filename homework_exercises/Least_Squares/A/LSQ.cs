using System;
public class LSQ{
	public static vector lsfit(Func<double,double>[] fs, double[] x, double[] y, double[] dy){
		int n = x.Length;
		int m = fs.Length;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		
		for(int i=0; i<n; i++){
			b[i] = y[i]/dy[i];
			for(int j=0; j<m; j++){

				A[i,j] = fs[j](x[i])/dy[i]; 

			}
		}

		
		matrix R = new matrix(m,m);
		QRGS.QRGSdecomp(A,R);
		matrix Q = A;
	
		
		vector c = QRGS.QRGSsolve(Q,R,b);
		return c;
	}
}