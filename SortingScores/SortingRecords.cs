using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct scoreRecord {
    public String firstName;
    public String lastName;
    public int score;
}

namespace SortingScores {

    /**
     * SortingRecords reads a file that contains a list of names and scores,
     * and saves the sorted version of the list into another file.
     * 
     * Author: Toni Lam
     * Date: 10 April 2017
     */
    class SortingRecords {
        
        static char[] delimiterChars = { ',' };

        /**
         * Main function controls the whole process flow of this application.
         * Pre-condition:
         *      args is a list of string
         * Post-condition:
         *      A sorted score list is saved in the same folder of this application.
         */
        static void Main(string[] args) {
            ArrayList scoreList = new ArrayList();

            if (args.Length == 1) {
                String inFile = args[0];
                if (File.Exists(inFile)) {
                    scoreList = loadScoresFromFile(inFile);
                    scoreList.Sort(new ScoreComparer());
                    SaveScoresToFile(scoreList, inFile);
                } else {
                    alertNoFile();
                }
            } else {
                alertErrorArgs();
            }
        }
        
        static private ArrayList loadScoresFromFile(string filename) {
            ArrayList scoreList = new ArrayList();
            scoreRecord record;
            string line;
            string[] columns;

            try {
                using (StreamReader sr = new StreamReader(filename)) {
                    while ((line = sr.ReadLine()) != null) {
                        columns = line.Split(delimiterChars);
                        record.firstName = columns[0].Trim();
                        record.lastName = columns[1].Trim();
                        if (Int32.TryParse(columns[2], out record.score)) {
                            scoreList.Add(record);
                        } else {
                            Console.WriteLine("Error in parsing this record.");
                        }
                    }
                }
                foreach(scoreRecord item in scoreList) {
                    String output = String.Format(
                                                     "{0}, {1}, {2:D}",
                                                     item.firstName,
                                                     item.lastName,
                                                     item.score
                                                   );
                    Console.WriteLine(output);
                }
            } catch (Exception e) {
                Console.WriteLine("There is an error while reading the file.");
                Console.WriteLine(e.Message);
            }

            return scoreList;
        }

        private static void SaveScoresToFile(ArrayList scoreList, string filename) {
            String[] fileToken = filename.Split('.');
            String newFileName = fileToken[0] + "-graded" + '.' + fileToken[1];

            using (StreamWriter sw = new StreamWriter(newFileName)) {
                foreach (scoreRecord item in scoreList) {
                    String newLine = String.Format(
                                                     "{0}, {1}, {2:D}",
                                                     item.firstName,
                                                     item.lastName,
                                                     item.score
                                                   );
                    sw.WriteLine(newLine);
                }
            }

            Console.WriteLine("Finished: created " + newFileName);
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
