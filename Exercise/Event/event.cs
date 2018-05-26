using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            System.Timers.Timer timer = new System.Timers.Timer(); //事件拥有者
            timer.Interval = 1000;  //1秒
            Boy boy = new Boy(); //事件响应者
            Girl girl = new Girl();
            timer.Elapsed += boy.Action; //订阅事件。Ctrl + . 自动生成方法（事件处理器）
            timer.Elapsed += girl.Action; 
            timer.Start();
            Console.ReadLine();






            //2
            Form form = new Form(); //事件拥有者
            Controller controller = new Controller(form); //事件响应者
            form.ShowDialog(); 






            //3
            MyForm MyForm = new MyForm();    //事件拥有者//事件响应者
            form.Click += MyForm.FormClicked;  //订阅事件
            form.ShowDialog();







            //4
            NewForm Newform = new NewForm();  //事件响应者
            Newform.ShowDialog();
        }
    }
    //1
    class Boy
    {
        internal void Action(object sender, ElapsedEventArgs e)   //事件处理器
        {
            Console.WriteLine("Jump!");
        }
    }
    //1
    class Girl
    {
        internal void Action(object sender, ElapsedEventArgs e)    //事件处理器
        {
            Console.WriteLine("Sing!");
        }
    }







    //2
    class Controller
    {
        private Form form;
        public Controller(Form form)    //构造器 ctor
        {
            if (form!=null)
            {
                this.form = form;
                this.form.Click += this.FormClicked;  //订阅事件
            }
        }

        private void FormClicked(object sender, EventArgs e)  //事件处理器
        {
            this.form.Text = DateTime.Now.ToString();
            
        }
    }







    //3
    class MyForm : Form  //派生，继承
    {
        internal void FormClicked(object sender, EventArgs e)   //事件处理器
        {
            this.Text = DateTime.Now.ToString();
        }
    }






    //4
    class NewForm : Form
    {
        private TextBox textBox;
        private Button button;  //事件拥有者

        public NewForm()
        {
            this.textBox = new TextBox();
            this.button = new Button();
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox);
            this.button.Click += this.ButtonClicked; //订阅事件

            this.button.Text = "Say Hello!";
            this.button.Top = 20;

        }

        private void ButtonClicked(object sender, EventArgs e)  //事件处理器
        {
            this.textBox.Text = "Hello World!";
        }
    }
}
