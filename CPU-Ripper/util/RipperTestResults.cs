using System;
using System.Collections.Generic;

namespace CPU_Ripper.util {

    /// <summary>
    /// Represents the results of a particular
    /// <see cref="Ripper"/> test instance.  
    /// </summary>

    public class RipperTestResults {

        #region Instance members and properties.

        /// <summary>
        /// Represents a dictionary containing the name of the test,
        /// and the average time it took the test.
        /// </summary>
        public Dictionary<string, TimeSpan> AveragePerTest { get; }

        /// <summary>
        /// Represents the score for 
        /// </summary>
        public byte Score { get => GenerateScore(); }

        /// <summary>
        /// Represents the description for this particular test.
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructors and methods.

        /// <summary>
        /// Default constructor for <see cref="RipperTestResults"/>.
        /// </summary>

        public RipperTestResults() {
            AveragePerTest = new Dictionary<string, TimeSpan>();
        }

        /// <summary>
        /// Gets the total time of all the average
        /// tests.
        /// </summary>
        /// <returns></returns>

        public TimeSpan GetTotalTime() {
            TimeSpan totalTime = new TimeSpan();

            foreach (TimeSpan t in AveragePerTest.Values) {
                totalTime = totalTime.Add(t);
            }

            return totalTime;
        }

        public byte GenerateScore() {

            // algorithm for generating a score.

            // maybe iterations per second

            // time taken to complete.
            return 50;
        }

        /// <summary>
        /// Returns a string representation of what
        /// the <see cref="Score"/> number represents.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">The score must be between 0-100 inc.</exception>

        private string GetScoreAsString() {
            switch (Score) {
                case byte b when (Score >= 0 && Score <= 35): { // new in C#7, range based case block.
                    return "LOW";          
                }

                case byte b when (Score >= 36 && Score <= 44): {
                    return "BELOW AVERAGE";
                }

                case byte b when (Score >= 45 && Score <= 55): {
                    return "AVERAGE";
                }

                case byte b when (Score >= 56 && Score <= 67): {
                    return "ABOVE AVERAGE";
                }

                case byte b when (Score >= 68 && Score <= 84): {
                    return "EXCELLENT";
                }

                case byte b when (Score >= 85 && Score <= 100): { 
                    return "SUPER BEAST";
                }

                default: {
                    throw new InvalidOperationException("Score must be between 0-100");
                }
            }
        }

        /// <summary>
        /// Generates a description contingent on the <see cref="Score"/> property,
        /// the <see cref="AveragePerTest"/>, and comparing this to the base.
        /// </summary>
        /// <returns></returns>
        
        public string GenerateDescription() {
            string desc = $"The score is {GenerateScore()} which is " +
                $"{GetScoreAsString().ToLower()}. It took {GetTotalTime()} long for all " +
                $"the tests to finish executing.";

            return desc;
        }
        #endregion

    }
}
