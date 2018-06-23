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
