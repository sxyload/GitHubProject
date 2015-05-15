using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitHubProject.DataAdapter
{
    public class SimpleSplit : ISplit
    {
        string[] SplitTokens;
        public SimpleSplit(string[] tokens)
        {
            SplitTokens = tokens;
        }
        public SimpleSplit(string token)
        {
            SplitTokens = new string[] { token };
        }
        public SimpleSplit()
        {
            SplitTokens = new string[] { Symbols.Dot };
        }
        public object[] SplitObject(object obj)
        {
            return (obj as string).Split(SplitTokens, StringSplitOptions.None);
        }

    }
}
