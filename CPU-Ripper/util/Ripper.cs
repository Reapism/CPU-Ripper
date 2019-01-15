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

    public class Ripper {

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

            TimeSpan dur = new TimeSpan();
            TimeSpan totalDur = new TimeSpan();
            var totalTime = Stopwatch.StartNew();

            RunSuccessorship(out dur);
            Dispatcher.CurrentDispatcher.Invoke(() =>
                w.txtStats.AppendText($"\nSuccessorship: {dur.ToString()}"));
            RunBoolean(out dur);
            Dispatcher.CurrentDispatcher.Invoke(() =>
                w.txtStats.AppendText($"\nBoolean Logic: {dur.ToString()}"));
            RunQueue(out dur);
            Dispatcher.CurrentDispatcher.Invoke(() =>
                w.txtStats.AppendText($"\nQueue: {dur.ToString()}"));
            RunLinkedList(out dur);
            Dispatcher.CurrentDispatcher.Invoke(() =>
                w.txtStats.AppendText($"\nLinkedList: {dur.ToString()}"));
            RunTree(out dur);
            Dispatcher.CurrentDispatcher.Invoke(() =>
                w.txtStats.AppendText($"\nTree (SortedSet): {dur.ToString()}"));

            totalTime.Stop();
            totalDur = totalTime.Elapsed;
            Dispatcher.CurrentDispatcher.Invoke(() =>
            w.txtStats.AppendText($"\nTotal Time: {totalDur.ToString()}"));
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

        /// <summary>
        /// Runs a naive test on successorship.
        /// <para>Counts from 0 to N.</para>
        /// </summary>
        /// <param name="dur">Outputs a <see cref="TimeSpan"/> 
        /// representing how long it takes this operation.</param>

        private void RunSuccessorship(out TimeSpan dur) {
            var sw = Stopwatch.StartNew();
            for (ulong i = 0; i < this.rs.IterationsSuccessorship; i++) { }
            sw.Stop();
            dur = sw.Elapsed;
        }

        /// <summary>
        /// Runs a naive test on boolean logic.
        /// <para>Internally, generates 2 random integers and 
        /// compares them. Whichever is greater, it adds to an output list.</para>
        /// </summary>
        /// <param name="dur">Outputs a <see cref="TimeSpan"/> 
        /// representing how long it takes this operation.</param>

        private void RunBoolean(out TimeSpan dur) {
            Random rnd = new Random();

            var sw = Stopwatch.StartNew();

            // Checks whether the left random number is bigger
            // than the right. Not storing the results of these
            // rnd numbers, not necessary.

            for (ulong i = 0; i < this.rs.IterationsBoolean; i++) {
                bool b1 = (rnd.Next() > rnd.Next() ? true : false);
            }

            sw.Stop();
            dur = sw.Elapsed;
        }

        /// <summary>
        /// Runs a naive test using linked lists.
        /// <para>Creates two <see cref="LinkedList{T}"/> and
        /// adds, removes, and searches random numbers of type 
        /// <see cref="int"/>.</para></summary>
        /// <param name="dur">Outputs a <see cref="TimeSpan"/> 
        /// representing how long it takes this operation.</param>

        private void RunLinkedList(out TimeSpan dur) {
            const int LARGEST_NUM = 10000;
            Random rnd = new Random();
            LinkedList<int> lst1 = new LinkedList<int>();
            LinkedList<int> lst2 = new LinkedList<int>();

            var sw = Stopwatch.StartNew();
            int choice;

            for (ulong i = 0; i < this.rs.IterationsLinkedList; i++) {
                choice = rnd.Next(0, 3);

                switch (choice) {

                    // add
                    case 0: {
                        int rndNum = rnd.Next(LARGEST_NUM);
                        lst1.AddLast(rndNum);
                        lst2.AddLast(rndNum);

                        break;
                    }
                    // remove
                    case 1: {
                        int rndNum = rnd.Next(LARGEST_NUM);
                        bool b1 = lst1.Remove(rndNum);
                        bool b2 = lst2.Remove(rndNum);

                        break;
                    }
                    // search
                    case 2: {
                        int rndNum = rnd.Next(LARGEST_NUM);
                        bool b1 = lst1.Contains(rndNum);
                        bool b2 = lst2.Contains(rndNum);

                        break;
                    }
                }
            }
            // finished adding, removing and searching from these
            // linked lists.

            sw.Stop();
            dur = sw.Elapsed;

        }

        private void RunQueue(out TimeSpan dur) {
            Random rnd = new Random();
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();

            List<bool> lstResult = new List<bool>();
            var sw = Stopwatch.StartNew();
            int choice;

            for (ulong i = 0; i < this.rs.IterationsQueue; i++) {
                choice = rnd.Next(0, 3);

                switch (choice) {

                    // add
                    case 0: {
                        int rndNum = rnd.Next();
                        q1.Enqueue(rndNum);
                        q2.Enqueue(rndNum);
                        break;
                    }
                    // remove
                    case 1: {
                        try { // if queues are empty, can throw exceptions.
                            int i1 = q1.Dequeue();
                            int i2 = q2.Dequeue();
                        } catch (InvalidOperationException) {
                            break;
                        }

                        break;
                    }
                    // contains
                    case 2: {
                        int rndNum = rnd.Next();
                        bool b1 = q1.Contains(rndNum);
                        bool b2 = q2.Contains(rndNum);

                        break;
                    }
                }
            }
            // finished adding, removing and searching from these
            // queues.

            sw.Stop();
            dur = sw.Elapsed;

        }

        private void RunTree(out TimeSpan dur) {
            Random rnd = new Random();
            SortedSet<string> set1 = new SortedSet<string>();
            SortedSet<string> set2 = new SortedSet<string>();

            var sw = Stopwatch.StartNew();
            int choice;

            for (ulong i = 0; i < this.rs.IterationsTree; i++) {
                choice = rnd.Next(0, 3);

                switch (choice) {

                    // add
                    case 0: {
                        string rndStr = rnd.Next().ToString();
                        set1.Add(rnd.Next().ToString());
                        set2.Add(rnd.Next().ToString());

                        break;
                    }
                    // remove
                    case 1: {
                        string rndStr = rnd.Next().ToString();
                        bool b1 = set1.Remove(rndStr);
                        bool b2 = set2.Remove(rndStr);

                        break;
                    }
                    // search
                    case 2: {
                        string rndStr = rnd.Next().ToString();
                        bool b1 = set1.Contains(rndStr);
                        bool b2 = set2.Contains(rndStr);

                        break;
                    }
                }
            }
            // finished adding, removing and searching from these
            // linked lists.

            sw.Stop();
            dur = sw.Elapsed;

        }
    }

}

