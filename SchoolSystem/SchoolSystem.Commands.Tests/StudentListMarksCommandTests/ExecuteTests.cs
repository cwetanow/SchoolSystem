using Moq;
using NUnit.Framework;
using SchoolSystem.Models;
using SchoolSystem.Models.Enums;
using SchoolSystem.Services.Contracts;

namespace SchoolSystem.Commands.Tests.StudentListMarksCommandTests
{
	[TestFixture]
	public class ExecuteTests
	{
		[TestCase(1)]
		public void TestExecute_ShouldCallServiceGetStudentById(int id)
		{
			// Arrange
			var parameters = new string[] { id.ToString() };

			var student = new Student("Foo", "Bar", Grade.Eighth);

			var mockedService = new Mock<IStudentService>();
			mockedService.Setup(s => s.GetStudentById(It.IsAny<int>()))
				.Returns(student);

			var command = new StudentListMarksCommand(mockedService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedService.Verify(s => s.GetStudentById(id), Times.Once);
		}
	}
}
