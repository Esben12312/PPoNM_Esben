using System;
using static System.Console;
using static System.Random;

class main{
	public static void Main(string[] args){
                var rand = new Random();
                int N = 400;
                for(int n=5; n<=N; n+=5){
                        matrix Q = new matrix(n,n);
                        matrix R = new matrix(n,n);
                        for(int i=0; i<n; i++){
                                for(int j=0; j<n; j++){
                                        Q[i,j] = rand.Next(1,9);
                                }
                        }
                        var stopwatch = new System.Diagnostics.Stopwatch();
                        stopwatch.Start();
                        QRGS.QRGSdecomp(Q,R);
                        stopwatch.Stop();
                        var elapsedMs = stopwatch.ElapsedMilliseconds;
                        WriteLine($"{n} {elapsedMs}");
                }
        }
}
