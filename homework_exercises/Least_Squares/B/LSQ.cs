using System;
public class LSQ{
	public static (double[], matrix) lsfit(Func<double,double>[] fs, double[] x, double[] y, double[] dy){
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

		double[] res = new double[c.size];
		for(int i=0; i<res.Length; i++){
			res[i] = c[i];
		}

		matrix R_RT_R = R.transpose()*R;
		matrix R2 = new matrix(R_RT_R.size2, R_RT_R.size2);
		QRGS.QRGSdecomp(R_RT_R, R2);
		matrix S = QRGS.QRGSinverse(R_RT_R, R2);

		return (res, S);
	}
}