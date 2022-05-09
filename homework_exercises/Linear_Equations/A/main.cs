using System;
using static System.Console;
using static System.Random;

class main{
	public static void Main(){

		TestDecomp();
		TestSolver();
	
	}
	public static void TestDecomp(){
		int n = 4;
                int m = 3;
                matrix A = new matrix(n,m);

                var rand = new Random();
                for(int i=0; i<n; i++){
                        for(int j=0; j<m; j++){
                        A[i,j] = rand.Next(11);
                        }
                }
                matrix A_copy = A.copy();

                WriteLine("Testing QRGS decomposion:");
                WriteLine($"Initial random {n} by {m} matrix:");
                A.print();

                WriteLine("Orthogonalizing...");
                matrix R = new matrix(m,m);
                QRGS.QRGSdecomp(A, R);
                matrix Q = A.copy();

                WriteLine("QRGS decomposed matrices:");
                WriteLine("Q:");
                Q.print();
                WriteLine("R:");
                R.print();

                matrix I = new matrix(m,m);
                for(int i=0; i<m; i++){
                        for(int j=0; j<m; j++){
                                if(i==j){I[i,j] = 1;}
                                else{I[i,j] = 0;}
                        }
                }

                matrix QTQ = Q.transpose()*Q;

                WriteLine("Control of the result");

                WriteLine($"Test 1: Q^T*Q ~ I, returns: {I.approx(QTQ)} \n");

                WriteLine($"Test 2: QR ~ A, returns: {A_copy.approx(Q*R)} \n");
	}
	public static void TestSolver(){
		WriteLine("Testing lin. eq. solver");
		Random rand = new Random();
		int n=4;
                int m=n;
                int N=9;
                matrix A = new matrix(n,m);
                matrix R = new matrix(m,m);
                vector b = new vector(n);
                for(int i=0; i<n; i++){
                        b[i] = rand.Next(N);
                        for(int j=0; j<m; j++){
                        A[i,j] = rand.Next(N);
                        }
                }
		
		WriteLine($"Initial random {n} by {m} matrix:");
		A.print();
		WriteLine($"Initial random vector of dimension {n}:");
		b.print();
		
		WriteLine("**solving**");
                matrix A_copy = A.copy();
                QRGS.QRGSdecomp(A, R);
                matrix Q = A.copy();
                vector x = QRGS.QRGSsolve(Q, R, b);
		vector Ax = A_copy*x;

		WriteLine($"Testing Ax ~ b: {Ax.approx(b)} \n");
	}
}