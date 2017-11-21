using System;

namespace Test.Utilities
{
	public interface IEnumTesterExpectation<out TEnum, TResult>
	{
		IEnumTesterRunnable<TEnum, TResult> ExpectedResult(Func<TResult, bool> expectation);
	}
}