using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Hiển thị danh sách sinh viên khoa CNTT");
                Console.WriteLine("4. Hiển thị danh sách sinh viên có điểm TB >= 5");
                Console.WriteLine("5. Sắp xếp sinh viên theo điểm TB tăng dần");
                Console.WriteLine("6. Hiển thị danh sách sinh viên khoa CNTT có điểm TB >= 5");
                Console.WriteLine("7. Hiển thị danh sách sinh viên khoa CNTT có điểm TB cao nhất");
                Console.WriteLine("8. Thống kê số lượng sinh viên theo xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);

                        break;
                    case "2":
                        DisplayStudentList(studentList);

                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        DisplayStudentCountByRanking(studentList);
                        break;
                }
                Console.WriteLine();
            }
         
        }
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách chi tiết thông tin sinh viên ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }
        //case 3- DS Sinh viên khoa CNTT
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0}", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty,
            StringComparison.OrdinalIgnoreCase));
            DisplayStudentList(studentList);
        }
        //case 4: Xuất ra thông tin sinh viên có điểm TB lớn hơn bằng 5.
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList,
        float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0}", minDTB);
            var students = studentList.Where(s => s.AverageScore >= minDTB);
            DisplayStudentList(studentList);
        }
        //case 5: Xuất ra danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần === ");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudentList(sortedStudents);
        }
        //case 6: DS sinh vien co DTB >=5 va thuoc khoa CNTT
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList,
        string faculty, float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} và thuộc khoa {1}", minDTB, faculty);
        var students = studentList.Where(s => s.AverageScore >= minDTB
        && s.Faculty.Equals(faculty,
        StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }
        // case 7: Xuất ra danh sách sinh viên có điểm TB cao nhất thuộc khoa CNTT
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0} có điểm TB cao nhất ===", faculty);
            var studentsInFaculty = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

            if (studentsInFaculty.Any())
            {
                float maxAverageScore = studentsInFaculty.Max(s => s.AverageScore);
                var topStudents = studentsInFaculty.Where(s => s.AverageScore == maxAverageScore).ToList();

                foreach (var student in topStudents)
                {
                    student.Show();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa {0}.", faculty);
            }
        }
        static void DisplayStudentCountByRanking(List<Student> studentList)
        {
            int excellent = 0, good = 0, quiteGood = 0, average = 0, weak = 0, bad = 0;

            foreach (var student in studentList)
            {
                if (student.AverageScore >= 9.0)
                {
                    excellent++;
                }
                else if (student.AverageScore >= 8.0)
                {
                    good++;
                }
                else if (student.AverageScore >= 7.0)
                {
                    quiteGood++;
                }
                else if (student.AverageScore >= 5.0)
                {
                    average++;
                }
                else if (student.AverageScore >= 4.0)
                {
                    weak++;
                }
                else
                {
                    bad++;
                }
            }

            Console.WriteLine("=== Thống kê xếp loại sinh viên ===");
            Console.WriteLine("Xuất sắc (Từ 9.0 đến 10.0): " + excellent);
            Console.WriteLine("Giỏi (Từ 8.0 đến dưới 9.0): " + good);
            Console.WriteLine("Khá (Từ 7.0 đến dưới 8.0): " + quiteGood);
            Console.WriteLine("Trung bình (Từ 5.0 đến dưới 7.0): " + average);
            Console.WriteLine("Yếu (Từ 4.0 đến dưới 5.0): " + weak);
            Console.WriteLine("Kém (Dưới 4.0): " + bad);
        }
    }
}
