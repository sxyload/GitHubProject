using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GitHubProject.DataModel
{
    public class TestModel1 : IData
    {
        private Turple m_ID;
        public Turple ID
        {
            get
            {
                if (m_ID == null)
                {
                    m_ID = new Turple();
                    m_ID.Key = "TESTID";
                }
                return m_ID;
            }
            set { }
        }
        private Turple m_Name;
        public Turple Name
        {
            get
            {
                if (m_Name == null)
                {
                    m_Name = new Turple();
                    m_Name.Key = "TESTNAME";
                }
                return m_Name;
            }
            set { }
        }
        //public void SetProperty(string key, string value)
        //{
        //    string pureKey = key.Replace("\t", "").Replace("\"", "").Trim();
        //    Console.WriteLine(pureKey);
        //    if (pureKey == ID.Key)
        //    {
        //        ID.Value = value;
        //    }
        //    else if (pureKey == Name.Key)
        //    {
        //        Name.Value = value;
        //    }
        //}
        // 用反射的方式赋值
        public void SetProperty(Dictionary<string, string> val)
        {
            System.Reflection.PropertyInfo[] propertyInfos = this.GetType().GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                Turple temp = (p.GetValue(this,null) as Turple);
                //p.SetValue(this,val[temp.Key] ,null);
                temp.Value = val[temp.Key];
            }
        }
    }
}
