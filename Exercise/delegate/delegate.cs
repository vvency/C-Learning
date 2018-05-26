using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks; //显示异步调用 

namespace Delegate
{
    public delegate double Calc(double x, double y);  // 声明委托


    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Calc calc1 = new Calc(calculator.Add);        //使用委托间接调用函数
            Calc calc2 = new Calc(calculator.Sub);
            Calc calc3 = new Calc(calculator.Mul);
            Calc calc4 = new Calc(calculator.Div);

            double a = 100;
            double b = 200;
            double c = 0;

            c = calc1.Invoke(a, b);//calc1(a, b);
            Console.WriteLine(c);
            c = calc2.Invoke(a, b);//calc2(a, b);
            Console.WriteLine(c);
            c = calc3.Invoke(a, b);//calc3(a, b);
            Console.WriteLine(c);
            c = calc4.Invoke(a, b);//calc4(a, b);
            Console.WriteLine(c);











            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);  //声明委托
            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.Log); //声明委托

            Box box1 = wrapFactory.WrapProduct(func1,log);  //间接调用
            Box box2 = wrapFactory.WrapProduct(func2,log);
             
            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);









            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Blue };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Yellow };
            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            action1 += action2;
            action1 += action3;
            action1.Invoke();       //多播委托,按照封装顺序执行  //间接同步调用（按顺序执行）

            action1.BeginInvoke(null, null);
            action2.BeginInvoke(null, null);
            action3.BeginInvoke(null, null); //用委托（BeginInvoke）实现隐式异步调动（同步执行）

            Task task1 = new Task(new Action(stu1.DoHomework));
            Task task2 = new Task(new Action(stu2.DoHomework));
            Task task3 = new Task(new Action(stu3.DoHomework));

            task1.Start();
            task2.Start();
            task3.Start();   //Task实现显式异步调用

        }
    }

    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }









    class Logger           //回调委托类
    {
        public void Log(Product product)
        {
            Console.WriteLine("Product '{0}'created at {1},Price is {2}",product .Name,DateTime.UtcNow,product .Price);
        }
    }

    class Product
    {
        public string Name { get; set; } 
        public decimal Price { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }
    }

    class WrapFactory
    {
        public Box WrapProduct(Func<Product> getProduct,Action<Product>logCallback)    //模板方法-接受委托,回调方法
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
            if (product.Price>=50)
            {
                logCallback(product);
            }
            box.Product = product; 
            return box;
                
        }
    }

    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 12;
            return product;
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }

    //可以使用接口取代委托











    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0}doing homework {1}hours.",this.ID, PenColor);
                Thread.Sleep(1000);
            }
        }
    }



}


