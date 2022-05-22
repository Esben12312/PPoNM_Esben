using System;
using System.Linq;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		TestNCon();
		TestRCon();
		CompareSolutions();
	}

		public static void TestNCon(){
		int nmax = 250;
		double[] table_energies = new double[] {-0.5, -0.125, -0.055};
		using(var outfile = new System.IO.StreamWriter("n_con.txt")){
			for(int en=0; en<=2; en++){
				for(int np=10; np<nmax; np+=5){
					(matrix H, vector r, double dr) = GenerateH(np);
					matrix V = new matrix(H.size1, H.size2);
                        		int e = Eig.jacobi_diag(H, V);
					outfile.WriteLine($"{np} {H[en, en]} {table_energies[en]}");
                        	}
				outfile.WriteLine("\n");
			}
		}
		}

		public static void TestRCon(){ 
		int rmax = 25;
		double dr = 0.2;
		double[] tabular = new double[] {-0.5, -0.125, -0.055};
		using(var outfile = new System.IO.StreamWriter("r_con.txt")){
			for(int en=0; en<=2; en++){
				for(double r=1; r<rmax; r+=0.5){
					int np = (int)(r/(dr-0.1));	
					(matrix H, vector rs, double dr_H) = GenerateH(np);
					matrix V = new matrix(H.size1, H.size2);
					int e = Eig.jacobi_diag(H, V);
                        		outfile.WriteLine($"{r} {H[en, en]} {tabular[en]}");
					}
				outfile.WriteLine("\n");
				}
			}
		}

		public static void CompareSolutions(){
		(matrix H, vector r, double dr) = GenerateH(250);
				matrix V = new matrix(H.size1, H.size2);
                int e = Eig.jacobi_diag(H, V);

                var Schrödinger = new Func<double,double>[] {x => 2*Exp(-x), x => -1.0/Sqrt(2)*(1-1.0/2*x)*Exp(-x/2), x => 2.0/(3*Sqrt(3))*(1-2.0/3*x+2.0/27*x*x)*Exp(-x/3)};

                int emax = 2;
                for(int elevel=0; elevel<=emax; elevel++){
                        for(int i=0; i<V.size1; i++){
                                WriteLine($"{r[i]} {V[elevel][i]/Sqrt(dr)} {r[i]*Schrödinger[elevel](r[i])}");
                        }
                WriteLine("\n");
                }

		}

		public static (matrix, vector, double) GenerateH(int npoints){
                double dr=0.2;
                vector r = new vector(npoints);
                for(int i=0;i<npoints;i++){
                        r[i]=dr*(i+1);
                }
                matrix H = new matrix(npoints,npoints);
                for(int i=0;i<npoints-1;i++){
                        matrix.set(H,i,i,-2);
                        matrix.set(H,i,i+1,1);
                        matrix.set(H,i+1,i,1);
                }
                matrix.set(H,npoints-1,npoints-1,-2);
                H*=-0.5/dr/dr;
                for(int i=0;i<npoints;i++){
                        H[i,i]+=-1/r[i];
                }
		return (H, r, dr);
	}
}

