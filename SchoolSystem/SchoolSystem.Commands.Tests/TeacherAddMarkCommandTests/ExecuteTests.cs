using Moq;
using NUnit.Framework;
using SchoolSystem.Factories;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using SchoolSystem.Services.Contracts;

namespace SchoolSystem.Commands.Tests.TeacherAddMarkCommandTests
{
	[TestFixture]
	public class ExecuteTests
	{
		[Test]
		public void TestExecute_PassValidParameters_ShouldCallServiceGetStudentById()
		{
			// Arrange
			var parameters = new string[] { "0", " 0", " 2" };

			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mark = new Mark(Subject.Bulgarian, 3);

			var mockedFactory = new Mock<IMarkFactory>();
			mockedFactory.Setup(f => f.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(mark);

			var mockedStudentService = new Mock<IStudentService>();
			mockedStudentService.Setup(s => s.GetStudentById(It.IsAny<int>())).Returns(student);

			var mockedTeacherService = new Mock<ITeacherService>();
			mockedTeacherService.Setup(s => s.GetTeacherById(It.IsAny<int>())).Returns(teacher);

			var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedStudentService.Object, mockedTeacherService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedStudentService.Verify(s => s.GetStudentById(int.Parse(parameters[1])));
		}

		[Test]
		public void TestExecute_PassValidParameters_ShouldCallServiceGetTeachertById()
		{
			// Arrange
			var parameters = new string[] { "0", " 0", " 2" };

			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mark = new Mark(Subject.Bulgarian, 3);

			var mockedFactory = new Mock<IMarkFactory>();
			mockedFactory.Setup(f => f.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(mark);

			var mockedStudentService = new Mock<IStudentService>();
			mockedStudentService.Setup(s => s.GetStudentById(It.IsAny<int>())).Returns(student);

			var mockedTeacherService = new Mock<ITeacherService>();
			mockedTeacherService.Setup(s => s.GetTeacherById(It.IsAny<int>())).Returns(teacher);

			var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedStudentService.Object, mockedTeacherService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedTeacherService.Verify(s => s.GetTeacherById(int.Parse(parameters[1])));
		}

		[Test]
		public void TestExecute_PassValidParameters_ShouldCallFactoryCreate()
		{
			// Arrange
			var parameters = new string[] { "0", " 0", " 2" };

			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mark = new Mark(Subject.Bulgarian, float.Parse(parameters[2]));

			var mockedFactory = new Mock<IMarkFactory>();
			mockedFactory.Setup(f => f.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(mark);

			var mockedStudentService = new Mock<IStudentService>();
			mockedStudentService.Setup(s => s.GetStudentById(It.IsAny<int>())).Returns(student);

			var mockedTeacherService = new Mock<ITeacherService>();
			mockedTeacherService.Setup(s => s.GetTeacherById(It.IsAny<int>())).Returns(teacher);

			var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedStudentService.Object, mockedTeacherService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedFactory.Verify(s => s.CreateMark(mark.Subject, mark.Value));
		}

		[Test]
		public void TestExecute_PassValidParameters_ShouldCallServiceAddMark()
		{
			// Arrange
			var parameters = new string[] { "0", " 0", " 2" };

			var teacher = new Teacher("Foo", "Bar", Subject.Bulgarian);
			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mark = new Mark(Subject.Bulgarian, 3);

			var mockedFactory = new Mock<IMarkFactory>();
			mockedFactory.Setup(f => f.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(mark);

			var mockedStudentService = new Mock<IStudentService>();
			mockedStudentService.Setup(s => s.GetStudentById(It.IsAny<int>())).Returns(student);

			var mockedTeacherService = new Mock<ITeacherService>();
			mockedTeacherService.Setup(s => s.GetTeacherById(It.IsAny<int>())).Returns(teacher);

			var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedStudentService.Object, mockedTeacherService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedStudentService.Verify(s => s.AddMark(student, mark), Times.Once);
		}
	}
}
