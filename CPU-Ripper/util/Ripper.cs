using CPU_Ripper.exception;
using CPU_Ripper.window;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;

namespace CPU_Ripper.util {

    /// <summary>
    /// The <seealso cref="Ripper"/> class.
    /// 
    /// All internal and external functions that performs
    /// the tests.
    /// 
    /// <para>Author: Reapism / Anthony Jaghab (c), all rights reserved.</para>
    /// </summary>

    public partial class Ripper {

        private RipperSettings rs;

        /// <summary>
        /// Default constructor <see cref="Ripper"/>.
        /// </summary>
        /// <param name="rs">A <see cref="RipperSettings"/> instance
        /// to extract the iterations from.</param>

        public Ripper(ref RipperSettings rs) {
            this.rs = rs;
        }

        /// <summary>
        /// <para>[Recommended test]</para>
        /// Performs a multithreaded test on the CPU.
        /// </summary>
        /// <exception cref="RipperThreadException"></exception>


        public void MultiThread() {
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Dispatcher.CurrentDispatcher.Invoke(() => w.txtStats.AppendText(new Specs().ToString()));

            //throw new RipperThreadException("void MultiThread() threw an exception!");
        }

        /// <summary>
        /// <para>[Naive test]</para>
        /// Performs a single threaded test on the CPU.
        /// </summary>
        /// <exception cref="RipperThreadException"></exception>

        public void SingleThread() {
            
            TimeSpan[,] durations = new TimeSpan[this.rs.AverageIterations, this.rs.NumberOfTests];
            Stopwatch[,] times = new Stopwatch[this.rs.AverageIterations, this.rs.NumberOfTests];

            Action allTests = GetTests();
            MessageBox.Show(allTests.Method.ToString());

            for (byte i = 0; i < this.rs.AverageIterations; i++) {
                for (byte j = 0; j < this.rs.NumberOfTests; j++) {
                    durations[i, j] = new TimeSpan();
                    times[i, j] = new Stopwatch();

                    allTests.Invoke();
                }
            }

            for (byte i = 0; i < this.rs.AverageIterations; i++) {
                int testIndex = this.rs.NumberOfTests - 1;

                
                // best way to do this is with a delegate.
                // need to figure out passing with out parameter
                // in delegate.
            }


        }

        /// <summary>
        /// Gets all the test methods and returns an action that holds
        /// all them.
        /// </summary>
        /// <returns>An action containing all the methods to run.</returns>

        private Action GetTests() {
            Action a = new Action(RunSuccessorship);

            a += RunBoolean;
            a += RunQueue;
            a += RunLinkedList;
            a += RunTree;

            return a;
        }

    }

}

