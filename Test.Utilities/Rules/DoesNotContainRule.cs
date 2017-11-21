using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Utilities.Rules
{
	internal class DoesNotContainRule<TEnum, TResult> : BaseRule<TEnum, TResult> where TEnum : IConvertible
	{
		protected override string DefaultMessageFormat { get; } = "{0} is currently supported";
		protected override string DefaultTitleFormat { get; } = "Unsupported {0}:";
		public DoesNotContainRule(IEnumerable<TEnum> expectedEnums) => TypePredicate = e => !expectedEnums.Contains(e);

		protected override void RunMethod(Func<TEnum, TResult> method)
		{
			foreach (var type in GetTypes().Where(TypePredicate))
			{
				var actual = method.Invoke(type);
				if (Expectation(actual)) AppendMessage(type);
			}
		}
	}
}