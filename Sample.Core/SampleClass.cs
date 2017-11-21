namespace Sample.Core
{
	public class SampleClass
	{
		private readonly ISomeInterface _someInterface;

		public SampleClass(ISomeInterface someInterface) => _someInterface = someInterface;

		public int SampleMethod(SampleEnum sampleEnum) =>
			sampleEnum == SampleEnum.Five || sampleEnum == SampleEnum.Six ? 1 : 0;

		public int SampleMethod(SampleEnum sampleEnum, int value) =>
			sampleEnum == SampleEnum.One || sampleEnum == SampleEnum.Two ? value : 0;

		public void SampleMethod(SampleEnum sampleEnum1, SampleEnum sampleEnum2)
		{
			if (sampleEnum1 == SampleEnum.Seven)
				_someInterface.SomeMethod();
		}
	}
}