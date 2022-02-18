using System;
using static System.Console;
using static System.Math;
public class passf {
	
	public static void make_table(Func<double, double> f, double a, double b, double dx) {
		for(double i = a; i <= b; i = i + dx) {
			WriteLine($"x={i}, Sin(k * {i}) = {f(i)}");
		}
	}

}
