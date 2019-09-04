using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compilador
{
    public class FileReader
    {

        public string ReadFile(string path, string file)
        {
            string content = string.Empty;            
            string fullPath = Path.Combine(path,file);
            if (CheckFileExists(fullPath))
            {
                content = File.ReadAllText(fullPath);
            }

            return content;
        }
        public bool CheckFileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
