using Moq;
using NUnit.Framework;
using SchoolSystem.Factories;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using SchoolSystem.Services.Contracts;

namespace SchoolSystem.Commands.Tests.CreateTeacherCommandTests
{
	[TestFixture]
	public class ExecuteTests
	{
		[Test]
		public void TestExecute_PassValidParameters_ShouldCallFactoryCreateTeacherCorrectly()
		{
			// Arrange
			var parameters = new string[] { "Pesho", " Peshev", "11" };
			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);

			var mockedFactory = new Mock<ITeacherFactory>();
			mockedFactory.Setup(x => x.CreateTeacher(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Subject>()))
				.Returns(teacher);

			var mockedService = new Mock<ITeacherService>();
			mockedService.Setup(s => s.AddTeacher(It.IsAny<Teacher>())).Returns(1);

			var command = new CreateTeacherCommand(mockedFactory.Object, mockedService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedFactory.Verify(x => x.CreateTeacher(parameters[0], parameters[1], (Subject)int.Parse(parameters[2])), Times.Once);
		}

		[Test]
		public void TestExecute_PassValidParameters_ShouldCallServiceAddTeacherCorrectly()
		{
			// Arrange
			var parameters = new string[] { "Pesho", " Peshev", "11" };

			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);

			var mockedFactory = new Mock<ITeacherFactory>();
			mockedFactory.Setup(x => x.CreateTeacher(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Subject>()))
				.Returns(teacher);

			var mockedService = new Mock<ITeacherService>();
			mockedService.Setup(s => s.AddTeacher(It.IsAny<Teacher>())).Returns(1);

			var command = new CreateTeacherCommand(mockedFactory.Object, mockedService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedService.Verify(x => x.AddTeacher(teacher), Times.Once);
		}
	}
}
