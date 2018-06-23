using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using System;

namespace SchoolSystem.Services.Tests.StudentServiceTests
{
	[TestFixture]
	public class RemoveStudentTests
	{
		[TestCase(1)]
		public void TestRemoveStudent_ShouldCallRepositoryGetById(int id)
		{
			// Arrange
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mockedRepository = new Mock<IRepository<Student>>();
			mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
				.Returns(student);


			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.RemoveStudent(id);

			// Assert
			mockedRepository.Verify(r => r.GetById(id), Times.Once);
		}

		[TestCase(1)]
		public void TestRemoveStudent_NoStudentFound_ShouldThrowArgumentException(int id)
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Student>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			// Act, Assert
			Assert.Throws<ArgumentException>(() => service.RemoveStudent(id));
		}

		[TestCase(1)]
		public void TestRemoveStudent_StudentFound_ShouldCallRepositoryDelete(int id)
		{
			// Arrange
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mockedRepository = new Mock<IRepository<Student>>();
			mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
				.Returns(student);

			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.RemoveStudent(id);

			// Assert
			mockedRepository.Verify(r => r.Delete(It.IsAny<Student>()), Times.Once);
		}

		[TestCase(1)]
		public void TestRemoveStudent_StudentFound_ShouldCallUnitOfWorkCommit(int id)
		{
			// Arrange
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mockedRepository = new Mock<IRepository<Student>>();
			mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
				.Returns(student);

			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.RemoveStudent(id);

			// Assert
			mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
		}
	}
}
