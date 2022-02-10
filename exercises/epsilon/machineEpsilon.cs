using static System.Console;
using static System.Math;

public class machineEpsilon {
	public static void Machine(){
	
	double x=1;
	while(1+x !=1){x/=2;} x*=2;
	Write($"Machine epsilon for double = {x} (expected value: {Pow(2, -52)})\n");
	float y=1F;
	while((float)(1F+y) != 1F) {y/=2F;} y*=2F;
	Write($"Machine epsilon for float = {y} (expected value: {Pow(2, -23)})\n");
	}
	
	public static void summing(){
	
	int n = (int) 1e7;
	double epsilon = Pow(2, -52);
	double tiny=epsilon/2, sumA=0, sumB=0;
	
	sumA += 1; for(int i = 0; i < n; i++) {sumA += tiny;}
	Write($"sumA-1 = {sumA-1:e} should be {n*tiny:e}\n");

	for(int i = 0; i < n; i++) {sumB += tiny;} sumB += 1;
	Write($"sumB-1 = {sumB-1:e} should be {n*tiny:e}\n");
	}
	
	public static bool approx(double a, double b, double tau = 1e-9, double epsilon = 1e-9) {
	
	if(Abs(a-b)<tau) {return true;}

	if(Abs(a-b)/(Abs(a)+Abs(b)) < epsilon) {return true;}

	return false;
	}	



}
