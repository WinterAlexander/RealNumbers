using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
			RealNumber num = 3;

			num += 3;

			num = num * num - 2;

			num = num.SquareRoot();

			num = num ^ 2;

			Console.WriteLine(num.ToString() + ": " + num.Value);

			while(true);
        }
    }
}
