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
using GitHubProject.FileModel;

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
            Test2();
            Test3();
        }
        private void Test1()
        {
            TestModel1[] res = IOHelper.GetData<TestModel1>("TEST.csv", new SimpleSplit());
            Console.WriteLine(res.Length);
            foreach (TestModel1 t in res)
            {
                Console.WriteLine(t.ID.Value + " " + t.Name.Value);
            }
        }
        private void Test2()
        {
            TestModel1[] res = IOHelper.GetData<TestModel1>("TEST.csv", Symbols.Dot);
            Console.WriteLine(res.Length);
            foreach (TestModel1 t in res)
            {
                Console.WriteLine(t.ID.Value + " " + t.Name.Value);
            }
        }

        private void Test3()
        {
            TestModel1[] res = null;
            using (BaseFileAnalyzer bfa = new CSVFileAnalyzer("TEST.csv", Symbols.Dot))
            {
                res = IOHelper.GetData<TestModel1>(bfa);
            }
            if (res == null) return;
            Console.WriteLine(res.Length);
            foreach (TestModel1 t in res)
            {
                Console.WriteLine(t.ID.Value + " " + t.Name.Value);
            }
        }
    }
}
