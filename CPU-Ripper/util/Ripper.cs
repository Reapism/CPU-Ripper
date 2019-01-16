using CPU_Ripper.exception;
using CPU_Ripper.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Action a = new Action(PrintTestIterations);

            Dispatcher.CurrentDispatcher.Invoke(a);

            List<Stopwatch> times = new List<Stopwatch>();
            List<TimeSpan> durations = new List<TimeSpan>();

            for (byte i = 0; i < this.rs.AverageIterations; i++) {
                times.Add(new Stopwatch());
                durations.Add(new TimeSpan());
            }

            for (byte i = 0; i < this.rs.AverageIterations; i++) {

                times[i] = Stopwatch.StartNew();

                RunSuccessorship();
                RunBoolean();
                RunQueue(); 
                RunLinkedList();
                RunTree();       
            }
        }

        /// <summary>
        /// Prints the specs of the current machine and the number
        /// of iterations for each test performed.
        /// <para>Attempts to get <see cref="MainWindow"/>.</para>
        /// </summary>

        public void PrintTestIterations() {
            MainWindow w;

            try {
                w = (MainWindow)Application.Current.MainWindow;
            } catch (InvalidOperationException e) {
                MessageBox.Show($"Exception found: Tried to get the main window!\n" +
                    $"{e.ToString()}", e.Message);
                return;
            }
            
            w.txtStats.AppendText(new Specs().ToString());
            w.txtStats.AppendText($"\nSuccessorship Iterations: {this.rs.IterationsSuccessorship}");
            w.txtStats.AppendText($"\nBoolean Iterations: {this.rs.IterationsBoolean}");
            w.txtStats.AppendText($"\nQueue Iterations: {this.rs.IterationsQueue}");
            w.txtStats.AppendText($"\nLinked List Iterations: {this.rs.IterationsLinkedList}");
            w.txtStats.AppendText($"\nTree Iterations: {this.rs.IterationsTree}");
        }


    }

}

