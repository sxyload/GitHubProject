using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GitHubProject.DataAdapter;

namespace GitHubProject.FileModel
{
    public class CSVFileAnalyzer : BaseFileAnalyzer,IDisposable
    {
        StreamReader SR;
        ISplit SplitTool;

        public CSVFileAnalyzer(string file, ISplit splitTool)
        {
            SR = new StreamReader(new FileStream(file, FileMode.Open));
            SplitTool = splitTool;
        }

        public CSVFileAnalyzer(string file, string[] tokens)
        {
            SR = new StreamReader(new FileStream(file, FileMode.Open));
            SplitTool = new SimpleSplit(tokens);
        }

        public CSVFileAnalyzer(string file, string token)
        {
            SR = new StreamReader(new FileStream(file, FileMode.Open));
            SplitTool = new SimpleSplit(token);
        }

        public CSVFileAnalyzer(string file)
        {
            SR = new StreamReader(new FileStream(file, FileMode.Open));
            SplitTool = new SimpleSplit(Symbols.Dot);
        }

        public override void Dispose()
        {
            SR.Dispose();
        }

        public override string[] GetMetedata()
        {
            //first line should be analyzied to pick header
            if (SR.Peek() < 0) throw new Exception("Config File Is Null");

            string headerLine = SR.ReadLine();

            string[] metedata = (string[])(SplitTool.SplitObject(headerLine));

            HashSet<string> headerSet = new HashSet<string>();

            foreach (string header in metedata)
            {
                if (headerSet.Contains(header)) throw new Exception("header conflict");

                headerSet.Add(header);
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
                return (string[])SplitTool.SplitObject(SR.ReadLine());
            }
            return null;
        }
    }
}
