using System;

namespace QLNH
{
    public class NhanVien
    {
        public string name { get; set; }
        public int intime { get; set; }
        public int overtime { get; set; }


        public NhanVien() { }

        public NhanVien(string name, int intime, int overtime)
        {
            this.name = name;
            this.intime = intime;
            this.overtime = overtime;
        }

        protected virtual double Luong()
        {
            return 0;
        }

        public void xuat()
        {
            Console.WriteLine("{0}\t\t{1}", name, Luong());
        }

    }
    public class NhanVietPartTime : NhanVien
    {

        public int LuongCung = 25000;

        public NhanVietPartTime() { }

        protected override double Luong()
        {
            double tong = 0;
            tong = ((intime + overtime) * LuongCung);
            return tong;
        }
    }

    public class NhanVietPartTimeBonus : NhanVietPartTime
    {

        static private double bonus = 1.1;

        public NhanVietPartTimeBonus() { }

        protected override double Luong()
        {
            double tong = 0;
            tong = ((intime + overtime) * LuongCung) * bonus;
            return tong;
        }

    }

    public class NhanVietFullTime : NhanVien
    {

        public int LuongCung = 65000;
        public int LuongOvertime = 85000;

        public NhanVietFullTime() { }

        protected override double Luong()
        {
            double tong = 0;
            tong = (intime * LuongCung + overtime * LuongOvertime);
            return tong;
        }

    }

    public class NhanVietFullTimeBonus : NhanVietFullTime
    {

        static private double bonus = 1.1;

        public NhanVietFullTimeBonus() { }

        protected override double Luong()
        {
            double tong = 0;
            tong = (intime * LuongCung + overtime * LuongOvertime) * bonus;
            return tong;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[100];
            int[] b = new int[100];
            int[] c = new int[100];
            int[] d = new int[100];


            Console.Write("Nhap so luong nhan vien ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Nhap ten nhan vien ");
                a[i] = Console.ReadLine();
                Console.Write("Nhap cong viec cua nhan vien (part-time an phim 1, full-time an phim 2) ");
                b[i] = int.Parse(Console.ReadLine());
                Console.Write("Nhap so gio trong thoi gian lam viec ");
                c[i] = int.Parse(Console.ReadLine());
                Console.Write("Nhap so gio tang ca ");
                d[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 1; i <= n; i++)
            {
                if (b[i] == 2)
                {
                    if (c[i] + d[i] > 220)
                    {
                        NhanVietFullTimeBonus S = new NhanVietFullTimeBonus();
                        S.name = a[i];
                        S.intime = c[i];
                        S.overtime = d[i];
                        S.xuat();
                    } else
                    {
                        NhanVietFullTime S = new NhanVietFullTime();
                        S.name = a[i];
                        S.intime = c[i];
                        S.overtime = d[i];
                        S.xuat();
                    }
                } else
                {
                    if (c[i] + d[i] > 100)
                    {
                        NhanVietPartTimeBonus S = new NhanVietPartTimeBonus();
                        S.name = a[i];
                        S.intime = c[i];
                        S.overtime = d[i];
                        S.xuat();
                    }
                    else
                    {
                        NhanVietPartTime S = new NhanVietPartTime();
                        S.name = a[i];
                        S.intime = c[i];
                        S.overtime = d[i];
                        S.xuat();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

