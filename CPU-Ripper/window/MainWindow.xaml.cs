using CPU_Ripper.util;
using System;
using System.Windows;

namespace CPU_Ripper.window {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    ///<para>Author: Reapism / Anthony Jaghab (c), all rights reserved.</para>
    /// </summary>

    #region The MainWindow class.

    public partial class MainWindow : Window {

        #region Instance members and properties

        /// <summary>
        /// A <see cref="RipperSettings"/> instance.
        /// </summary>
        private RipperSettings rs;

        /// <summary>
        /// A <see cref="Ripper"/> instance.
        /// </summary>
        private Ripper r;

        #endregion

        #region Constructors and methods.

        /// <summary>
        /// Default constructor for the main window.
        /// </summary>

        public MainWindow() {
            InitializeComponent();

            this.rs = new RipperSettings();
            this.r = new Ripper(ref this.rs);

            InitializeSettings();
        }

        /// <summary>
        /// Initializes values in the current <see cref="RipperSettings"/>
        /// instance to values stored in the settings. 
        /// </summary>

        private void InitializeSettings() {
            this.rs.IterationsSuccessorship = Properties.Settings.Default.iter_successor;
            this.rs.IterationsBoolean = Properties.Settings.Default.iter_bool;
            this.rs.IterationsQueue = Properties.Settings.Default.iter_queue;
            this.rs.IterationsLinkedList = Properties.Settings.Default.iter_linkedlist;
            this.rs.IterationsTree = Properties.Settings.Default.iter_tree;
            this.rs.AverageIterations = Properties.Settings.Default.iter_avg;

            this.rs.AutoCheckForUpdates = Properties.Settings.Default.auto_updates;
            this.rs.FluidLoading = Properties.Settings.Default.fluid_loading;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e) {
            this.btnStart.ContextMenu.IsOpen = true;
        }

        private void BtnSpecs_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(new Specs().ToString());
        }

        private void BtnCompare_Click(object sender, RoutedEventArgs e) {

        }

        private void BtnSingle_Click(object sender, RoutedEventArgs e) {
            this.txtStats.Document.Blocks.Clear();
            PrintTestIterations();
            this.r.SingleThread();
        }

        private void BtnMulti_Click(object sender, RoutedEventArgs e) {
            this.txtStats.Document.Blocks.Clear();
            PrintTestIterations();
            this.r.MultiThread();
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

            w.txtStats.AppendText($"Specs\n\n{new Specs().ToString()}");
            w.txtStats.AppendText("\n\n\nIterations\n");
            w.txtStats.AppendText($"\nSuccessorship: {this.rs.IterationsSuccessorship.ToString("n0")}");
            w.txtStats.AppendText($"\nBoolean: {this.rs.IterationsBoolean.ToString("n0")}");
            w.txtStats.AppendText($"\nQueue: {this.rs.IterationsQueue.ToString("n0")}");
            w.txtStats.AppendText($"\nLinked List: {this.rs.IterationsLinkedList.ToString("n0")}");
            w.txtStats.AppendText($"\nTree: {this.rs.IterationsTree.ToString("n0")}");
        }

        #endregion
    }

    #endregion
}
