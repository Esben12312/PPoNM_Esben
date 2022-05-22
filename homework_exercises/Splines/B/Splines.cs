using static System.Math;
using static System.Console;
using System.Diagnostics;

public static class spline{
	
	public class lnspline{
		private double[] x;
		private double[] y;
		
		public lnspline(double[] x, double[] y){
			this.x = x;
			this.y = y;
		}

        	public double eval(double z){
                	int ix = binsearch(x, z);
                	double dy = y[ix+1] - y[ix];
			double dx = x[ix+1] - x[ix];
			return y[ix] + dy/dx * (z-x[ix]);
       		}

		public double inte(double z){	
			double cumsum = 0;
		       	double dx = 0;
			double dy = 0;	
			int ix = binsearch(x, z);
			for(int i=0; i<ix; i++){
				dy = y[i+1] - y[i];
				dx = x[i+1] - x[i];
				cumsum += y[i]*dx + dy/dx * 0.5*dx*dx; 		
			} 
			dy = y[ix+1] - y[ix];
			dx = x[ix+1] - x[ix];
			cumsum += y[ix]*(z-x[ix]) + dy/dx * 0.5*(z-x[ix])*(z-x[ix]);
			return cumsum;
		}
	}

	public class q_spline {
		double[] x,y,b,c,s;
		public q_spline(double[] xs,double[] ys){
			int n = xs.Length; Trace.Assert(ys.Length>=n);
			x = new double[n];
			y = new double[n]; 
			b = new double[n-1];
			c = new double[n-1];
			s = new double[n-1];
		
			double[] dx = new double[n-1];
			double[] p = new double[n-1];
			for(int i=0;i<n;i++){x[i]=xs[i];y[i]=ys[i];}
		
			for(int i = 0; i < (n-1); i ++) {		
				dx[i] = x[i+1] - x[i];
				p[i] = (y[i+1] - y[i])/dx[i];
			
			}
			
			c[0] = 0;
			for(int i=0; i<n-2; i++){
				c[i+1] = 1/dx[i+1] * (p[i+1]-p[i] - c[i]*dx[i]); // Eq. 13, recursion up
			}
			c[n-2] = c[n-2]/2;
			for(int i=n-3; i>=0; i--){
				c[i] = 1/dx[i] * (p[i+1] - p[i] - c[i+1]*dx[i+1]);
			}
			for(int i=0; i<n-1; i++){
				b[i] = p[i] - c[i]*dx[i];
			}
		}

		public double eval(double z){
			Trace.Assert(z>=x[0] && z<=x[x.Length-1]); 
			int i = binsearch(x, z);
			double dx = z-x[i]; 
			return  y[i] + b[i]*dx + c[i]*dx*dx;
		}
		
		public double deriv(double z){ 
			int i = binsearch(x, z); 
			double  dx = z-x[i]; 
			return  b[i] + 2*c[i] * dx;}

		public double inte(double z){ 
			double cumsum=0;
			int idx=binsearch(x,z);
			for(int i=0; i<=idx; i++){
			double p = (y[i+1] - y[i])/(x[i+1] - x[i]); 
			double l =  y[i]*x[i] + p*(x[i]*x[i]/2-x[i]*x[i]); 
			if(z>=x[i+1]){ 
				double r = y[i]*x[i+1] + p*(x[i+1]*x[i+1]/2 -x[i]*x[i+1]); 
				cumsum += r-l; 
			}
			else{
				double r = y[i]*z + p*(z*z/2 -x[i]*z); 
				cumsum += r - l;
			}
		}
		return cumsum;
			
		}
	}

	public static int binsearch(double[] x, double z){
                /* locates the interval for z by bisection */
                int i=0, j=x.Length-1;
                while(j-i>1){
                        int mid=(i+j)/2;
                        if(z>x[mid]) i=mid; else j=mid;
                }
                return i;
        }
}	