using System.Collections.Generic;

namespace Test.Utilities
{
	public interface IEnumTesterEnum<TEnum, TResult>
	{
		IEnumTesterExpectation<TEnum, TResult> ExpectedEnums(IEnumerable<TEnum> validEnums);
	}
}