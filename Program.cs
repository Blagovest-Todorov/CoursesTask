using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // key -> Courses ; value - > List<string> strudensName
            Dictionary<string, List<string>> studentsByCourses = 
                                 new Dictionary<string, List<string>>();     

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    //ToDo
                    break;
                }

                string[] parts = line.Split(" : ");
                string courseName = parts[0];
                string studentName = parts[1];

                if (studentsByCourses.ContainsKey(courseName))
                {
                    studentsByCourses[courseName].Add(studentName);                    
                }
                else // course not exist, crea it, add students, 
                {
                    studentsByCourses.Add(courseName, new List<string> {studentName});                    
                }
            }            

            Dictionary<string, List<string>> sortedStudentsByCourses = studentsByCourses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedStudentsByCourses)
            {           // Course  ; List<string>
                Console.WriteLine($"{kvp.Key} : {kvp.Value.Count}");

                List<string> sortedStudents = kvp.Value
                    .OrderBy(stud => stud)
                    .ToList();

                foreach (var stud in sortedStudents)
                {
                    Console.WriteLine($"-- {stud}");
                }
                
            }

        }
    }
}
