using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class Base_ChildClass : IExecution
	{
		public MethodEnums Name => MethodEnums.BaseChildClass;

		public void Execute()
		{
			new C().FunctionRun();
		}

		public class A
		{
			public virtual void Run()
			{
				Console.WriteLine("BaseClass");
			}
		}

		public class B : A
		{
			public override void Run()
			{
				Console.WriteLine("ChildClass");
			}
		}

		public class C
		{
			public void FunctionRun()
			{
				var first = new B();
				A second = first;
				second.Run();
			}
		}
	}
}
