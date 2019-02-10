using CPU_Ripper.exception;
using CPU_Ripper.window;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CPU_Ripper.util {

    /// <summary>
    /// The <seealso cref="Ripper"/> class.
    /// All internal and external functions that performs
    /// the tests.
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

            // Initalize all the objects.
            TimeSpan avgSucc = new TimeSpan();
            TimeSpan avgBool = new TimeSpan();
            TimeSpan avgQ = new TimeSpan();
            TimeSpan avgLL = new TimeSpan();
            TimeSpan avgT = new TimeSpan();

            for (int j = 0; j < this.rs.AverageIterations; j++) {
                TimeSpan t = RunSuccessorship();
                MainWindow w = (MainWindow)Application.Current.MainWindow;
                Dispatcher.CurrentDispatcher.Invoke(() => w.txtStats.AppendText($"\nSuccessor {j}: {t}"));
                avgSucc = avgSucc.Add(t);
            }

            for (int j = 0; j < this.rs.AverageIterations; j++) {
                TimeSpan t = RunBoolean();
                MainWindow w = (MainWindow)Application.Current.MainWindow;
                Dispatcher.CurrentDispatcher.Invoke(() => w.txtStats.AppendText($"\nBool {j}: {t}"));
                avgBool = avgBool.Add(t);
            }

            for (int j = 0; j < this.rs.AverageIterations; j++) {
                TimeSpan t = RunQueue();
                MainWindow w = (MainWindow)Application.Current.MainWindow;
                Dispatcher.CurrentDispatcher.Invoke(() => w.txtStats.AppendText($"\nQueue {j}: {t}"));
                avgQ = avgQ.Add(t);
            }

            for (int j = 0; j < this.rs.AverageIterations; j++) {
                TimeSpan t = RunLinkedList();
                MainWindow w = (MainWindow)Application.Current.MainWindow;
                Dispatcher.CurrentDispatcher.Invoke(() => w.txtStats.AppendText($"\nLL {j}: {t}"));
                avgLL = avgLL.Add(t);
            }
      
            for (int j = 0; j < this.rs.AverageIterations; j++) {
                TimeSpan t = RunTree();
                MainWindow w = (MainWindow)Application.Current.MainWindow;
                Dispatcher.CurrentDispatcher.Invoke(() => w.txtStats.AppendText($"\nTree {j}: {t}"));
                avgT = avgT.Add(t);
            }

            try {
                avgSucc = AverageTimespan(ref avgSucc, rs.AverageIterations);
                avgBool = AverageTimespan(ref avgBool, rs.AverageIterations);
                avgQ = AverageTimespan(ref avgQ, rs.AverageIterations);
                avgLL = AverageTimespan(ref avgLL, rs.AverageIterations);
                avgT = AverageTimespan(ref avgT, rs.AverageIterations);
            } catch (DivideByZeroException e) {
                MessageBox.Show("Thrown when averaging with a " +
                    "number less than or equal to 0.", "DivideByZeroException");
            }

            results.AveragePerTest.Add("Successorship", avgSucc);
            results.AveragePerTest.Add("Boolean", avgBool);
            results.AveragePerTest.Add("Queue", avgQ);
            results.AveragePerTest.Add("Linked List", avgLL);
            results.AveragePerTest.Add("Tree", avgT);
            
            return results;
        }

        /// <summary>
        /// Averages a particular <see cref="TimeSpan"/> with a number and
        /// returns a new <see cref="TimeSpan"/> with the average.
        /// </summary>
        /// <param name="averageMe">A <see cref="TimeSpan"/> object to average.</param>
        /// <param name="divideBy">The number to divide the <see cref="TimeSpan"/> by.</param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException">Thrown if a number is less than or = to 0.</exception>

        private TimeSpan AverageTimespan(ref TimeSpan averageMe, int divideBy) {
            return (divideBy <= 0) ? throw new DivideByZeroException() :
                new TimeSpan(averageMe.Ticks / divideBy);
        }

    }

}

