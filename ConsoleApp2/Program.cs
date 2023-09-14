using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string address = "C:/Users/rupakal/Documents/SF_module_8";
            Console.WriteLine(GetFolderSize(address));
            Console.ReadKey();
        }
        static long GetFolderSize(string address)
        {
            long size = 0;
            try
            {
                var directory = new DirectoryInfo(address);
                FileInfo[] files = directory.GetFiles();
                string[] directories = Directory.GetDirectories(address);
                foreach (var file in files)
                {
                    size += file.Length;
                    Console.WriteLine(file.Name + " " + file.Length);
                }
                if (directories.Length > 0)
                {
                    foreach (var dr in directories)
                    {
                        size += GetFolderSize(dr);
                    }
                }
                return size;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;

        }
    }
}
