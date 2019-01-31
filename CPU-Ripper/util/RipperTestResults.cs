using System;
using System.Collections.Generic;

namespace CPU_Ripper.util {

    /// <summary>
    /// Represents the results of a particular
    /// <see cref="Ripper"/> test instance.  
    /// </summary>

    public class RipperTestResults {

        #region Instance members and properties.

        private byte numberOfTests;

        /// <summary>
        /// 
        /// </summary>
        public List<TimeSpan> AveragePerTest { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> ListOfTests { get; }

        /// <summary>
        /// 
        /// </summary>
        public byte Score { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructors and methods.

        /// <summary>
        /// Default constructor for <see cref="RipperTestResults"/>.
        /// </summary>

        public RipperTestResults() {
            numberOfTests = Properties.Settings.Default.num_tests;
        }

        /// <summary>
        /// Gets the total time of all the average
        /// tests.
        /// </summary>
        /// <returns></returns>

        public TimeSpan GetTotalTime() {
            TimeSpan totalTime = new TimeSpan();

            foreach (TimeSpan t in AveragePerTest) {
                totalTime = totalTime.Add(t);
            }

            return totalTime;
        }

        #endregion

    }
}
