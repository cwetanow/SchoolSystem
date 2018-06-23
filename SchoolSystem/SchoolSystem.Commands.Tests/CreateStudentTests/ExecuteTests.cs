using Moq;
using NUnit.Framework;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using SchoolSystem.Factories;
using SchoolSystem.Services.Contracts;

namespace SchoolSystem.Commands.Tests.CreateStudentTests
{
	[TestFixture]
	class ExecuteTests
	{
		[Test]
		public void TestExecute_PassValidParameters_ShouldCallFactoryCreateStudentCorrectly()
		{
			var parameters = new string[] { "Pesho", " Peshev", "11" };
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mockedFactory = new Mock<IStudentFactory>();
			mockedFactory.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()))
				.Returns(student);

			var mockedService = new Mock<IStudentService>();
			mockedService.Setup(s => s.AddStudent(It.IsAny<Student>())).Returns(1);

			var command = new CreateStudentCommand(mockedFactory.Object, mockedService.Object);

			command.Execute(parameters);

			mockedFactory.Verify(x => x.CreateStudent(parameters[0], parameters[1], (Grade)int.Parse(parameters[2])),
				Times.Once);
		}

		[Test]
		public void TestExecute_PassValidParameters_ShouldCallServiceAddStudentCorrectly()
		{
			var parameters = new string[] { "Pesho", " Peshev", "11" };

			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mockedFactory = new Mock<IStudentFactory>();
			mockedFactory.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()))
				.Returns(student);

			var mockedService = new Mock<IStudentService>();
			mockedService.Setup(s => s.AddStudent(It.IsAny<Student>())).Returns(1);

			var command = new CreateStudentCommand(mockedFactory.Object, mockedService.Object);

			command.Execute(parameters);

			mockedService.Verify(x => x.AddStudent(student),
				Times.Once);
		}
	}
}
