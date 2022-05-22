using static System.Console;
using static System.Math;
using static spline;

class main{
	public static void Main(){
		
		double[] xs = new double[] {-10,-8,-6,-4,-2,0,2,4,6,8,10};
		double[] y1 = new double[xs.Length];
		double[] y2 = new double[xs.Length];
		double[] y3 = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){
			y1[i] = 1;
			y2[i] = 2*xs[i];
			y3[i] = 0.1*xs[i]*xs[i];	
		}

		spline.q_spline s1 = new spline.q_spline(xs, y1);
		for(int i=0;i<xs.Length; i++){
			WriteLine($"{xs[i]} {y1[i]}");
		}
		WriteLine("\n");
		for(double z=-10; z<=10; z+=1.0/64){
			double interp = s1.eval(z);
			double inte = s1.inte(z);
			double deriv = s1.deriv(z);
			WriteLine($"{z} {interp} {inte} {deriv}");
		}

		WriteLine("\n");
		spline.q_spline s2 = new spline.q_spline(xs, y2);
		for(int i=0;i<xs.Length; i++){
			WriteLine($"{xs[i]} {y2[i]}");
		}
		WriteLine("\n");
		for(double z=-10; z<=10; z+=1.0/64){
			double interp = s2.eval(z);
			double inte = s2.inte(z);
			double deriv = s2.deriv(z);
			WriteLine($"{z} {interp} {inte} {deriv}");
		}

		WriteLine("\n");
		spline.q_spline s3 = new spline.q_spline(xs, y3);
		for(int i=0;i<xs.Length; i++){
			WriteLine($"{xs[i]} {y3[i]}");
		}
		WriteLine("\n");
		for(double z=-10; z<=10; z+=1.0/64){
			double interp = s3.eval(z);
			double inte = s3.inte(z);
			double deriv = s3.deriv(z);
			WriteLine($"{z} {interp} {inte} {deriv}");
		}

		double[] x0 = new double[] {-7, -5, -3, -1, 1, 3, 5, 7};
		double[] y0 = new double[] {0, 0, 0, 0, 1, 1, 1, 1};		 
		WriteLine("\n");
		spline.q_spline s4 = new spline.q_spline(x0, y0);
		for(int i=0;i<x0.Length; i++){
			WriteLine($"{x0[i]} {y0[i]}");
		}
		WriteLine("\n");
		for(double z=-7; z<=7; z+=1.0/64){
			double interp = s4.eval(z);
			double inte = s4.inte(z);
			double deriv = s4.deriv(z);
			WriteLine($"{z} {interp} {inte} {deriv}");
		}
	}	
}