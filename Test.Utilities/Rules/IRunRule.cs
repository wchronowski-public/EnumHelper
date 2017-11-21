using System;

namespace Test.Utilities.Rules
{
	internal interface IRunRule<out TEnum, in TResult> where TEnum : IConvertible
	{
		IRunRule<TEnum, TResult> WithMessageFormat(string messageFormat);
		IRunRule<TEnum, TResult> WithTitleFormat(string titleFormat);
		IEnumTesterResult Run(Func<TEnum, TResult> method);
	}

	internal interface IRunRuleExpectation<out TEnum, TResult> where TEnum : IConvertible
	{
		IRunRule<TEnum, TResult> WithExpectation(Func<TResult, bool> expectation);
	}
}