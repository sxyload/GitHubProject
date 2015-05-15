using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitHubProject.FileModel
{
    public abstract class BaseFile
    {
        public abstract string[] GetMetedata();

        public abstract string[] Next();

        public abstract bool HasNext();
    }
}
