using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//ゼロから始める


namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console a = new Console();
            ulong b = a.HanoiTower(64);
            System.Console.WriteLine(b);

            System.Console.WriteLine(Count.GetCylinderVolume(4.0, 7.0));

            Count count = new Count(1,"abc");
            int c = count.Add(1, 2);

            Person d = new Person();
            System.Console.WriteLine(d.ID);
            System.Console.WriteLine(d.Name);
            System.Console.WriteLine(d.age);

            int e = 100;
            int f = e++;
            System.Console.WriteLine(e);     //x++先赋值（运算）再自加 //x--相同
            System.Console.WriteLine(f);

            int g = 100;
            int h = ++g;
            System.Console.WriteLine(g);     //++x先自加再赋值（运算） //--x相同
            System.Console.WriteLine(h);

            var x = 100D;                   //隐式定义，赋值后类型不可更改
            System.Console.WriteLine(x.GetType().Name);

            var person = new { Name = "233", Age = 14 };//匿名类型创建对象
            System.Console.WriteLine(person.Name);
            System.Console.WriteLine(person.Age);
            System.Console.WriteLine(person.GetType().Name);


            Form myForm = new Form() { Text = "Hello" };   //{}为初始化器

            int? i = null;
            i = 100;
            int j = i ?? 2;   // null合并

            int k = 80;
            string str = (k >= 60) ? "pass" : "failed"; //  ?: 条件操作符，与if相同
            System.Console.WriteLine(str);

            int l = 10;
            System.Console.WriteLine(++l);
            System.Console.WriteLine(l++);
            System.Console.WriteLine(l);
            System.Console.WriteLine(l.GetType().FullName);   //查看数据类型

            string input = System.Console.ReadLine(); // 接受输入


            int score = 0;
            int sum = 0;
            do
            {
                System.Console.WriteLine("Enter Number1:");
                string str1 = System.Console.ReadLine();
                if (str1.ToLower() == "end")
                {
                    break;
                }
                int num1 = 0;
                try                                     //try语句
                {
                    num1 = int.Parse(str1);         //类型转换
                }
                catch
                {
                    System.Console.WriteLine("Number 1 is error,Restart");
                    continue;
                }
                System.Console.WriteLine("Enter Number2:");
                string str2 = System.Console.ReadLine();
                if (str2.ToLower() == "end")
                {
                    break;
                }
                int num2 = 0;
                try
                {
                    num2 = int.Parse(str2);
                }
                catch
                {
                    System.Console.WriteLine("Number 2 is error,Restart");
                    continue;

                }

                sum = num1 + num2;
                if (sum == 100)
                {
                    score++;
                    System.Console.WriteLine("Corroct! {0}+{1}={}", num1, num2, sum);
                }
                else
                {
                    System.Console.WriteLine("False");
                }
            } while (sum == 100);




            for (int A = 1; A <= 9; A++)
            {
                for (int B = 1; B <= A; B++)
                {
                    System.Console.WriteLine("{0}+{1}={2}\t", A, B, A * B);
                }

                System.Console.WriteLine();
            }

            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var current in intArray)        //循环遍历每一个成员
            {
                System.Console.WriteLine(current);
            }



        }
    }

    class Console
    {
        public int Add(int x)
        {
            int result = 0;
            for (int i = 0; i < x + 1; i++)   //循环
            {
                result = result + i;
            }
            return result;
        }

        public int Sum(int x)
        {
            if (x == 1)
            {
                return 1;
            }
            else
            {
                return x + Sum(x - 1);
            }
        }

        public ulong HanoiTower(int x)   //递归
        {
            if (x == 1)
            {
                return 1;
            }
            else
            {
                return 2 * HanoiTower(x - 1) + 1;

            }
        }
    }

    class Count
    {
        public static double GetCircleArea(double r)
        {
            return Math.PI * r * r;
        }

        public static double GetCylinderVolume(double r, double h)   //复用
        {
            return GetCircleArea(r) * h;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)       //重载
        {
            return a + b;
        }

        public int ID;
        public string Name;

        public Count(int a, string b)   //构造器
        {
            this.ID = a;
            this.Name = b;
        }
    }

    class Person
    {
        public int ID;
        public string Name;
        public int age;



        public Person()     //构造器
        {
            this.ID = 2;
            this.Name = "ABC";
            this.age = 10;
        }
    }

    class Student
    {
        private int age;
        // propfull
        public int Age                   //实例属性
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value >= 0 && value <= 120)
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Age value has error.");
                }
            }
        }


        private static int amount;    //静态字段

        private static int Amount    //静态属性
        {
            get { return amount; }
            set
            {
                if (value >= 0)
                {
                    Student.amount = value;
                }
                else
                {
                    throw new Exception("Amount must greater than 0");
                }
            }
        }

        static void IWantSideEffect(ref int x)   //值类型引用参数，不创建副本，与实参指向同一个地址，ref修饰符显式指出改变实际参数的值
                                                 //用于需要修改实际参数值的场景
        {
            x = x + 100;
        }

        static int CalculateSum(params int[] intArray)  //数组参数 
        {
            int sum = 0;
            foreach (var item in intArray)
            {
                sum += item;
            }
            return sum;

        }


        public static bool TryParse(string input, out double result)   //输出参数，用out修饰符。用于除返回值外还需要输出的场景
        {
            try
            {
                result = double.Parse(input);
                return true;
            }
            catch
            {
                result = 0;
                return false;

            }
        }

    }




}
