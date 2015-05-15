using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitHubProject.DataModel
{
    public interface IData
    {
        //void SetProperty(string key, string value);

        void SetProperty(Dictionary<string, string> valueList);
    }
}
