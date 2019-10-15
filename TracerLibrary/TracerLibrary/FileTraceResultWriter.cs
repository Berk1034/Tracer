using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TracerLibrary
{
    public class FileTraceResultWriter : IResultWriter
    {
        public string FileName { get; }
        public FileTraceResultWriter(string Filename)
        {
            this.FileName = Filename;
        }

        public void WriteResult(string result)
        {
            File.WriteAllText(FileName, result);
        }
    }
}
