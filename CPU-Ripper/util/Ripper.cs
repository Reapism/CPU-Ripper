using CPU_Ripper.exception;
using CPU_Ripper.window;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
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
        /// Runs <see cref="Ripper.SingleThread"/> but on a different
        /// thread.<para>Useful when there is a large number of
        /// iterations per test which could take a long time for the <see cref="Ripper"/>
        /// to complete.</para>
        /// </summary>
        /// <exception cref="ObjectDisposedException">Exception generated from <see cref="Task.Start()"/></exception>
        /// <exception cref="InvalidOperationException">Exception generated from <see cref="Task.Start()"/></exception>

        public RipperTestResults ThreadedSingle() {
            return null;
        }

        /// <summary>
        /// Performs a multithreaded test on the CPU.
        /// <para>Returns a <see cref="RipperTestResults"/> that contains
        /// the results of the tests.</para>
        /// </summary>
        /// <returns>A <see cref="RipperTestResults"/> containing the results.</returns>
        /// <exception cref="RipperThreadException"></exception>

        public RipperTestResults MultiThread() {
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Dispatcher.CurrentDispatcher.Invoke(() => w.txtStats.AppendText(new Specs().ToString()));

            //throw new RipperThreadException("void MultiThread() threw an exception!");

            return null;
        }

        /// <summary>
        /// <para>[Naive test]</para>
        /// Performs a single threaded test on the CPU.
        /// </summary>

        public RipperTestResults SingleThread() {
            var results = new RipperTestResults();

            Action allTests = GetTests();
            MessageBox.Show(allTests.Method.ToString());

            // Initalize all the objects.

            

                for (int j = 0; j< this.rs.AverageIterations; j++) {
                    TimeSpan avgSucc = new TimeSpan();
                    avgSucc = avgSucc.Add(RunSuccessorship());
                }

                for (int j = 0; j < this.rs.AverageIterations; j++) {
                    TimeSpan avgBool = new TimeSpan();
                    avgBool = avgBool.Add(RunBoolean());
                }

                for (int j = 0; j < this.rs.AverageIterations; j++) {
                    TimeSpan avgQ = new TimeSpan();
                    avgQ = avgQ.Add(RunQueue());
                }

                for (int j = 0; j < this.rs.AverageIterations; j++) {
                    TimeSpan avgLL = new TimeSpan();
                    avgLL = avgLL.Add(RunLinkedList());
                }

                for (int j = 0; j < this.rs.AverageIterations; j++) {
                    TimeSpan avgT = new TimeSpan();
                    avgT = avgT.Add(RunTree());
                }

                // best way to do this is with a delegate.
                // need to figure out passing with out parameter
                // in delegate.
            

            return results;
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

        private byte GenerateScore(RipperTestResults ripperTest) {

            // algorithm for generating a score.

            // maybe iterations per second

            // time taken to complete.
            return 50;
        }

    }

}

