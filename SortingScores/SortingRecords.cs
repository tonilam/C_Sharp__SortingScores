using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingScores {
    class SortingRecords {
        static void Main(string[] args) {
            if (args.Length == 1) {
                String inFile = args[0];
                if (File.Exists(inFile)) {
                    Console.WriteLine("File ok to process.");
                } else {
                    alertNoFile();
                }
                alertErrorArgs();
            }
        }

        static private void alertErrorArgs() {
            Console.WriteLine("Usage:");
            Console.WriteLine("This application needs one parameter to specific"
                              + " where the input text file is, e.g.");
            Console.WriteLine("SortingScores <filename>");
        }
        static private void alertNoFile() {
            Console.WriteLine("File not found!");
            Console.WriteLine("Program terminated.");
        }
    }
}
