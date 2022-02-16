using static System.Console;
using static System.Math;

	public class vec {
		public double x,y,z;
		//constructors:
		public vec() {x=y=z=0;}
		public vec(double a, double b, double c) {x=a; y=b; z=c;}
		//operators:
		public static vec operator*(vec v, double c) {return new vec(c*v.x, c*v.y, c*v.z);}
		public static vec operator*(double c, vec v) {return v*c;}
		public static vec operator+(vec u, vec v) {return new vec (u.x+v.x, u.y+v.y, u.z+v.z);}
		public static vec operator-(vec u, vec v) {return new vec (u.x-v.x, u.y-v.y, u.z-v.z);}
		public static vec operator+(vec v) {return +v;}
		public static vec operator-(vec v) {return new vec(-v.x, -v.y, -v.z);}
		public static bool operator== (vec v, vec u) {if(u.x==v.x && u.y == v.y && u.z == v.z ) {return true;} else {return false;}}
		public static bool operator!= (vec v, vec u) {if(u.x==v.x && u.y == v.y && u.z == v.z ) {return false;} else {return true;}}
		//methods:
		public void print(string s){Write(s); WriteLine($"{x} {y} {z}");}
		public void print() {this.print("");}
		public override string ToString() {return $"{x} {y} {z}";}


		public static double Dot(vec v, vec u) {return v.x*u.x + v.y*u.y + v.z*u.z;}

		public static vec Cross(vec v, vec u) {return new vec(v.y*u.z-v.z*u.y, v.z*u.x-v.x*u.z, v.x*u.y-v.y*u.x);}

		public static double Norm(vec v) {return Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);}

		public bool approx(vec other)
		{
			double tau = 1e-9, epsilon = 1e-9;
			if(Abs(this.x - other.x) < tau && Abs(this.y - other.y) < tau && Abs(this.y - other.y) < tau || Abs(this.x - other.x)/(Abs(this.x)+Abs(other.x)) < epsilon && Abs(this.y - other.y)/(Abs(this.y)+Abs(other.y)) < epsilon && Abs(this.z - other.z)/(Abs(this.z)+Abs(other.z)) < epsilon) {
				return true;
			}
			else {
					return false;
			}
		}
		public static bool approx(vec u, vec v) {return u.approx(v);}
	}

