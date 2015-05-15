using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using GitHubProject.DataModel;
using GitHubProject.DataAdapter;
using GitHubProject.FileModel;

namespace GitHubProject
{
    
    public class IOHelper
    {

        public static T[] GetData<T>(BaseFileAnalyzer fileAnalyzer) 
            where T : IData,new()
        {
            List<T> res = new List<T>();

            string[] metedata = fileAnalyzer.GetMetedata();
            //read content
            int row = 0;

            Dictionary<string, string> valueList = new Dictionary<string, string>();

            while (fileAnalyzer.HasNext())
            {
                valueList.Clear();

                ++row;

                string[] content = fileAnalyzer.Next();

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
            
            return res.ToArray();
        }

        public static T[] GetData<T>(string file, ISplit splitTool)
            where T : IData, new()
        {
            using (BaseFileAnalyzer bfa = new CSVFileAnalyzer(file, splitTool))
            {
                return GetData<T>(bfa);
            }
        }

        public static T[] GetData<T>(string file, string[] tokens)
            where T : IData, new()
        {
            ISplit splitTool = new SimpleSplit(tokens);
            return GetData<T>(file, splitTool);
        }

        public static T[] GetData<T>(string file, string token)
            where T : IData, new()
        {
            ISplit splitTool = new SimpleSplit(token);
            return GetData<T>(file, splitTool);
        }

    }
}
