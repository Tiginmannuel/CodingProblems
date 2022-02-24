using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Interfaces
{
	public interface IExecution
	{
		public MethodEnums Name { get; }
		public void Execute();
	}
}
