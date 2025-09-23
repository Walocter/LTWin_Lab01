using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_3
{
    internal class Person
    {
        protected string maSo;
        protected string hoTen;

        public string MaSo { get => maSo; set => maSo = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }

        public Person() { }
        public Person(string maSo, string hoTen)
        {
            this.maSo = maSo;
            this.hoTen = hoTen;
        }

        public virtual void Input()
        {
            Console.Write("Nhập Mã số: ");
            MaSo = Console.ReadLine();
            Console.Write("Nhập Họ tên: ");
            HoTen = Console.ReadLine();
        }

        public virtual void Show()
        {
            Console.WriteLine($"Mã số: {MaSo}, Họ tên: {HoTen}");
        }
    }
}
