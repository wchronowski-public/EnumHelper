using System.Text;
using Test.Utilities.Rules;

namespace Test.Utilities
{
	public class EnumTesterResult : IEnumTesterResult
	{
		public EnumTesterResult()
		{
		}

		public EnumTesterResult(RuleStatus status, string message)
		{
			Status = status;
			Message = message;
		}

		public RuleStatus Status { get; private set; } = RuleStatus.Valid;
		public string Message { get; private set; }

		public void Combine(IEnumTesterResult result)
		{
			Status = Status == RuleStatus.Invalid ? RuleStatus.Invalid : result.Status;

			Message = new StringBuilder()
				.Append(Message)
				.Append(result.Message)
				.ToString();
		}
	}
}