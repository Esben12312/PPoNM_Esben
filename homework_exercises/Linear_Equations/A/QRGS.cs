using static System.Console;
using static System.Math;

public class QRGS{
	public static void QRGSdecomp(matrix A, matrix R) {

		int m= A.size1;
		int n= A.size2;
		for(int i=0; i<n; i++){
				vector a = A[i];
				R[i, i] = Sqrt(a.dot(a));
				A[i] = a/R[i,i];				
			for(int j=i+1; j<n; j++){
				vector qi = A[i];
				vector aj = A[j];
				R[i,j] = qi.dot(aj);
				A[j] = aj-qi*R[i,j];
			}
		}
	}

	public static vector QRGSsolve(matrix Q, matrix R, vector b) {
		matrix Q_trans = Q.transpose();
		vector sol = Q_trans*b;
		backsub(R,sol);
		return sol;
	}

	public static void backsub(matrix U, vector c) {		
		for(int i=c.size-1; i>=0; i--) {
			double sum = 0;
			for(int k=i+1; k<c.size; k++) {
				sum+=U[i,k]*c[k];
			}
		c[i] = (c[i]-sum)/U[i,i];
		}
	}
}
