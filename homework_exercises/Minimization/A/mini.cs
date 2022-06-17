using static System.Math;
using System;

public class mini{
	private static double eps = Pow(2,-26);

	public static (vector, int) qnewton(Func<vector,double> f, vector x, double acc){
		int s=0;
		int maxsteps=100000;
		int n=x.size;
		matrix A = new matrix(n,n);
		A.set_identity();
		
		vector v = gradient(f,x);

		//Backtracking linesearch
		while(s<maxsteps){
			s++;
			vector l = new vector(n);
			vector xs;
			double fxs;
			double fx = f(x);
			double lambda = 1;
			vector Dx = -A*v;
			while(true){
				s++;
				l = lambda*Dx;
				xs = x+l;
				fxs = f(xs);
				if(fxs<fx){
					break;
				}
				if(lambda<eps){
					A.set_identity();
					break;
				}
				lambda /= 2;
			}
			vector vx = gradient(f, xs);
			vector y = vx-v;
			vector u = l-A*y;
			double uTy = u%y;
			if(Abs(uTy)>1e-6){
				A.update(u,u,1/uTy);
			}
			x=xs;
			v=vx;
			fx=fxs;
			if(Abs(v.norm())<acc){break;}
		}
		return (x,s);
	}

	public static vector gradient(Func<vector,double> f, vector v){
	double dx;
	vector u = new vector(v.size);
	for(int i=0; i<v.size; i++){
		dx = Abs(v[i])*eps;
		if(Abs(v[i])<Sqrt(eps)){
			dx = eps;
		}
		vector vdx = v.copy();
		vdx[i] += dx;
		u[i] = (f(vdx)-f(v))/dx;

                }
	return u;
	}
}