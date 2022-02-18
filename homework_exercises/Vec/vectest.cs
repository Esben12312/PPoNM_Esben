using static System.Console;
using static System.Math;
using static vec;
using System.IO;
public class vectest {

	static int TestNumber = 0;
	static int noOfFails = 0;
	
	public static void startTest() {
		noOfFails=0;
		TestNumber=0;
		WriteLine("Initializing a new test.");
	}

	public static void test(vec v, vec res, bool show) {
		//returns Suscces if the two vectors are identical
		vectest.TestNumber++;
		if(v == res) { 
			if(show){
				WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			WriteLine( $"Test no. {TestNumber}. = Fail" );
			WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
	}

	public static void negativeTest(vec v, vec res, bool show) {
		vectest.TestNumber++;
		//returns Suscces if the two vectors are identical
		if(v != res) { 
			if(show) {
			WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			WriteLine( $"Test no. {TestNumber}. = Fail" );
			WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
	}

	public static void test(double v, double res, bool show) {
		//returns Suscces if the two vectors are identical
		vectest.TestNumber++;
		if(v == res) { 
			if(show){
				WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			WriteLine( $"Test no. {TestNumber}. = Fail" );
			WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
		
	}

	public static void negativeTest(double v, double res, bool show) {
		vectest.TestNumber++;
		//returns false if the two vectors are identical
		if(v != res) { 
			if(show) {
			WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			WriteLine( $"Test no. {TestNumber}. = Fail" );
			WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
	}

	public static void test(double v, vec res, bool show) {
		//returns false
		vectest.TestNumber++;
		{
			vectest.noOfFails++;
			WriteLine( $"Test no. {TestNumber}. = Fail" );
			WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
		
	}

	public static void negativeTest(double v, vec res, bool show) {
		vectest.TestNumber++;
		//returns Suscces
			if(show) {
			WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
	}

	public static void test(vec v, double res, bool show) {
		//returns false
		vectest.TestNumber++;
		{
			vectest.noOfFails++;
			WriteLine( $"Test no. {TestNumber}. = Fail" );
			WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
		
	}

	public static void negativeTest(vec v, double res, bool show) {
		vectest.TestNumber++;
		//returns Suscces
			if(show) {
			WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
	}

	public static void approxTest(bool v, bool res, bool show) {
		vectest.TestNumber++;
		// 
		if(v==res) {
					if(show) {
			WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
			else {
			vectest.noOfFails++;
			WriteLine( $"Test no. {TestNumber}. = Fail" );
			WriteLine($"Expected {res.ToString()}, got {v.ToString()}");				
			}
		}
	}

	public static void endTest() {
		if(noOfFails == 0) {
			WriteLine("All tests returned Succes");
		}
		else {
			WriteLine($"{noOfFails} tests failed");
		}
	}

}