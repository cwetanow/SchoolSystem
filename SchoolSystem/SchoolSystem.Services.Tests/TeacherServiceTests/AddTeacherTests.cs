using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Services.Tests.TeacherServiceTests
{
	[TestFixture]
	public class AddTeacherTests
	{
		[Test]
		public void TestAddTeacher_ShouldCallRepositoryAdd()
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Teacher>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			var Teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);

			// Act
			service.AddTeacher(Teacher);

			// Assert
			mockedRepository.Verify(r => r.Add(Teacher), Times.Once);
		}

		[Test]
		public void TestAddTeacher_ShouldCallUnitOfWorkCommit()
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Teacher>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			var Teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);

			// Act
			service.AddTeacher(Teacher);

			// Assert
			mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
		}

		[TestCase(1)]
		[TestCase(457)]
		[TestCase(11)]
		public void TestAddTeacher_ShouldReturnCorrectly(int id)
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Teacher>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			var Teacher = new Teacher("Foo", "Bar", Subject.Bulgarian)
			{
				Id = id
			};

			// Act
			var result = service.AddTeacher(Teacher);

			// Assert
			Assert.AreEqual(id, result);
		}
	}
}
