using System;
using System.Collections.Generic;
using System.Linq;
using src;

namespace plmeredith13.CodeLou.ExerciseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputtingStudent = true;

            while (inputtingStudent)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                switch (int.Parse(option))
                {
                    case 1:
                        InputStudent();
                        break;
                    case 2:
                        DisplayStudents();

                        break;
                    case 3:
                        SearchStudents();
                        break;
                    case 4:
                        inputtingStudent = false;
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Select from the following operations:");
            Console.WriteLine("1: Enter new student");
            Console.WriteLine("2: List all students");
            Console.WriteLine("3: Search for student by name");
            Console.WriteLine("4: Exit");
        }
        private static void InputStudent()
        {
            Student student = new Student();
            // Continue prompting the user for input until it is valid
            while (true)
            {
                // Prompt user
                Console.WriteLine("Enter Student Id");
                // Try to parse the user input 
                var studentIdSuccessful = int.TryParse(Console.ReadLine(), out var studentId);
                // If the input is valid 
                if (studentIdSuccessful)
                {
                    // Add input to the Student object 
                    student.StudentId = studentId;
                    Console.WriteLine("Enter First Name");
                    student.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name");
                    student.LastName = Console.ReadLine();
                    Console.WriteLine("Enter Class Name");
                    student.ClassName = Console.ReadLine();
                    Console.WriteLine("Enter Last Class Completed");
                    student.LastClassCompleted = Console.ReadLine();
                    Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
                    student.LastClassCompletedOn = DateTimeOffset.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Start Date in format MM/dd/YYYY");
                    student.StartDate = DateTimeOffset.Parse(Console.ReadLine());
                    // Exit the loop
                    break;
                }
            }

            var studentRecord = student;
            studentRecord.StudentId = student.StudentId;
            studentRecord.FirstName = student.FirstName;
            studentRecord.LastName = student.LastName;
            studentRecord.ClassName = student.ClassName;
            studentRecord.StartDate = student.StartDate;
            studentRecord.LastClassCompleted = student.LastClassCompleted;
            studentRecord.LastClassCompletedOn = student.LastClassCompletedOn;
            studentsList.Add(studentRecord);

        }

        static List<Student> studentsList = new List<Student>();
        private static void DisplayStudents() => DisplayStudents(studentsList); // Display all students
        private static void DisplayStudents(List<Student> students) // Display all students in received parameter
        {
            if (students.Any())
            {
                Console.WriteLine($"Student Id | Name |  Class ");
                studentsList.ForEach(x =>
                {
                    Console.WriteLine(x.StudentDisplay);
                });
            }
        }

        private static void SearchStudents()
        {
            Console.WriteLine("Search string:");
            var searchString = Console.ReadLine();
            var students = studentsList.Where(x => x.FullName.Equals(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudents(students);
        }
    }
}