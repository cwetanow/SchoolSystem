using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Services.Tests.TeacherServiceTests
{
	[TestFixture]
	public class RemoveTeacherTests
	{
		[TestCase(1)]
		public void TestRemoveTeacher_ShouldCallRepositoryGetById(int id)
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Teacher>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.RemoveTeacher(id);

			// Assert
			mockedRepository.Verify(r => r.GetById(id), Times.Once);
		}

		[TestCase(1)]
		public void TestRemoveTeacher_NoTeacherFound_ShouldNotCallRepositoryDelete(int id)
		{
			// Arrange
			var mockedRepository = new Mock<IRepository<Teacher>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.RemoveTeacher(id);

			// Assert
			mockedRepository.Verify(r => r.Delete(It.IsAny<Teacher>()), Times.Never);
		}

		[TestCase(1)]
		public void TestRemoveTeacher_TeacherFound_ShouldCallRepositoryDelete(int id)
		{
			// Arrange
			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);

			var mockedRepository = new Mock<IRepository<Teacher>>();
			mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
				.Returns(teacher);

			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.RemoveTeacher(id);

			// Assert
			mockedRepository.Verify(r => r.Delete(It.IsAny<Teacher>()), Times.Once);
		}

		[TestCase(1)]
		public void TestRemoveTeacher_TeacherFound_ShouldCallUnitOfWorkCommit(int id)
		{
			// Arrange
			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);

			var mockedRepository = new Mock<IRepository<Teacher>>();
			mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
				.Returns(teacher);

			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var service = new TeacherService(mockedRepository.Object, mockedUnitOfWork.Object);

			// Act
			service.RemoveTeacher(id);

			// Assert
			mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
		}
	}
}
