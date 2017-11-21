using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Utilities.Rules
{
	internal class DoesContainRule<TEnum, TResult> : BaseRule<TEnum, TResult> where TEnum : IConvertible
	{
		protected override string DefaultMessageFormat { get; } = "{0} is NOT currently supported";
		protected override string DefaultTitleFormat { get; } = "Supported {0}:";
		public DoesContainRule(IEnumerable<TEnum> expectedEnums) => TypePredicate = e => expectedEnums.Contains(e);

		protected override void RunMethod(Func<TEnum, TResult> method)
		{
			foreach (var type in GetTypes().Where(TypePredicate))
			{
				var actual = method.Invoke(type);
				if (!Expectation(actual)) AppendMessage(type);
			}
		}
	}
}