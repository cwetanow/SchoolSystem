using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Tests.RepositoryTests.Fakes;

namespace SchoolSystem.Data.Tests.RepositoryTests
{
  [TestFixture]
  public class GetByIdTests
  {
    [TestCase(1)]
    [TestCase(432)]
    public void TestGetById_ShouldCallDbContextSetFind(int id)
    {
      // Arrange
      var mockedSet = new Mock<DbSet<FakeRepositoryType>>();

      var mockedDbContext = new Mock<IDbContext>();
      mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

      var repository = new EfRepository<FakeRepositoryType>(mockedDbContext.Object);

      // Act
      repository.GetById(id);

      // Assert
      mockedSet.Verify(x => x.Find(id), Times.Once);
    }

    [TestCase(1)]
    [TestCase(432)]
    public void TestGetById_ShouldReturnCorrectly(int id)
    {
      // Arrange
      var mockedResult = new Mock<FakeRepositoryType>();

      var mockedSet = new Mock<DbSet<FakeRepositoryType>>();
      mockedSet.Setup(s => s.Find(It.IsAny<object>())).Returns(mockedResult.Object);

      var mockedDbContext = new Mock<IDbContext>();
      mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

      var repository = new EfRepository<FakeRepositoryType>(mockedDbContext.Object);

      // Act
      var result = repository.GetById(id);

      // Assert
      Assert.AreSame(mockedResult.Object, result);
    }
  }
}
