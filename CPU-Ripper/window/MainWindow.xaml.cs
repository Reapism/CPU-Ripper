using CPU_Ripper.util;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Runtime.Serialization;

namespace CPU_Ripper.window {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    #region The mainwindow class.

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

            rs = new RipperSettings();
            r = new Ripper(ref rs);
      
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

            this.rs.AutoCheckForUpdates = Properties.Settings.Default.auto_updates;
            this.rs.FluidLoading = Properties.Settings.Default.fluid_loading;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e) {
            r.SingleThread();
            
        }

        private void BtnSpecs_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(new Specs().ToString());
        }

        private void BtnCompare_Click(object sender, RoutedEventArgs e) {

        }




        #endregion
    }

    #endregion
}
