using static System.Console;
using static System.Math;

public class QRGS{
	public matrix Q,R;
	public QRGS(matrix A){/* run the Gram-Schmidt process */}
	public vector solve(vector b){/* back-substitute Q^T*b */}
	public matrix inverse(){/* return the inverse matrix (part B) */}
	public double determinant(){/* return ΠiRii */}
}