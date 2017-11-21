using Test.Utilities.Rules;

namespace Test.Utilities
{
	public interface IEnumTesterResult
	{
		RuleStatus Status { get; }
		string Message { get; }
		void Combine(IEnumTesterResult result);
	}
}