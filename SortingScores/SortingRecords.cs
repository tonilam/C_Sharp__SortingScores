using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingScores {
    class SortingRecords {
        static void Main(string[] args) {
            if (args.Length == 1) {
                // do something
            } else {
                alertErrorArgs();
            }
        }

        static private void alertErrorArgs() {
            Console.WriteLine("Usage:");
            Console.WriteLine("This application needs one parameter to specific"
                              + " where the input text file is, e.g.");
            Console.WriteLine("SortingScores <filename>");
        }
    }
}
