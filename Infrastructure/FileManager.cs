using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.Infrastructure
{
    public class FileManager
    {
        public string FileToString(string file)
        {
            return File.ReadAllText(ApplicationPath + "/" + file);
        }

        public string ApplicationPath
        {
            get { return Directory.GetCurrentDirectory(); }
        }
    }
}
