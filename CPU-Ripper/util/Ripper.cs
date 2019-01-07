using CPU_Ripper.exception;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        public Ripper() {
            this.rs = new RipperSettings();
        }

        /// <summary>
        /// <para>[Recommended test]</para>
        /// Performs a multithreaded test on the CPU.
        /// </summary>
        /// <exception cref="RipperThreadException"> ds </exception>

        public void MultiThread() {
            throw new Exception();
        }



        private void SingleThread() {

        }

        private void RunSuccessorship(out TimeSpan dur) {
            var sw = Stopwatch.StartNew();

            for (ulong i = 0; i < this.rs.IterationsSuccessorship; i++) {
                i++;
            }
            sw.Stop();
            dur = sw.Elapsed;
        }

        private void RunBoolean(out TimeSpan dur) {
            Random rnd = new Random();
            List<bool> lstResult = new List<bool>();

            var sw = Stopwatch.StartNew();

            // Checks whether the left random number is bigger
            // than the right. Not storing the results of these
            // rnd numbers, not necessary.

            for (ulong i = 0; i < this.rs.IterationsBoolean; i++) {
                lstResult.Add(rnd.Next() > rnd.Next() ? true : false);
            }

            sw.Stop();
            dur = sw.Elapsed;
        }

        private void RunLinkedList(out TimeSpan dur) {
            const ushort NUM_ITERATIONS = 10000;
            Random rnd = new Random();
            LinkedList<string> lst1 = new LinkedList<string>();
            LinkedList<string> lst2 = new LinkedList<string>();
            
            LinkedList<bool> lstRemove = new LinkedList<bool>();
            LinkedList<bool> lstSearch = new LinkedList<bool>();

            var sw = Stopwatch.StartNew();
            int choice;

            for (ulong i = 0; i < this.rs.IterationsLinkedList; i++) {
                choice = rnd.Next(0, 3);

                switch (choice) {

                    // add
                    case 0: {
                        lst1.AddLast(rnd.Next(NUM_ITERATIONS).ToString());
                        lst2.AddLast(rnd.Next(NUM_ITERATIONS).ToString());
                        break;
                    }
                    // remove
                    case 1: {
                        bool b1 = lst1.Remove(rnd.Next(NUM_ITERATIONS).ToString());
                        bool b2 = lst2.Remove(rnd.Next(NUM_ITERATIONS).ToString());

                        if (b1 == b2) { lstRemove.AddLast(true); }

                        break;
                    }
                    // search
                    case 2: {
                        bool b1 = lst1.Contains(rnd.Next(NUM_ITERATIONS).ToString());
                        bool b2 = lst2.Contains(rnd.Next(NUM_ITERATIONS).ToString());

                        if (b1 == b2) { lstSearch.AddLast(true); }
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

