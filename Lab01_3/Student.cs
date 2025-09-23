using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_3
{
    internal class Student : Person
    {
        public string Faculty { get; set; }
        public float AverageScore { get; set; }

        public Student() : base() { }
        public Student(string maSo, string hoTen, string faculty, float averageScore)
            : base(maSo, hoTen)
        {
            Faculty = faculty;
            AverageScore = averageScore;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();

            float score;
            Console.Write("Nhập Điểm TB: ");
            while (!float.TryParse(Console.ReadLine(), out score) || score < 0 || score > 10)
            {
                Console.Write("Điểm không hợp lệ, vui lòng nhập lại (0-10): ");
            }
            AverageScore = score;
        }

        public override void Show()
        {
            Console.WriteLine($"Mã số: {MaSo}, Họ tên: {HoTen}, Khoa: {Faculty}, Điểm TB: {AverageScore}");
        }
    }
}
