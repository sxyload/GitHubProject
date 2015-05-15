using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GitHubProject.DataAdapter;

namespace GitHubProject.FileModel
{
    public class CSVFile : BaseFile
    {
        StreamReader SR;
        ISplit SplitHelper;

        public CSVFile(string file, ISplit splitHelper)
        {
            SR = new StreamReader(new FileStream(file, FileMode.Open));
            SplitHelper = splitHelper;
        }

        public override string[] GetMetedata()
        {
            //first line should be analyzied to pick header
            if (SR.Peek() < 0) throw new Exception("Config File Is Null");

            string headerLine = SR.ReadLine();

            string[] content = (string[])(SplitHelper.SplitObject(headerLine));

            string[] metedata = new string[content.Length];

            HashSet<string> headerSet = new HashSet<string>();

            for (int index = 0; index < content.Length; index++)
            {
                if (headerSet.Contains(content[index])) throw new Exception("header conflict");

                metedata[index] = content[index];
            }
            return metedata;
        }

        public override bool HasNext()
        {
            return SR.Peek() > 0;
        }

        public override string[] Next()
        {
            if (HasNext())
            {
                return (string[])SplitHelper.SplitObject(SR.ReadLine());
            }
            return null;
        }
    }
}
