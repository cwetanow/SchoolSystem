using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Tests.RepositoryTests.Fakes;

namespace SchoolSystem.Data.Tests.RepositoryTests
{
  [TestFixture]
  public class DeleteTests
  {
    [Test]
    public void TestDelete_ShouldCallDbContextSetDeleted()
    {
      // Arrange
      var mockedDbContext = new Mock<IDbContext>();

      var repository = new EfRepository<FakeRepositoryType>(mockedDbContext.Object);

      var entity = new Mock<FakeRepositoryType>();

      // Act
      repository.Delete(entity.Object);

      // Assert
      mockedDbContext.Verify(c => c.SetDeleted(entity.Object), Times.Once);
    }
  }
}
