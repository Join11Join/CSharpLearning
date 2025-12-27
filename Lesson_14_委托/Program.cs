using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_14_委托
{
	delegate void MyDel(int value);//声明委托类型	  （MyDel是委托类型 不是委托对象）



	internal class Program
	{
		static void PrintLow(int value)
		{
			Console.WriteLine($"{value}-Low Value");
		}

		static void PrintHigh(int value)
		{
			Console.WriteLine($"{value}-High Value");
		}

		static void MMain()
		{
			MyDel del;//声明委托变量

			Random rand = new Random();
			int randomValue = rand.Next(0, 99);

			del = randomValue < 50 ?
				new MyDel(PrintLow) :
				new MyDel(PrintHigh);
			del(randomValue);
		}


		static void Main(string[] args)
		{
			MMain();

		}
	}
}
