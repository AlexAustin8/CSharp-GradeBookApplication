using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            double[] averages;
            int res;
            if (Students.Count() < 5)
            {
                throw new InvalidOperationExeception();
            }

            averages = new double[Students.Count()];

            for (int i = 0; i < Students.Count(); i++)
            {
                averages[i] = Students[i].AverageGrade;
            }

            Array.Sort(averages);
            int pos = 0;
            
            foreach(double d in Students)
            {

                if(averageGrade < d)
                {
                    break;
                }
                pos++;
            }
            res = Students.Count() / pos;
            if(res >= 80)
            {
                return 'A';
            }else if(res >= 60)
            {
                return 'B';
            }
            else if (res >= 40)
            {
                return 'C';
            }
            else if (res >= 20)
            {
                return 'D';
            }

            return 'F';
        }
    }

   /* static void Main()
    {
        Student s1 = new Student("Jim", Enums.StudentType.DualEnrolled, Enums.EnrollmentType.International);
        Student s2 = new Student("Bob", Enums.StudentType.Honors, Enums.EnrollmentType.Campus);
        Student s3 = new Student("dim", Enums.StudentType.DualEnrolled, Enums.EnrollmentType.International);
        Student s4 = new Student("pob", Enums.StudentType.Honors, Enums.EnrollmentType.Campus);
        Student s5 = new Student("pob", Enums.StudentType.Honors, Enums.EnrollmentType.Campus);

        s1.AddGrade(90);
        s2.AddGrade(75);
        s3.AddGrade(55);
        s4.AddGrade(35);
        s5.AddGrade(15);

        RankedGradeBook g = new RankedGradeBook("Grade");
        g.AddStudent(s1);
        g.AddStudent(s2);
        g.AddStudent(s3);
        g.AddStudent(s4);
        g.AddStudent(s5);

        Console.WriteLine(g.GetLetterGrade(95.0));



    } */
}
