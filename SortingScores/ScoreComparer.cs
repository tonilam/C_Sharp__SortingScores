using System;
using System.Collections;

namespace SortingScores {
    /**
     * ScoreComparer is use to compare which scoreRecord object has a greater score.
     * If the score is the same, then compare the object by name.
     * 
     * Author: Toni Lam
     * Date: 10 April 2017
     */
    public class ScoreComparer : IComparer {

        /**
         * Compare which object has a greater score.
         * If scores are the same, then compare by their last names.
         * If the last names are still the same, then compare by their first names.
         * 
         * Pre-condition:
         *      x not null
         *      y not null
         * Post-condition:
         *      return 1 if x < y
         *      return 0 if x = y
         *      return -1 if x > y
         */
        public int Compare(object x, object y) {
            scoreRecord r1 = (scoreRecord)x;
            scoreRecord r2 = (scoreRecord)y;
            if (r2.score == r1.score) {
                if (r2.lastName == r1.lastName) {
                    if (r2.firstName == r1.firstName) {
                        return 0;
                    } else {
                        return String.Compare(r2.firstName, r1.firstName, StringComparison.OrdinalIgnoreCase);
                    }
                } else {
                    return String.Compare(r2.lastName, r1.lastName, StringComparison.OrdinalIgnoreCase);
                }
            } else {
                return (r2.score > r1.score) ? 1 : -1;
            }
        }
    }
}
