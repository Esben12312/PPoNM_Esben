using static System.Math;
using static System.Console;
using System.Threading;

public class data { public int a, b; public double sum;} 

public class main {

	public static void harmonic_sum(object obj) {
		data x = (data) obj;
		x.sum = 0; for(int i = x.a; i<=x.b; i++) x.sum += 1.0/i;
	}

	public static void Main() {
		data x = new data();
		x.a = 1; x.b=1000; x.sum = 0;
		Thread t = new Thread(harmonic_sum);
		WriteLine($"The inital value for the harmonic sum in the current thread is {x.sum}");
		t.Start(x);
		WriteLine("Now the harmonic sum works on its own thread");
		WriteLine($"The harmonic sum in the current thread is {x.sum}");
		x.sum = x.sum+1;
		WriteLine("Add one to the harmonic sum to test allow changes without chaning the thread");
		WriteLine($"The harmonic sum in the current thread is {x.sum}");
		t.Join();
		WriteLine("Joining the two threads");
		WriteLine($"Gives the harmonic sum from {x.a} to {x.b} equals {x.sum}");
	}
}