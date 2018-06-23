using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;

namespace SchoolSystem.Data.Tests.UnitOfWorkTests
{
	[TestFixture]
	public class CommitTests
	{
		[Test]
		public void TestCommit_ShouldCallDbContextSaveChanges()
		{
			// Arrange
			var mockedDbContext = new Mock<IDbContext>();

			var unitOfWork = new UnitOfWork(mockedDbContext.Object);

			// Act
			unitOfWork.Commit();

			// Assert
			mockedDbContext.Verify(c => c.SaveChanges(), Times.Once);
		}

		[TestCase(1)]
		[TestCase(723)]
		[TestCase(14)]
		public void TestCommit_ShouldReturnCorrectly(int expectedResult)
		{
			// Arrange
			var mockedDbContext = new Mock<IDbContext>();
			mockedDbContext.Setup(d => d.SaveChanges()).Returns(expectedResult);

			var unitOfWork = new UnitOfWork(mockedDbContext.Object);

			// Act
			var result = unitOfWork.Commit();

			// Assert
			Assert.AreEqual(expectedResult, result);
		}
	}
}
