using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13_数组
{
	internal class Program
	{
		static void Main(string[] args)
		{

			#region 数组 一维数组，矩形数组，隐式类型数组
			//一维数组
			int[] arr1;//数组声明 ，没有初始化
			arr1 = new int[4];//实例化数组
			int[] arr2 = new int[2];//
			int[] arr3 = { 1, 2, 3, 4, 5, 6, 7 };//一维数组 设置显示初始值

			//arr3[8] = 1;  //索引超出了数组界限。没有输入长度，编译器通过初始化值的个数来推断长度
			int[] intarr = new int[] { 10, 20, 30, 40 };


			//多维数组
			//多维数组是由 主向量中的位置组成的，每个位置本身又是一个数组，称为子数组（subarray）
			//子数组向量中的位置的本身又是一个子数组
			//多维数组有 矩形数组（rectangular array）和 交错数组 （jagged array）两种类型

			//方括号内的逗号就是秩说明符，它们指定了数组的维度数。秩就是逗号数量加1，
			//比如，没有逗号代表一维数组，一个逗号代表二维数组，以此类推

			//矩形数组 rectangular array 二维数组	  [2,2]
			int[,] arr4 = {
				{ 1, 2 },{ 3, 4 },{ 5, 6 },{ 7, 8 }
			};
			//矩形三维数组 ;维度长度 [2,2,6]
			int[,,] arr5 = {
				{ { 1, 2, 11, 12, 21, 22 }, { 3, 4, 13, 14, 23, 24 }},
				{ { 5, 6, 15, 16, 25, 26 }, { 7, 8, 17, 18, 27, 28 } }
			};

			int[,] arr6;//数组声明维度就是固定的了，维度长度直到数组实例化时才会确定
			int[,,] arr7 = new int[3, 6, 2];


			//arr3.Rank;//返回数组维度的属性
			Console.WriteLine($"arr3:{arr3.Rank}维数组");
			Console.WriteLine($"arr4:{arr4.Rank}维数组");
			Console.WriteLine($"arr5:{arr5.Rank}维数组");
			//获取矩形数组元素
			int x4 = arr4[1, 0];
			Console.WriteLine($"x4 = {x4}"); //x4 = 3;
			int x5 = arr5[0, 0, 1];
			Console.WriteLine($"x5 = {x5}");//x5 = 2;
			x5 = arr5[1, 1, 3];
			Console.WriteLine($"x5 = {x5}");//x5 = 2;

			//隐式类型数组
			int[] arr8 = new int[] { 1, 2, 3, 4, 5, 6 };
			var arr9 = new[] { 1, 2, 3, 4, 5, 6 };
			#endregion

			#region	  交错数组
			//每交错数组是数组的数组
			//交错数组的子数组的元素个数可以不同
			//为数组的每一个维度使用一对方括号
			Console.WriteLine("交错数组--------jagged array-------------------------");
			//具有三个数组
			int[][] jagArr = new int[3][];// 声明并创建顶层数组
										  //声明并创建子数组								

			//交错数组的维度可以是大于1 的任意整数
			//和矩形数组一样，维度数组不饿能包含在数组类型声明部分
			int[][] jagArr1;    //秩等于2
			int[][][] jagArr2;  //秩等于3

			//交错数组的初始化不能在一个步骤中完成

			//交错数组是独立的数组，每一个数组必须独立创建
			int[][] jagArr3 = new int[3][];//1.实例化顶层数组
			jagArr3[0] = new int[] { 10, 20, 30 };   //实例化子数组
			jagArr3[1] = new int[] { 40, 50 };
			jagArr3[2] = new int[4] { 60, 70, 80, 90 };

			Console.WriteLine($"jagArr3.Length:{jagArr3[0].Length}");

			//交错数组可以有矩形数组
			int[][,] jagArr4;       //带有二维数组的交错数组
			jagArr4 = new int[3][,];  //实例化带有3个二维数组的交错数组

			jagArr4[0] = new int[,] {
				{ 11, 22 },
				{ 33, 44 }
			};
			jagArr4[1] = new int[,] {
				{ 33, 44, 55 },
				{ 55, 66, 77 }
			};
			jagArr4[2] = new int[,] {
				{ 100, 200, 300, 400, 500 },
				{ 600, 700, 800, 900, 1000 }
			};


			Console.WriteLine($"获取jagArr4维度0 的长度={jagArr4.GetLength(0)}");


			for (int i = 0; i < jagArr4.GetLength(0); i++)
			{
				for (int j = 0; j < jagArr4[i].GetLength(0); j++)    //这里使用0 下面是用1 ，是因为已经确认是二维数组
				{
					for (int k = 0; k < jagArr4[i].GetLength(1); k++)
					{
						Console.Write($"[{i}{j}{k}] = {jagArr4[i][j, k]}");
					}
					Console.WriteLine();
				}
				Console.WriteLine();
			}


			//一维数组有特定的优化指令，矩形数组没有这些指令，且不在相同级别进行优化。
			//因此，有时使用一维数组（可以被优化）的交错数组比矩形数组（不能被优化）更高效。
			//矩形数组的变成复杂度要低很多，因此它常会被作为一个单元 而不是数组的数组

			#endregion


			#region	数组与 foreach
			//在多维数组中，元素的处理次序是最右边的索引号最先递增， 当索引号从0得到长度减1时，开始开始递增它左边的索引，右边的被充值成0
			Console.WriteLine("--------数组与 foreach---------");
			Console.WriteLine("矩形数组");
			foreach (var item in arr4)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("交错数组");
			foreach (var item in jagArr3)
			{
				foreach (var item1 in item)
				{
					Console.WriteLine(item1);
				}
			}

			#endregion


			#region	  数组协变
			//在某些情况下，即使某个对象不是数组的基类型， 也可以把它赋值给数组元素。
			// 这种属性叫做数组协变（array covariance）
			//可以使用数组协变的情况
			//1.数组是引用类型数组
			//2.在赋值的对象类型和数组基类型之间有隐式转换或显示转换
			//由于在派生类和基类之间总是有隐式转换，因此总是可以将一个派生类的对象赋值给为基类声明的数组。
			//值类型数组没有协变								

			#endregion

			#region	 数组继承的最有用的一些成员
			Console.WriteLine("数组继承的最有用的一些成员");
			//Rank 属性 实例 获取数组的维度数
			//Length 属性 实例 获取数组中所有维度的元素总数
			//GetLength() 方法 实例 返回数组的指定维度的长度
			//Clear() 方法 静态  将某一范围内的元素设置为 0 或 null；
			//arr3 = { 1, 2, 3, 4, 5, 6, 7 };
			Array.Clear(arr3, 0, 2);
			foreach (var item in arr3)
			{
				Console.Write($"{item},");

			}
			//arr3 = { 0, 0, 3, 4, 5, 6, 7 };
			Console.WriteLine();
			//Sort 方法 静态  在一维数组中对元素进行排序
			arr3[0] = 90;
			arr3[1] = 76;
			Array.Sort(arr3);
			foreach (var item in arr3)
			{
				Console.Write($"{item},");
			}

			Console.WriteLine();
			//BinarySearch 方法 静态 使用二进制搜索，搜索一维数组中的值

			//Clone 方法 实例 进行数组的浅复制——对于值类型数组和引用类型数组，都只复制元素。
			//克隆数值类型数组会产生两个独立数组
			//克隆引用类型数组会产生指向相同对象的两个数组
			Console.WriteLine();
			int[] ints = { 1, 2, 3 };
			int[] ints1 = (int[])ints.Clone(); //Clone 方法返回object类型的引用，它必须被强制转换成数组类型。

			ints1[0] = 100;          //1,100
			Console.WriteLine($"ints[0]={ints[0]},ints1[0]={ints1[0]}");

			Test[] testArr = new Test[3] { new Test(), new Test(), new Test() };
			Test[] testArr1 = (Test[])testArr.Clone();

			testArr1[0].x = 100;                   //5 ,5
			Console.WriteLine($"testArr[0].x={testArr[0].x},testArr1[0].x={testArr1[0].x}");



			//IndexOf  方法 静态 返回一维数组中遇到的第一个值
			//Reverse 方法 静态 反转一维数组中某一范围内的元素
			//GetUpperBound	   方法 实例 获取指定维度的上限



			#endregion


			#region	数组与ref返回和ref局部变量
			//ref 返回 和 ref局部变量，常见用途是把对一个数组元素的引用传递回调用域
			//在调用域，可以通过ref局部变量给这个元素赋值
			Console.WriteLine();

			int[] scores = { 5, 80 };
			Console.WriteLine($"scores[0]={scores[0]},scores[1]={scores[1]}");
			ref int locationOfHigher = ref PointerToHightestPositive(scores);
			locationOfHigher = 0;
			Console.WriteLine($"scores[0]={scores[0]},scores[1]={scores[1]}");



			#endregion



		}

		public static ref int PointerToHightestPositive(int[] numbers)
		{
			int highest = 0;
			int indexOfHighest = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] > highest)
				{
					indexOfHighest = i;
					highest = numbers[i];
				}
			}

			return ref numbers[indexOfHighest];    // 找到最大数并返回
		}

	}

	class Test
	{
		public int x = 5;
	}
}
