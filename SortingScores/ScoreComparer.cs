using System;
using System.Collections;

namespace SortingScores {
    public class ScoreComparer : IComparer {
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
