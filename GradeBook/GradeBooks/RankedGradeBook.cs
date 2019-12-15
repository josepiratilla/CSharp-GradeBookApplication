using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Less than 5 students.");
            }
            // Get the position of the grade
            var better = Students.FindAll(s => s.AverageGrade>=averageGrade).Count;
            var rank = (double)better/(double)Students.Count;
            // Act accordingly
            if(rank<=0.2) return 'A';
            if(rank<=0.4) return 'B';
            if(rank<=0.6) return 'C';
            if(rank<=0.8) return 'D';
            
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}