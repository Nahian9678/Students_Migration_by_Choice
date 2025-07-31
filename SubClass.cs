using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Migration
{
    internal class StudentMigrationSubClass
    {
        private List<StudentInfo> students = new List<StudentInfo>();
        private List<CourseInfo> courses = new List<CourseInfo>();

        public StudentMigrationSubClass()
        {
            AddData();
            AssignCourses();
            StudentAssignCourse();
        }

        private void AddData()
        {
            #region Add Student
            students.Add(new StudentInfo { Id = 20251001, Name = "A", TotalMarks = 95, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251002, Name = "B", TotalMarks = 85, PreferredCourse = "EEE" });
            students.Add(new StudentInfo { Id = 20251003, Name = "C", TotalMarks = 75, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251004, Name = "D", TotalMarks = 65, PreferredCourse = "BBA" });
            students.Add(new StudentInfo { Id = 20251005, Name = "E", TotalMarks = 55, PreferredCourse = "ME" });
            students.Add(new StudentInfo { Id = 20251006, Name = "F", TotalMarks = 45, PreferredCourse = "EEE" });
            students.Add(new StudentInfo { Id = 20251007, Name = "G", TotalMarks = 35, PreferredCourse = "SOC" });
            students.Add(new StudentInfo { Id = 20251008, Name = "H", TotalMarks = 25, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251009, Name = "I", TotalMarks = 15, PreferredCourse = "BBA" });
            students.Add(new StudentInfo { Id = 20251010, Name = "J", TotalMarks = 5, PreferredCourse = "SOC" });
            students.Add(new StudentInfo { Id = 20251011, Name = "K", TotalMarks = 90, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251012, Name = "L", TotalMarks = 80, PreferredCourse = "ME" });
            students.Add(new StudentInfo { Id = 20251013, Name = "M", TotalMarks = 70, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251014, Name = "N", TotalMarks = 60, PreferredCourse = "ME" });
            students.Add(new StudentInfo { Id = 20251015, Name = "O", TotalMarks = 50, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251016, Name = "P", TotalMarks = 40, PreferredCourse = "EEE" });
            students.Add(new StudentInfo { Id = 20251017, Name = "Q", TotalMarks = 30, PreferredCourse = "SOC" });
            students.Add(new StudentInfo { Id = 20251018, Name = "R", TotalMarks = 20, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251019, Name = "S", TotalMarks = 10, PreferredCourse = "BBA" });
            students.Add(new StudentInfo { Id = 20251020, Name = "T", TotalMarks = 0, PreferredCourse = "SOC" });
            students.Add(new StudentInfo { Id = 20251021, Name = "U", TotalMarks = 92, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251022, Name = "V", TotalMarks = 82, PreferredCourse = "EEE" });
            students.Add(new StudentInfo { Id = 20251023, Name = "W", TotalMarks = 72, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251024, Name = "X", TotalMarks = 62, PreferredCourse = "BBA" });
            students.Add(new StudentInfo { Id = 20251025, Name = "Y", TotalMarks = 52, PreferredCourse = "CSE" });
            students.Add(new StudentInfo { Id = 20251026, Name = "Z", TotalMarks = 42, PreferredCourse = "EEE" });
            #endregion

            #region Add Course
            courses.Add(new CourseInfo { Name = "CSE", Seats = 5 });
            courses.Add(new CourseInfo { Name = "EEE", Seats = 4 });
            courses.Add(new CourseInfo { Name = "BBA", Seats = 3 });
            courses.Add(new CourseInfo { Name = "SOC", Seats = 2 });
            #endregion
        }

        public void AssignCourses()
        {
            var sortedStudents = students.OrderByDescending(s => s.TotalMarks);

            foreach (var student in sortedStudents)
            {
                try
                {
                    if (!string.IsNullOrEmpty(student.PreferredCourse))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        AssignCourse(student, student.PreferredCourse);
                        //Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        student.AssignedCourse = "No Preference Given";
                        //Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error assigning course for student {student.Name}: {ex.Message}");
                    student.AssignedCourse = "Error";
                }
                Console.ResetColor();
            }
        }

        public void AssignCourse(StudentInfo student, string courseName)
        {
            var course = courses.FirstOrDefault(c => c.Name == courseName && c.Seats > 0);
            if (course != null)
            {

                student.AssignedCourse = course.Name;
                course.Seats--;
            }
            else
            {
                student.AssignedCourse = "Not Assigned (No Seats)";
            }
        }

        public void StudentAssignCourse()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t\t\tCourse Assigned List:");
            Console.WriteLine("\tID\t\tName\t\tTotal Marks\tPreferredCourse Assigned Course");
            Console.ResetColor();
            Console.WriteLine("     --------------------------------------------------------------");

            foreach (var student in students.OrderByDescending(s => s.TotalMarks))
            {
                Console.WriteLine($"\t{student.Id}\t{student.Name}\t\t{student.TotalMarks}\t\t{student.PreferredCourse} \t\t{student.AssignedCourse}");
            }
        }
    }
}
