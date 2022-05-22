using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
//using static Meta.Numerics.AdvancedMath;
public class main{

	public static double erf_int(double z){
		double integral = AdaptiveIntegrator.integrate(x => Exp(-x*x), a:0, b:z);
		return 2/Sqrt(PI)*integral;
	}

	public static void Main(){
		WriteLine("Testing on some knwon suggested integrals:\n");

		double a=0.0, b=1.0;
		Func<double,double> f1 = x => Sqrt(x);
		Func<double,double> f2 = x => 1/Sqrt(x);
		Func<double,double> f3 = x => 4*Sqrt(1-x*x);
		Func<double,double> f4 = x => Log(x)/Sqrt(x);


		double res1 = AdaptiveIntegrator.integrate(f1, a, b);
		double res2 = AdaptiveIntegrator.integrate(f2, a, b);
		double res3 = AdaptiveIntegrator.integrate(f3, a, b);
		double res4 = AdaptiveIntegrator.integrate(f4, a, b);
		WriteLine($"Integral sqrt(x) from 0 to 1: {res1}, expected 2/3");
		WriteLine($"Integral 1/sqrt(x) from 0 to 1: {res2}, expected 2");
		WriteLine($"Integral 4*sqrt(1-x^2) from 0 to 1: {res3}, expected Pi");
		WriteLine($"Integral ln(x)/sqrt(x) from 0 to 1: {res4}, expected -4");
		WriteLine("\n------------------------------------");

		WriteLine("Using the AdaptiveIntegrator to implement the error function");
		WriteLine("The result is plotted in erf.png along some table values");

		using(var outfile = new System.IO.StreamWriter("Erf.txt")){
			for(double x=-3; x<=3; x+=1.0/16){
				outfile.WriteLine($"{x} {erf_int(x)}");	
			}

		using(var outfile2 = new System.IO.StreamWriter("table_Erf.txt")){
			List<double> ys = new List<double>();
			ys.Add(-1);	ys.Add(-0.9867); ys.Add(-0.9661); ys.Add(-0.9229); ys.Add(-0.8427); ys.Add(-0.7112); ys.Add(-0.5205); ys.Add(-0.2763); ys.Add(0); ys.Add(0.2763); ys.Add(0.5205); ys.Add(0.7112); ys.Add(0.8427); ys.Add(0.9229); ys.Add(0.9661); ys.Add(0.9867); ys.Add(1); //5 decimals from WolframAlpha
			int i = 0;
			for(double x=-2; x<=2; x+=1.0/4){

				outfile2.WriteLine($"{x} {ys[i]}");	
				i++;
			}
		}
		}
	}
}