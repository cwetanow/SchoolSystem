using Moq;
using NUnit.Framework;
using SchoolSystem.Services.Contracts;

namespace SchoolSystem.Commands.Tests.RemoveTeacherCommandTests
{
	[TestFixture]
	public class ExecuteTests
	{
		[TestCase(1)]
		[TestCase(12)]
		[TestCase(1123123)]
		public void TestExecute_PassValidId_ShouldCallServiceRemoveTeacherCorrectly(int id)
		{
			// Arrange
			var parameters = new string[] { id.ToString() };

			var mockedService = new Mock<ITeacherService>();

			var command = new RemoveTeacherCommand(mockedService.Object);

			// Act
			command.Execute(parameters);

			// Assert
			mockedService.Verify(s => s.RemoveTeacher(id), Times.Once);
		}
	}
}
