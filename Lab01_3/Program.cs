using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_3
{
    class Program
    {
        static List<Student> studentList = new List<Student>();
        static List<Teacher> teacherList = new List<Teacher>();

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                Console.Write("Chọn chức năng (0-9): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddTeacher();
                        break;
                    case "3":
                        DisplayStudents();
                        break;
                    case "4":
                        DisplayTeachers();
                        break;
                    case "5":
                        ShowCounts();
                        break;
                    case "6":
                        DisplayStudentsByFaculty("CNTT");
                        break;
                    case "7":
                        DisplayTeachersByAddress("Quận 9");
                        break;
                    case "8":
                        DisplayTopStudentByFaculty("CNTT");
                        break;
                    case "9":
                        DisplayStudentRankingCount();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1 - Thêm sinh viên");
            Console.WriteLine("2 - Thêm giáo viên");
            Console.WriteLine("3 - Xuất danh sách sinh viên");
            Console.WriteLine("4 - Xuất danh sách giáo viên");
            Console.WriteLine("5 - Số lượng từng danh sách");
            Console.WriteLine("6 - Xuất danh sách sinh viên khoa CNTT");
            Console.WriteLine("7 - Xuất danh sách giáo viên có địa chỉ chứa 'Quận 9'");
            Console.WriteLine("8 - Xuất danh sách sinh viên có điểm trung bình cao nhất khoa CNTT");
            Console.WriteLine("9 - Thống kê số lượng sinh viên theo xếp loại");
            Console.WriteLine("0 - Thoát");
        }

        static void AddStudent()
        {
            Console.WriteLine("=== Thêm sinh viên ===");
            Student s = new Student();
            s.Input();
            studentList.Add(s);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void AddTeacher()
        {
            Console.WriteLine("=== Thêm giáo viên ===");
            Teacher t = new Teacher();
            t.Input();
            teacherList.Add(t);
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        static void DisplayStudents()
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            if (studentList.Count == 0)
            {
                Console.WriteLine("Chưa có sinh viên nào.");
                return;
            }
            foreach (var s in studentList)
                s.Show();
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("=== Danh sách giáo viên ===");
            if (teacherList.Count == 0)
            {
                Console.WriteLine("Chưa có giáo viên nào.");
                return;
            }
            foreach (var t in teacherList)
                t.Show();
        }

        static void ShowCounts()
        {
            Console.WriteLine("=== Số lượng từng danh sách ===");
            Console.WriteLine($"Tổng số sinh viên: {studentList.Count}");
            Console.WriteLine($"Tổng số giáo viên: {teacherList.Count}");
        }

        static void DisplayStudentsByFaculty(string faculty)
        {
            Console.WriteLine($"=== Danh sách sinh viên khoa {faculty} ===");
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (students.Count == 0)
            {
                Console.WriteLine($"Không có sinh viên thuộc khoa {faculty}.");
                return;
            }
            foreach (var s in students)
                s.Show();
        }

        static void DisplayTeachersByAddress(string addressKeyword)
        {
            Console.WriteLine($"=== Danh sách giáo viên có địa chỉ chứa '{addressKeyword}' ===");
            var teachers = teacherList.Where(t => t.Address.IndexOf(addressKeyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (teachers.Count == 0)
            {
                Console.WriteLine($"Không có giáo viên có địa chỉ chứa '{addressKeyword}'.");
                return;
            }
            foreach (var t in teachers)
                t.Show();
        }

        static void DisplayTopStudentByFaculty(string faculty)
        {
            Console.WriteLine($"=== Sinh viên có điểm TB cao nhất thuộc khoa {faculty} ===");
            var studentsInFaculty = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (studentsInFaculty.Count == 0)
            {
                Console.WriteLine($"Không có sinh viên thuộc khoa {faculty}.");
                return;
            }
            float maxScore = studentsInFaculty.Max(s => s.AverageScore);
            var topStudents = studentsInFaculty.Where(s => s.AverageScore == maxScore).ToList();
            foreach (var s in topStudents)
                s.Show();
        }

        static void DisplayStudentRankingCount()
        {
            int xuatSac = 0, gioi = 0, kha = 0, trungBinh = 0, yeu = 0, kem = 0;

            foreach (var s in studentList)
            {
                if (s.AverageScore >= 9.0f)
                    xuatSac++;
                else if (s.AverageScore >= 8.0f)
                    gioi++;
                else if (s.AverageScore >= 7.0f)
                    kha++;
                else if (s.AverageScore >= 5.0f)
                    trungBinh++;
                else if (s.AverageScore >= 4.0f)
                    yeu++;
                else
                    kem++;
            }

            Console.WriteLine("=== Thống kê xếp loại sinh viên ===");
            Console.WriteLine($"Xuất sắc (9.0 - 10.0): {xuatSac}");
            Console.WriteLine($"Giỏi (8.0 - <9.0): {gioi}");
            Console.WriteLine($"Khá (7.0 - <8.0): {kha}");
            Console.WriteLine($"Trung bình (5.0 - <7.0): {trungBinh}");
            Console.WriteLine($"Yếu (4.0 - <5.0): {yeu}");
            Console.WriteLine($"Kém (<4.0): {kem}");
        }
    }
}
