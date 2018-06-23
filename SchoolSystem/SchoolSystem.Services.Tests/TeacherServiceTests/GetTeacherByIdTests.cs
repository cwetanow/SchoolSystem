using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Services.Tests.TeacherServiceTests
{
	[TestFixture]
	public class GetTeacherByIdTests
	{
		[TestCase(1)]
		public void TestGetTeacherById_ShouldCallRepositoryGetById(int id)
		{
			// Arrange
			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian)
			{
				Id = id
			};

			var mockedRepository = new Mock<IRepository<Teacher>>();
			mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
				.Returns(teacher);


			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.GetTeacherById(id);

			// Assert
			mockedRepository.Verify(r => r.GetById(id), Times.Once);
		}

		[TestCase(1)]
		public void TestGetTeacherById_NoTeacher_ShouldThrowArgumentException(int id)
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Teacher>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act, Assert
			Assert.Throws<ArgumentException>(() => service.GetTeacherById(id));
		}

		[TestCase(1)]
		public void TestGetTeacherById_ShouldReturnCorrectly(int id)
		{
			// Arrange
			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian)
			{
				Id = id
			};

			var mockedRepository = new Mock<IRepository<Teacher>>();
			mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
				.Returns(teacher);

			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			var result = service.GetTeacherById(id);

			// Assert
			Assert.AreSame(teacher, result);
		}
	}
}
