using System;
using static System.Math;
using static System.Console;
using static cmath;
class main{
static int Main(){
	int return_code=0;
	bool test;
	var rnd=new Random();
	int n=9;
	complex[] zs = new complex[n];
	for(int i=0;i<n;i++)
		zs[i]=new complex(2*rnd.NextDouble()-1,2*rnd.NextDouble()-1);

	Write("testing sqrt(-1) = ");
	test=sqrt(new complex(-1, 0)).approx(new complex (0, 1));

	Write($" {new complex (0, 1)} ");
		if(test) Write(" ...passed\n");

	Write("testing sqrt(i) = ");
	test=sqrt(new complex(0, 1)).approx(new complex (1/sqrt(2), 1/sqrt(2)));

	Write($" {new complex (1/sqrt(2), 1/sqrt(2))} ");
		if(test) Write(" ...passed\n");

	Write("testing exp(i) = ");
	test=exp(new complex(0, 1)).approx(new complex (cos(1), sin(1)));

	Write($" {new complex (cos(1), sin(1))} ");
		if(test) Write(" ...passed\n");

	Write("testing exp(i*pi) = ");
	test=exp(new complex(0, 1*PI)).approx(new complex (-1, 0));

	Write($" {new complex (-1, 0)} ");
		if(test) Write(" ...passed\n");

	Write("testing pow(i, i) = ");
	test= cmath.pow(new complex(0, 1), new complex(0, 1)).approx(exp(-PI/2));

	Write($" {exp(-PI/2)} ");
		if(test) Write(" ...passed\n");

	Write("testing ln(i) = ");
	test=cmath.log(I).approx(new complex(0, PI/2));

	Write($" {new complex(0, PI/2)} ");
		if(test) Write(" ...passed\n");

	Write("testing sin(i*pi) = ");
	test=sin(I*PI).approx(new complex(0, Sinh(PI)));

	Write($" {new complex(0, Sinh(PI))} ");
		if(test) Write(" ...passed\n");

if(return_code==0)
	Write("all tests passed \n");
else 
	Write("{0} tests FAILED \n",return_code);
return return_code;

}//Main
}//main
