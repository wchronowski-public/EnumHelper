using Moq;

namespace Sample.Core.Mocks
{
	public class MockSomeInterface : ISomeInterface
	{
		private readonly Mock<ISomeInterface> _mock = new Mock<ISomeInterface>();

		public void SomeMethod() => _mock.Object.SomeMethod();

		public void VerifySomeMethodCalled(int times = 1) =>
			_mock.Verify(m => m.SomeMethod(), Times.Exactly(times));

		public void VerifySomeMethodNotCalled() =>
			_mock.Verify(m => m.SomeMethod(), Times.Never);
	}
}