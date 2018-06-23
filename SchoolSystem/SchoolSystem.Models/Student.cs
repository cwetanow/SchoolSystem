using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchoolSystem.Models.Abstractions;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Models
{
    public class Student : Person
    {
        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<Mark>();
        }

        public Grade Grade { get; set; }

        public IList<Mark> Marks { get; private set; }

        public string ListMarks()
        {
            if (this.Marks.Count == 0)
            {
                return "This student has no marks.";
            }

            var builder = new StringBuilder();
            builder.AppendLine("The student has these marks:");

            var marksAsString = this.Marks
                .Select(m => $"{m.Subject} => {m.Value}")
                .ToList();

            marksAsString.ForEach(m => builder.AppendLine(m));

            return builder.ToString();
        }
    }
}
