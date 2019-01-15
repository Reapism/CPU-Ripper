using CPU_Ripper.util;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

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
            //// Create a timer and add its corresponding event
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Elapsed += TimerFade_Elapsed;

            //timer.Interval = 5;

            //// Want a new thread to run this task on so
            //// the main thread doesn't wait.

            //Task task = new Task(() => timer.Start());
            //task.Start();          
            //r.SingleThread();

            //new RipperAnimation(ref this.btnStart).FadeOut(RipperAnimation.RipperTimer.FAST);
            
            Storyboard sb = this.FindResource("FadeAnim") as Storyboard;
            Storyboard.SetTarget(sb, this.btnStart);
            sb.Begin();
            
        }

        private void TimerFade_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            // Access UI thread to decrease Opacity on a button from a different thread.

            Dispatcher.Invoke(() => {
                if (btnStart.Opacity > 0.0) {
                    btnStart.Opacity -= 0.01;
                    // code here to force update the GUI.
                } else {
                    System.Timers.Timer t;
                    t = (System.Timers.Timer)sender;
                    t.Stop();
                }
            });          
                
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
