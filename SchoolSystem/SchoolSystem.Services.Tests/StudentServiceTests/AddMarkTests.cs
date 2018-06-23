using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Services.Tests.StudentServiceTests
{
	[TestFixture]
	public class AddMarkTests
	{
		[Test]
		public void TestAddMark_ShouldCallRepositoryUpdate()
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Student>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			var student = new Student("Foo", "Bar", Grade.Eighth);
			var mark = new Mark(Subject.Bulgarian, 3);

			// Act
			service.AddMark(student, mark);

			// Assert
			mockedRepository.Verify(r => r.Update(student), Times.Once);
		}

		[Test]
		public void TestAddMark_ShouldCallUnitOfWorkCommit()
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Student>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			var student = new Student("Foo", "Bar", Grade.Eighth);
			var mark = new Mark(Subject.Bulgarian, 3);

			// Act
			service.AddMark(student, mark);

			// Assert
			mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
		}
	}
}
