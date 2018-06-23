using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Services.Contracts;
using SchoolSystem.Factories;

namespace SchoolSystem.Commands.Tests.CreateStudentTests
{
	[TestFixture]
    class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassNullAsFactory_ShouldThrowArgumentNullException()
        {
            var mockedService = new Mock<IStudentService>();

            Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(null, mockedService.Object));
        }

        [Test]
        public void TestConstructor_PassNullAsService_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<IStudentFactory>();

            Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(mockedFactory.Object, null));
        }
    }
}
