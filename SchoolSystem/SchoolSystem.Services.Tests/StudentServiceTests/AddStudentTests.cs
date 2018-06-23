using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using SchoolSystem.Services.Contracts;

namespace SchoolSystem.Services.Tests.StudentServiceTests
{
	[TestFixture]
	public class AddStudentTests
	{
		[Test]
		public void TestAddStudent_ShouldCallRepositoryAdd()
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Student>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			var student = new Student("Foo", "Bar", Grade.Eighth);

			// Act
			service.AddStudent(student);

			// Assert
			mockedRepository.Verify(r => r.Add(student), Times.Once);
		}

		[Test]
		public void TestAddStudent_ShouldCallUnitOfWorkCommit()
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Student>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			var student = new Student("Foo", "Bar", Grade.Eighth);

			// Act
			service.AddStudent(student);

			// Assert
			mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
		}

		[TestCase(1)]
		[TestCase(457)]
		[TestCase(11)]
		public void TestAddStudent_ShouldReturnCorrectly(int id)
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Student>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			var student = new Student("Foo", "Bar", Grade.Eighth)
			{
				Id = id
			};

			// Act
			var result = service.AddStudent(student);

			// Assert
			Assert.AreEqual(id, result);
		}
	}
}
