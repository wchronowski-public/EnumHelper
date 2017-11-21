using System.Collections.Generic;
using Sample.Core.Mocks;
using Test.Utilities;
using Test.Utilities.Rules;
using Xunit;

namespace Sample.Core.Tests
{
	public class SampleClassTest
	{
		//[Fact]
		//public void SampleMethod_WhenSampleEnum_WhenSampleEnum_Verify()
		//{			
		//	var someInterface = new MockSomeInterface();
		//	var expected = new List<SampleEnum> {SampleEnum.Three};
		//	var sampleClass = BuildSampleClass(someInterface);

		//	var result = EnumTester<SampleEnum>
		//		.Setup()
		//		.ExpectedEnums(expected)
		//		.ExpectedResult(() => someInterface.VerifySomeMethodCalled())
		//		.Run((e) => sampleClass.SampleMethod(e, e));

		//	Assert.True(result.Result, result.Message);
		//}

		private static SampleClass BuildSampleClass(ISomeInterface someInterface = null)
		{
			someInterface = someInterface ?? new MockSomeInterface();
			return new SampleClass(someInterface);
		}

		[Fact]
		public void SampleMethod_WhenSampleEnum_Return()
		{
			var expected = new List<SampleEnum> {SampleEnum.Five, SampleEnum.Six};
			var sampleClass = BuildSampleClass();

			var result = EnumTester<SampleEnum, int>
				.Setup()
				.ExpectedEnums(expected)
				.ExpectedResult(r => r == 1)
				.Run(e => sampleClass.SampleMethod(e));

			Assert.True(result.Status == RuleStatus.Valid, result.Message);
		}

		[Fact]
		public void SampleMethod_WhenSampleEnum_WhenValue_Return()
		{
			var expected = new List<SampleEnum> {SampleEnum.One, SampleEnum.Two};
			var sampleClass = BuildSampleClass();

			var result = EnumTester<SampleEnum, int>
				.Setup()
				.ExpectedEnums(expected)
				.ExpectedResult(r => r == 1)
				.Run(e => sampleClass.SampleMethod(e, 1));

			Assert.True(result.Status == RuleStatus.Valid, result.Message);
		}
	}
}