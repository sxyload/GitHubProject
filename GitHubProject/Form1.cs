using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GitHubProject.DataModel;
using GitHubProject.DataAdapter;

namespace GitHubProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test1();
        }
        private void Test1()
        {
            TestModel1[] res = IOHelper.Test<TestModel1>("TEST.csv", new SimpleSplit());
            Console.WriteLine(res.Length);
            foreach (TestModel1 t in res)
            {
                Console.WriteLine(t.ID.Value + " " + t.Name.Value);
            }
        }
    }
}
