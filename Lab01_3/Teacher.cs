using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_3
{
    internal class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher() : base() { }
        public Teacher(string maSo, string hoTen, string address)
            : base(maSo, hoTen)
        {
            Address = address;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập Địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void Show()
        {
            Console.WriteLine($"Mã số: {MaSo}, Họ tên: {HoTen}, Địa chỉ: {Address}");
        }
    }
}
