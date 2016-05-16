

using System;

namespace RealNumbers
{
	///<sumary>
	///	Represents a real number
	///</sumary>
	abstract public class RealNumber
	{
		public abstract decimal Value
		{
			get;
		}
		
		public abstract int GetPriority();
		
		public double DoubleValue
		{
			get
			{
				return (double)Value;
			}
		}
		
		public float FloatValue
		{
			get
			{
				return (float)Value;
			}
		}
		
		public RealNumber SquareRoot()
		{
			return Root(new SimpleNumber(2));
		}
		
		public RealNumber Root(RealNumber num2)
		{
			return new Root(this, num2);
		}
		
		/*public RealNumber Factorial(RealNumber num2)
		{
			return new Factorial(this, num2);
		}*/
		
		public static RealNumber operator +(RealNumber num1, RealNumber num2)
		{
			return new Sum(num1, num2);
		}
		
		public static RealNumber operator -(RealNumber num1, RealNumber num2)
		{
			return new Difference(num1, num2);
		}
		
		public static RealNumber operator *(RealNumber num1, RealNumber num2)
		{
			return new Product(num1, num2);
		}
		
		public static RealNumber operator /(RealNumber num1, RealNumber num2)
		{
			return new Quotient(num1, num2);
		}
		
		public static RealNumber operator ++(RealNumber num1)
		{
			return new Sum(num1, new SimpleNumber(1));
		}
		
		public static RealNumber operator --(RealNumber num1)
		{
			return new Difference(num1, new SimpleNumber(1));
		}
		
		public static RealNumber operator -(RealNumber num1)
		{
			return new Product(new SimpleNumber(-1), num1);
		}
		
		public static RealNumber operator ^(RealNumber num1, RealNumber num2)
		{
			return new Power(num1, num2);
		}

		public static implicit operator RealNumber(long i)
		{
			return new SimpleNumber(i);
		}
	}
	
	public class SimpleNumber : RealNumber
	{
		private long num;
		
		public SimpleNumber(short num)
		{
			this.num = num;
		}
		
		public SimpleNumber(int num)
		{
			this.num = num;
		}
		
		public SimpleNumber(long num)
		{
			this.num = num;
		}
		
		public override decimal Value
		{
			get
			{
				return num;
			}
		}
		
		public override string ToString()
		{
			return num.ToString();
		}
		
		public override int GetPriority()
		{
			return 0;
		}
	}
	
	public class Sum : RealNumber
	{
		private RealNumber num1, num2;
		
		public Sum(RealNumber num1, RealNumber num2)
		{
			this.num1 = num1;
			this.num2 = num2;
		}
		
		public override decimal Value
		{
			get
			{
				return num1.Value + num2.Value;
			}
		}
		
		public override string ToString()
		{
			return (num1.GetPriority() >= GetPriority() ? "(" + num1.ToString() + ")" : num1.ToString()) + " + " + (num2.GetPriority() >= GetPriority() ? "(" + num2.ToString() + ")" : num2.ToString());
		}
		
		public override int GetPriority()
		{
			return 3;
		}
	}
	
	public class Difference : RealNumber
	{
		private RealNumber num1, num2;
		
		public Difference(RealNumber num1, RealNumber num2)
		{
			this.num1 = num1;
			this.num2 = num2;
		}
		
		public override decimal Value
		{
			get
			{
				return num1.Value - num2.Value;
			}
		}
		
		public override string ToString()
		{
			return (num1.GetPriority() >= GetPriority() ? "(" + num1.ToString() + ")" : num1.ToString()) + " - " + (num2.GetPriority() >= GetPriority() ? "(" + num2.ToString() + ")" : num2.ToString());
		}
		
		public override int GetPriority()
		{
			return 3;
		}
	}
	
	public class Product : RealNumber
	{
		private RealNumber num1, num2;
		
		public Product(RealNumber num1, RealNumber num2)
		{
			this.num1 = num1;
			this.num2 = num2;
		}
		
		public override decimal Value
		{
			get
			{
				return num1.Value * num2.Value;
			}
		}
		
		public override string ToString()
		{
			return (num1.GetPriority() >= GetPriority() ? "(" + num1.ToString() + ")" : num1.ToString()) + " * " + (num2.GetPriority() >= GetPriority() ? "(" + num2.ToString() + ")" : num2.ToString());
		}
		
		public override int GetPriority()
		{
			return 2;
		}
	}
	
	public class Quotient : RealNumber
	{
		private RealNumber num1, num2;
		
		public Quotient(RealNumber num1, RealNumber num2)
		{
			this.num1 = num1;
			this.num2 = num2;
		}
		
		public override decimal Value
		{
			get
			{
				return num1.Value / num2.Value;
			}
		}
		
		public override string ToString()
		{
			return (num1.GetPriority() >= GetPriority() ? "(" + num1.ToString() + ")" : num1.ToString()) + " / " + (num2.GetPriority() >= GetPriority() ? "(" + num2.ToString() + ")" : num2.ToString());
		}
		
		public override int GetPriority()
		{
			return 2;
		}
	}
	
	public class Power : RealNumber
	{
		private RealNumber num1, num2;
		
		public Power(RealNumber num1, RealNumber num2)
		{
			this.num1 = num1;
			this.num2 = num2;
		}
		
		public override decimal Value
		{
			get
			{
				return (decimal)Math.Pow(num1.DoubleValue, num2.DoubleValue);
			}
		}
		
		public override string ToString()
		{
			return (num1.GetPriority() >= GetPriority() ? "(" + num1.ToString() + ")" : num1.ToString()) + "^" + (num2.GetPriority() >= GetPriority() ? "(" + num2.ToString() + ")" : num2.ToString());
		}
		
		public override int GetPriority()
		{
			return 1;
		}
	}
	
	public class Root : RealNumber
	{
		private RealNumber num1, num2;
		
		public Root(RealNumber num1, RealNumber num2)
		{
			this.num1 = num1;
			this.num2 = num2;
		}
		
		public override decimal Value
		{
			get
			{
				return (decimal)Math.Pow(num1.DoubleValue, 1 / num2.DoubleValue);
			}
		}
		
		public override string ToString()
		{
			return (num2.GetPriority() >= GetPriority() ? "(" + num2.ToString() + ")" : num2.ToString()) + "v/¯(" + num1.ToString() + ")";
		}
		
		public override int GetPriority()
		{
			return 1;
		}
	}
	
	/*
	public class Factorial : RealNumber
	{
		private RealNumber num;
		
		public Factorial(RealNumber num)
		{
			this.num = num;
		}
		
		public decimal Value
		{
			get
			{
				return 0;
			}
		}
		
		public override string ToString()
		{
			return (num.GetPriority() >= GetPriority() ? "(" + num.ToString() + ")" : num.ToString()) + "!";
		}
		
		public int GetPriority()
		{
			return 1;
		}
	}*/
}