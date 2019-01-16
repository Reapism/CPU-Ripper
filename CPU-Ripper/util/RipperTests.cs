using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CPU_Ripper.util {

    #region Partial class -> RipperTests 

    /// <summary>
    /// A partial class under <see cref="Ripper"/> which
    /// contains all the actual test functions.
    /// </summary>

    public partial class Ripper {

        #region Successorship functions

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
        /// Runs a naive test on successorship.
        /// <para>Counts from 0 to N.</para>
        /// </summary>

        private void RunSuccessorship() {
            for (ulong i = 0; i < this.rs.IterationsSuccessorship; i++) { }
        }

        #endregion

        #region Boolean functions

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

        private void RunBoolean() {
            Random rnd = new Random();

            for (ulong i = 0; i < this.rs.IterationsBoolean; i++) {
                bool b1 = (rnd.Next() > rnd.Next() ? true : false);
            }
        }

        #endregion

        #region LinkedLists functions.

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

        private void RunLinkedList() {
            const int LARGEST_NUM = 10000;
            Random rnd = new Random();
            LinkedList<int> lst1 = new LinkedList<int>();
            LinkedList<int> lst2 = new LinkedList<int>();

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

        }

        #endregion

        #region Queue functions.

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

        private void RunQueue() {
            Random rnd = new Random();
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();

            List<bool> lstResult = new List<bool>();
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
        }

        #endregion

        #region Tree functions.

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

        private void RunTree() {
            Random rnd = new Random();
            SortedSet<string> set1 = new SortedSet<string>();
            SortedSet<string> set2 = new SortedSet<string>();

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
        }

        #endregion

    }

    #endregion
}
