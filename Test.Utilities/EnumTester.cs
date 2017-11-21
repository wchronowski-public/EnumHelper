using System;
using System.Collections.Generic;
using System.Linq;
using Test.Utilities.Rules;

namespace Test.Utilities
{
	public class EnumTester<TEnum, TResult> : IEnumTesterExpectation<TEnum, TResult>, IEnumTesterRunnable<TEnum, TResult>, IEnumTesterEnum<TEnum, TResult> where TEnum : IConvertible
	{
		private readonly IList<IRunRule<TEnum, TResult>> _rules = new List<IRunRule<TEnum, TResult>>();

		public IEnumTesterExpectation<TEnum, TResult> ExpectedEnums(IEnumerable<TEnum> expectedEnums)
		{
			_rules.Add(new DoesContainRule<TEnum, TResult>(expectedEnums));
			_rules.Add(new DoesNotContainRule<TEnum, TResult>(expectedEnums));
			return this;
		}

		public IEnumTesterRunnable<TEnum, TResult> ExpectedResult(Func<TResult, bool> expectation)
		{
			foreach (var rule in _rules.OfType<IRunRuleExpectation<TEnum, TResult>>())
				rule.WithExpectation(expectation);

			return this;
		}

		public IEnumTesterResult Run(Func<TEnum, TResult> method)
		{
			var result = new EnumTesterResult();
			foreach (var rule in _rules)
				result.Combine(rule.Run(method));

			return result;
		}

		public static IEnumTesterEnum<TEnum, TResult> Setup() => new EnumTester<TEnum, TResult>();
	}
}