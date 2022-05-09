using System;
using static System.Console;
using static System.Random;

class main{
	public static void Main(){

		testQRGSinverse();
	
	}

        public static void testQRGSinverse() {
                                WriteLine("Testing QRGS inverse");
                Random rand = new Random();
                int n=5;
                matrix A = new matrix(n,n);
                matrix R = new matrix(n,n);
                matrix Q = new matrix(n,n);             
                for(int i=0; i<n; i++){
                        for(int j=0; j<n; j++){
                                int num = rand.Next(1,8); 
                                A[i,j] = num;
                                Q[i,j] = num;
                        }
                }
                WriteLine($"Randomly generated square matrix ({n}x{n}):");
                A.print();

                QRGS.QRGSdecomp(Q,R);

               

                WriteLine("Printing Inverse of A^-1:");

                matrix A_inv = QRGS.QRGSinverse(Q,R);

                A_inv.print();

                WriteLine("Printing A*A^-1:");
                matrix A_A_inv = A*A_inv;
                A_A_inv.print();


                WriteLine("Testing if this is the identity matrix!");
                matrix I = new matrix(n,n);
                I.set_identity();
                WriteLine($"A*A^-1 is approximately equal to I: {A_A_inv.approx(I)}");
        }
}