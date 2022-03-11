using System;
using static System.Console;
using static System.Math;
public static class main{
	public static double erf(double z) {
		double integral = integrate.quad(x => Exp(-x*x), a:0, b:z);
		return 2/Sqrt(PI)*integral;
	}

	public static void Main() {
		for(double x=-4; x<=4; x+=1.0/32){
			WriteLine($"{x} {erf(x)}");
		}
	}
}
