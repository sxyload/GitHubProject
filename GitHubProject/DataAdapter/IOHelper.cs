using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using GitHubProject.DataModel;
using GitHubProject.DataAdapter;

namespace GitHubProject
{
    
    public class IOHelper
    {
        private static string[] ReadMetedata(string headerLine, ISplit splitHelper)

        {
            string[] content = (string[])(splitHelper.SplitObject(headerLine));

            string[] metedata = new string[content.Length];

            HashSet<string> headerSet = new HashSet<string>();

            for (int index = 0; index < content.Length; index++)
            {
                if (headerSet.Contains(content[index])) throw new Exception("header conflict");
                
                metedata[index] = content[index];
            }
            return metedata;
        }

        public static T[] Test<T>(string file, ISplit splitHelper) 
            where T : IData,new()
        {
            List<T> res = new List<T>();

            using (StreamReader sr = new StreamReader(new FileStream(file, FileMode.Open)))
            {
                //first line should be analyzied to pick header
                if (sr.Peek() < 0) throw new Exception("Config File Is Null");
                
                string line = sr.ReadLine();

                string[] metedata = ReadMetedata(line, splitHelper);
                //read content
                int row = 0;

                Dictionary<string, string> valueList = new Dictionary<string, string>();

                while (sr.Peek() >= 0)
                {
                    valueList.Clear();

                    ++row;

                    line = sr.ReadLine();

                    string[] content = (string[])(splitHelper.SplitObject(line));

                    if (content.Length != metedata.Length) throw new Exception("row"+ row+" don't have enough column");

                    T tu = new T();

                    for (int i = 0; i < content.Length; i++)
                    {
                        //tu.SetProperty(metedata[i], content[i]);
                        valueList[metedata[i]] = content[i];
                    }

                    tu.SetProperty(valueList);

                    res.Add(tu);
                }
            }
            return res.ToArray();
        }

        public static T[] Test<T>(string file, string[] tokens)
            where T : IData, new()
        {
            ISplit splitTool = new SimpleSplit(tokens);
            return Test<T>(file, splitTool);
        }

        public static T[] Test<T>(string file, string token)
            where T : IData, new()
        {
            ISplit splitTool = new SimpleSplit(token);
            return Test<T>(file, splitTool);
        }
    }
}
