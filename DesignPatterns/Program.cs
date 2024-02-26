// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns
{
    public class Journal{
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text){
            entries.Add($"{++count}: {text}");
            return count;
        }
        public void RemoveEntry(int index){
            entries.RemoveAt(index);
        }
        public override string ToString(){
            return string.Join(Environment.NewLine, entries);
        }
        
    }

    public class Persistence{
        public void SaveToFile(Journal j, string filename, bool overwrite = false){
            if(overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());

        }
    }

    public class Demo{
        static void Main(string[] args){
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"D:\learn\DesignPatterns\DesignPatterns\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}

