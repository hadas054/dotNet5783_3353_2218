using System;

namespace Targil0
{
	partial class Program
	{
		static void Main(string[] args)
		{
			Welcome3353();
			Welcome2218();
			Console.ReadKey();
		}
		static partial void Welcome2218();

		private static void Welcome3353()
		{
			Console.Write("Enter your name: ");
			string username = Console.ReadLine();
			Console.WriteLine("{0}, welcome to my first console application", username);
		}
	}
}