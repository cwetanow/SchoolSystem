# SchoolSystem [![Build Status](https://travis-ci.org/cwetanow/SchoolSystem.svg?branch=master)](https://travis-ci.org/cwetanow/SchoolSystem)

## Project for the High Quality Code course at FMI

- **Students** have a `first name`, `last name`, `grade` and a collection of `marks`. 
- **Grades** can be between `1` and `12`.
- **Teachers** have a `first name`, `last name` and a `subject` that they teach. They also poses the _mighty power_ to add marks to students. Poor kids...
- **Marks** have a `subject` and a `value` that can be between `2` and `6`.

The program takes as input `commands` as strings. Each command consists of a `name` and a `collection of parameters`.

- **CreateStudent _[FirstName] [LastName] [Grade]_** - Creates a new student with the provided `first name`, `last name` and `grade` and prints out a success message that contains the `full name`, `grade` and the `ID` of the created student.
- **CreateTeacher _[FirstName] [LastName] [SubjectId]_** - Creates a new teacher with the provided `first name`, `last name` and `subject` and prints out a succes message that contains the `full name`, `subject` and the `ID` of the created teacher.
- **RemoveStudent _[StudentId]_** - Removes a student with the provided `ID` and prints out a `success message`.
- **RemoveTeacher _[TeacherId]_** - Removes a teacher with the provided `ID` and prints out a `success message`.
- **StudentListMarks _[StudentId]_** - Lists the marks of a student with the provided `ID` and prints out a list of marks in the format `SUBJECT => MARKVALUE`.
- **TeacherAddMark _[TeacherId] [StudentId] [Mark]_** - The teacher with the provided `ID` adds a mark to the student with the provided `ID` with the provided `value`.

## Project structure

1. SchoolSystem.Data
  
  Here is all the database related classes. Contains db context for entity framework (with an interface for abstraction), IRepository and IUnitOfWork with their implementations. 
  Tests are located int SchoolSystem.Data.Tests
  
2. SchoolSystem.Models
  
  This project contains the application models, which also are a representation of the database structure.
  
3. SchoolSystem.Factories
  
  Contains interfaces for the factories, which create models. Because of Ninject's functionality (Ninject.Extensions.Factory) there are no implementation.
  
4. SchoolSystem.Providers
  
  Interfaces for IReader and IWriter that allow easy switching of input and output streams. Implemented with ConsoleReaderWriterProvider (uses command prompt). Also ICommandParser which parses the input and creates a suitable ICommand implementation. 
  
5. SchoolSystem.Services
  
  Service layer for our application - contains ITeacherService and IStudentService interfaces for abstraction over the operations with different models. Also service implementations are there
  Service unit tests are located in the SchoolSystem.Services.Tests project
  
6. SchoolSystem.Commands
  
  Project contains the abstraction ICommand interface and the ICommandFactory. Also implementations for different commands are contained in this project.
  All command implementations are unit tested in the SchoolSystem.Commands.Tests project
  
7. SchoolSystem.Core
  
  This project contains the IEngine abstraction with the specific Engine implementation for running the application. It gets input from the injected IReader, parses and runs the command, and prints the output to the IWriter
  
8. SchoolSystem.CLI
  
  Console interface for the application. Contains a DbContextFactory for entity framework migrations (only used in development). SchoolSystemModule which is the configuration for our inversion of control container. Program.cs is the main entry point of the application (composition root).
