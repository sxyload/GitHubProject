using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitHubProject.FileModel
{
    public abstract class BaseFileAnalyzer:IDisposable
    {
        public abstract string[] GetMetedata();

        public abstract string[] Next();

        public abstract bool HasNext();

        public virtual void Dispose() { }
    }
}
