using System;

namespace Test.Utilities
{
	public interface IEnumTesterRunnable<out TEnum, in TResult>
	{
		IEnumTesterResult Run(Func<TEnum, TResult> predicate);
	}
}