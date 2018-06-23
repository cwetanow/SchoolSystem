using System;

using SchoolSystem.Models.Abstractions;
using SchoolSystem.Models.Contracts;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;

        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, IMark mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            student.Marks.Add(mark);
        }
    }
}
