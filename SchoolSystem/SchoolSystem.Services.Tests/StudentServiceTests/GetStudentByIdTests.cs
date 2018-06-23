using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Services.Tests.StudentServiceTests
{
	[TestFixture]
	public class GetStudentByIdTests
	{
		[TestCase(1)]
		public void TestGetStudentById_ShouldCallRepositoryAll(int id)
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Student>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.GetStudentById(id);

			// Assert
			mockedRepository.Verify(r => r.All, Times.Once);
		}

		[TestCase(1)]
		public void TestGetStudentById_ShouldReturnCorrectly(int id)
		{
			// Arrange
			var student = new Student("Foo", "Bar", Grade.Eighth)
			{
				Id = id
			};

			var students = new List<Student>() { student };

			var mockedRepository = new Mock<IRepository<Student>>();
			mockedRepository.Setup(r => r.All)
				.Returns(students.AsQueryable());

			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new StudentService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			var result = service.GetStudentById(id);

			// Assert
			Assert.AreSame(student, result);
		}
	}
}
