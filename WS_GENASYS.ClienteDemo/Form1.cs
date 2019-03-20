using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WS_GENASYS.ClienteDemo
{
    public partial class Form1 : Form
    {

        List<int> numbers = new List<int>();

        public Form1()
        {
            InitializeComponent();
            //Timer clock = new Timer();
            //clock.Interval = 1000;
            //clock.Tick += new EventHandler(clock_Tick);
            //clock.Start();
           // printRandomValue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printRandomValue();
            
        }

        void clock_Tick(object sender, EventArgs e)
        {
            printRandomValue();
        }

        private void printRandomValue()
        {
            int newint = getRandomValue(99999999);
            numbers.Add(newint);
            this.Text = newint.ToString();
            label1.Text = newint.ToString();
        }

        private int getRandomValue(int MaxValue)
        {
            Random r = new Random();
            int newint = 0;
            newint = r.Next(MaxValue);
            while (numbers.Contains(newint))
            {
                newint = r.Next(MaxValue);
            }
            return newint;
        }


    }
}
