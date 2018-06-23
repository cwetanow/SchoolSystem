using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using System.Collections.Generic;
using System.Linq;
using SchoolSystem.Data.Tests.RepositoryTests.Fakes;

namespace SchoolSystem.Data.Tests.RepositoryTests
{
  [TestFixture]
  public class AllTests
  {
    private IQueryable<FakeRepositoryType> GetData()
    {
      return new List<FakeRepositoryType>
            {
               new FakeRepositoryType(),
               new FakeRepositoryType(),
               new FakeRepositoryType()
            }.AsQueryable();
    }

    [Test]
    public void TestAll_ShouldCallDbContextSet()
    {
      // Arrange
      var data = this.GetData();

      var mockedSet = new Mock<DbSet<FakeRepositoryType>>();
      //mockedSet.Setup(m => m.Provider).Returns(data.Provider);
      //mockedSet.Setup(m => m.Expression).Returns(data.Expression);
      //mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
      //mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      var mockedDbContext = new Mock<IDbContext>();
      mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

      var repository = new EfRepository<FakeRepositoryType>(mockedDbContext.Object);

      // Act
      var result = repository.All;

      // Assert
      mockedDbContext.Verify(db => db.DbSet<FakeRepositoryType>(), Times.Once);
    }

    [Test]
    public void TestAll_ShouldReturnCorrectly()
    {
      // Arrange
      var data = this.GetData();

      var mockedSet = new Mock<DbSet<FakeRepositoryType>>();
      //mockedSet.Setup(m => m.Provider).Returns(data.Provider);
      //mockedSet.Setup(m => m.Expression).Returns(data.Expression);
      //mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
      //mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      var mockedDbContext = new Mock<IDbContext>();
      mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

      var repository = new EfRepository<FakeRepositoryType>(mockedDbContext.Object);

      // Act
      var result = repository.All;

      // Assert
      CollectionAssert.AreEqual(mockedSet.Object, result);
    }
  }
}
