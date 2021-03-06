﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("You need 5 or more students");
            }

            int gradesPercentage = (int)(Math.Round(Students.Count * 0.2));

            List<double> allGrades = Students
                .OrderByDescending(student => student.AverageGrade)
                .Select(student => student.AverageGrade)
                .ToList();

            if(allGrades[gradesPercentage - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (allGrades[(gradesPercentage * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (allGrades[(gradesPercentage * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (allGrades[(gradesPercentage * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
