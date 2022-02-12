using static System.Console;
using static System.Math;
using static vec;
using System.IO;
public class vectest {

	static int TestNumber = 0;
	static int noOfFails = 0;
	private static StreamWriter _outputStream;
	
	public static void startTest() {
		File.Create("test.txt").Dispose();
		_outputStream = new StreamWriter("test.txt");
	}

	public static void test(vec v, vec res, bool show) {
		//returns Suscces if the two vectors are identical
		vectest.TestNumber++;
		if(v == res) { 
			if(show){
				_outputStream.WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Fail" );
			_outputStream.WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
	}

	public static void negativeTest(vec v, vec res, bool show) {
		vectest.TestNumber++;
		//returns Suscces if the two vectors are identical
		if(v != res) { 
			if(show) {
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Fail" );
			_outputStream.WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
	}

	public static void test(double v, double res, bool show) {
		//returns Suscces if the two vectors are identical
		vectest.TestNumber++;
		if(v == res) { 
			if(show){
				_outputStream.WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Fail" );
			_outputStream.WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
		
	}

	public static void negativeTest(double v, double res, bool show) {
		vectest.TestNumber++;
		//returns false if the two vectors are identical
		if(v != res) { 
			if(show) {
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
		}
		else {
			vectest.noOfFails++;
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Fail" );
			_outputStream.WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
	}

	public static void test(double v, vec res, bool show) {
		//returns false
		vectest.TestNumber++;
		{
			vectest.noOfFails++;
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Fail" );
			_outputStream.WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
		
	}

	public static void negativeTest(double v, vec res, bool show) {
		vectest.TestNumber++;
		//returns Suscces
			if(show) {
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
	}

	public static void test(vec v, double res, bool show) {
		//returns false
		vectest.TestNumber++;
		{
			vectest.noOfFails++;
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Fail" );
			_outputStream.WriteLine($"Expected {res.ToString()}, got {v.ToString()}");
		}
		
	}

	public static void negativeTest(vec v, double res, bool show) {
		vectest.TestNumber++;
		//returns Suscces
			if(show) {
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
	}

	public static void approxTest(bool v, bool res, bool show) {
		vectest.TestNumber++;
		// 
		if(v==res) {
					if(show) {
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Succes" );
			}
			else {
			vectest.noOfFails++;
			_outputStream.WriteLine( $"Test no. {TestNumber}. = Fail" );
			_outputStream.WriteLine($"Expected {res.ToString()}, got {v.ToString()}");				
			}
		}
	}

	public static void endTest() {
		if(noOfFails == 0) {
			_outputStream.WriteLine("All tests returned Succes");
		}
		else {
			_outputStream.WriteLine($"{noOfFails} tests failed");
		}

	_outputStream.Flush();
	_outputStream.Close();
	}

}