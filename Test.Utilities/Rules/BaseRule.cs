using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Utilities.Rules
{
	internal abstract class BaseRule<TEnum, TResult> : IRunRuleExpectation<TEnum, TResult>, IRunRule<TEnum, TResult> where TEnum : IConvertible
	{
		private readonly StringBuilder _errorMessage = new StringBuilder();
		private RuleStatus _status = RuleStatus.Valid;
		protected Func<TEnum, bool> TypePredicate { get; set; }
		protected Func<TResult, bool> Expectation { get; private set; }
		protected abstract string DefaultMessageFormat { get; }
		protected virtual string DefaultTitleFormat { get; } = "{0}:";
		protected string MessageFormat { get; private set; }
		protected string TitleFormat { get; private set; }

		public IRunRule<TEnum, TResult> WithMessageFormat(string messageFormat)
		{
			if (string.IsNullOrWhiteSpace(messageFormat)) messageFormat = DefaultMessageFormat;

			MessageFormat = messageFormat;
			return this;
		}

		public IRunRule<TEnum, TResult> WithTitleFormat(string titleFormat)
		{
			if (string.IsNullOrWhiteSpace(titleFormat)) titleFormat = DefaultTitleFormat;

			TitleFormat = titleFormat;
			return this;
		}

		public IEnumTesterResult Run(Func<TEnum, TResult> method)
		{
			MessageFormat = MessageFormat ?? DefaultMessageFormat;
			TitleFormat = TitleFormat ?? DefaultTitleFormat;
			RunMethod(method);

			return new EnumTesterResult(_status, _errorMessage.ToString());
		}

		public IRunRule<TEnum, TResult> WithExpectation(Func<TResult, bool> expectation)
		{
			Expectation = expectation;
			return this;
		}

		protected abstract void RunMethod(Func<TEnum, TResult> method);

		protected void AppendMessage(TEnum type)
		{
			if (_status == RuleStatus.Valid) _errorMessage.AppendFormat($"{TitleFormat}", typeof(TEnum).Name).AppendLine();
			_status = RuleStatus.Invalid;
			_errorMessage.AppendFormat($"\t{MessageFormat}", type).AppendLine();
		}

		protected IEnumerable<TEnum> GetTypes() =>
			Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
	}
}