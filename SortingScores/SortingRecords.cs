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
         * 
         * Pre-condition:
         *      args is a list of string
         * Post-condition:
         *      A sorted score list is saved in the same folder of this application.
         */
        static void Main(string[] args) {
            ArrayList scoreList = new ArrayList();

            /* Process only if only one file name is provided by user */
            if (args.Length == 1) {
                String inFile = args[0];

                /* Process only if the specified file exist */
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

        /**
         * Load scores from a user specified file.
         * 
         * Pre-condition:
         *      filename not null
         * Post-condition:
         *      An array list contains all the records inside the file is returned.
         */
        static private ArrayList loadScoresFromFile(string filename) {
            ArrayList scoreList = new ArrayList();
            scoreRecord record;
            string line;
            string[] columns;

            try {
                using (StreamReader sr = new StreamReader(filename)) {
                    /* Read each record line by line and retrieve the information
                     * in scoreRecord data structure.
                     */
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
                    sr.Close();
                }
            } catch (Exception e) {
                Console.WriteLine("There is an error while reading the file.");
                Console.WriteLine(e.Message);
            }

            return scoreList;
        }

        /**
          * Save scores to a new file with the presetted postfix.
          * 
          * Pre-condition:
          *      scoreList not null
          *      filename not null
          * Post-condition:
          *      The sorted list is printed on the console and 
          *      saved to the new file.
          */
        private static void SaveScoresToFile(ArrayList scoreList, string filename) {
            const String POSTFIX = "-graded";
            String[] fileToken = filename.Split('.');
            String newFileName = fileToken[0] + POSTFIX + '.' + fileToken[1];

            using (StreamWriter sw = new StreamWriter(newFileName)) {
                /* Print out and save the result one by one */
                foreach (scoreRecord item in scoreList) {
                    String output = String.Format(
                                                         "{0}, {1}, {2:D}",
                                                         item.firstName,
                                                         item.lastName,
                                                         item.score
                                                       );
                    Console.WriteLine(output);
                    sw.WriteLine(output);
                }
                sw.Close();
            }

            Console.WriteLine("Finished: created " + newFileName);
        }

        /**
         * Alert the user if the parameter is not valid.
         */
        static private void alertErrorArgs() {
            Console.WriteLine("Usage:");
            Console.WriteLine("This application needs one parameter to specific"
                              + " where the input text file is, e.g.");
            Console.WriteLine("SortingScores <filename>");
        }

        /**
         * Alert the user if the specified file not exist.
         */
        static private void alertNoFile() {
            Console.WriteLine("File not found!");
            Console.WriteLine("Program terminated.");
        }
    }
}
