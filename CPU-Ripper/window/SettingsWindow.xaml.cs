using CPU_Ripper.exception;
using CPU_Ripper.util;
using System.Windows;
using System.Windows.Controls;

namespace CPU_Ripper.window {
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window {

        #region Instance members and Properties.

        private RipperSettings rs;

        /// <summary>
        /// Defines which test.
        /// </summary>

        private enum Test {

            /// <summary>
            /// The successorship test.
            /// </summary>
            Successorship,

            /// <summary>
            /// The boolean test. Checks which of two random integers is greater.
            /// </summary>
            Boolean,

            /// <summary>
            /// The queue test. Uses a <see cref="System.Collections.Generic.Queue{T}"/>
            /// </summary>
            Queue,

            /// <summary>
            /// The Linked list test. Uses a <see cref="System.Collections.Generic.LinkedList{T}"/>
            /// </summary>
            LinkedList,

            /// <summary>
            /// The Tree test. Uses a <see cref="System.Collections.Generic.SortedSet{T}"/>
            /// </summary>
            Tree
        }

        #endregion

        #region Contructor and methods.

        /// <summary>
        /// Default constructor.
        /// </summary>

        public SettingsWindow(RipperSettings rs) {
            this.rs = rs;

            InitializeComponent();
            InitializeSettings();
        }

        /// <summary>
        /// Initializes the <see cref="SettingsWindow"/>
        /// with some default properties.
        /// </summary>

        private void InitializeSettings() {
            UpdateTextIter(Test.Successorship);
            UpdateTextIter(Test.Boolean);
            UpdateTextIter(Test.Queue);
            UpdateTextIter(Test.LinkedList);
            UpdateTextIter(Test.Tree);
        }

        /// <summary>
        /// Updates a particular textbox thats
        /// associated with a particular test
        /// with a potentially new value.
        /// </summary>
        /// <param name="updateMe">A <see cref="Test"/> parameter which 
        /// represents all the tests.</param>
        /// <exception cref="RipperUnknownTestException">Thrown if an unknown 
        /// <see cref="Test"/> type is passed.</exception>

        private void UpdateTextIter(Test updateMe) {

            switch (updateMe) {
                case Test.Successorship: {
                    this.txtSuccIter.Text = $"  Successorship: {this.rs.IterationsSuccessorship.ToString("n0")}";
                    break;
                }

                case Test.Boolean: {
                    this.txtBoolIter.Text = $"  Boolean: {this.rs.IterationsBoolean.ToString("n0")}";
                    break;
                }

                case Test.Queue: {
                    this.txtQueueIter.Text = $"  Queue: {this.rs.IterationsQueue.ToString("n0")}";
                    break;
                }

                case Test.LinkedList: {
                    this.txtLinkedIter.Text = $"  LinkedList: {this.rs.IterationsLinkedList.ToString("n0")}";
                    break;
                }

                case Test.Tree: {
                    this.txtTreeIter.Text = $"  Tree: {this.rs.IterationsTree.ToString("n0")}";
                    break;
                }

                default: {
                    throw new RipperUnknownTestException("Attempted to update an unknown textboxes test.");
                }
            }
        }

        /// <summary>
        /// Clears a particular textbox thats
        /// associated with a particular test.
        /// </summary>
        /// <param name="clearMe">A <see cref="Test"/> which refers
        /// to a particular <see cref="Ripper"/> test.</param>
        /// <exception cref="RipperUnknownTestException">Thrown if an unknown 
        /// <see cref="Test"/> type is passed.</exception>

        private void ClearTextIter(Test clearMe) {
            switch (clearMe) {
                case Test.Successorship: {
                    this.txtSuccIter.Clear();
                    break;
                }

                case Test.Boolean: {
                    this.txtBoolIter.Clear();
                    break;
                }

                case Test.Queue: {
                    this.txtQueueIter.Clear();
                    break;
                }

                case Test.LinkedList: {
                    this.txtLinkedIter.Clear();
                    break;
                }

                case Test.Tree: {
                    this.txtTreeIter.Clear();
                    break;
                }

                default: {
                    throw new RipperUnknownTestException("Attempted to clear an unknown textbox.");
                }
            }
        }

        /// <summary>
        /// Clears all passed <see cref="TextBox"/> controls.
        /// </summary>
        /// <param name="txtBoxes">One or many <see cref="TextBox"/></param>

        private void ClearTextIter(params TextBox[] txtBoxes) {
            foreach (TextBox t in txtBoxes) { t.Clear(); }
        }

        /// <summary>
        /// Gets a particular textbox thats
        /// associated with a particular test.
        /// </summary>
        /// <param name="getMe">A <see cref="Test"/> which refers
        /// to a particular <see cref="Ripper"/> test.</param>
        /// <exception cref="RipperUnknownTestException">Thrown if an unknown 
        /// <see cref="Test"/> type is passed.</exception>
        
        private TextBox GetTextBox(Test getMe) {

            switch (getMe) {
                case Test.Successorship: {
                    return txtSuccIter;
                }

                case Test.Boolean: {
                    return txtBoolIter;
                }

                case Test.Queue: {
                    return txtQueueIter;
                }

                case Test.LinkedList: {
                    return txtSuccIter;
                }

                case Test.Tree: {
                    return txtTreeIter;
                }

                default: {
                    throw new RipperUnknownTestException("Attempted to get an unknown textbox from an unknown test.");
                }
            }
        }

        /// <summary>
        /// Updates a particular <see cref="Test"/> setting in the
        /// application settings and saves the change.
        /// </summary>
        /// <param name="updateMe">A <see cref="Test"/> which refers
        /// to a particular <see cref="Ripper"/> test.</param>

        private void UpdateSettings(Test updateMe) {

            switch (updateMe) {
                case Test.Successorship: {
                    Properties.Settings.Default.iter_successor = rs.IterationsSuccessorship;
                    break;
                }

                case Test.Boolean: {
                    Properties.Settings.Default.iter_bool = rs.IterationsBoolean;
                    break;
                }

                case Test.Queue: {
                    Properties.Settings.Default.iter_queue = rs.IterationsQueue;
                    break;
                }

                case Test.LinkedList: {
                    Properties.Settings.Default.iter_linkedlist = rs.IterationsLinkedList;
                    break;
                }

                case Test.Tree: {
                    Properties.Settings.Default.iter_tree = rs.IterationsTree;
                    break;
                }
            }

            Properties.Settings.Default.Save();
        }

        #endregion

        #region Events and Event methods.

        private void ChkFluidLoad_Checked(object sender, RoutedEventArgs e) {

        }

        private void ChkAutoUpdates_Checked(object sender, RoutedEventArgs e) {

        }

        private void ChkGlue_Checked(object sender, RoutedEventArgs e) {

        }

        private void TxtSuccIter_GotFocus(object sender, RoutedEventArgs e) {
            ClearTextIter(Test.Successorship);
        }

        private void TxtSuccIter_LostFocus(object sender, RoutedEventArgs e) {
            UpdateTextIter(Test.Successorship);
        }

        private void TxtSuccIter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (ulong.TryParse(this.txtSuccIter.Text, out ulong i)) {
                    rs.IterationsSuccessorship = i;
                    this.txtBoolIter.Focus();
                    UpdateSettings(Test.Successorship);
                }
            }
        }

        private void TxtBoolIter_GotFocus(object sender, RoutedEventArgs e) {
            ClearTextIter(Test.Boolean);
        }

        private void TxtBoolIter_LostFocus(object sender, RoutedEventArgs e) {
            UpdateTextIter(Test.Boolean);
        }

        private void TxtBoolIter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (ulong.TryParse(this.txtBoolIter.Text, out ulong i)) {
                    rs.IterationsBoolean = i;
                    this.txtQueueIter.Focus();
                    UpdateSettings(Test.Boolean);
                }
            }
        }

        private void TxtQueueIter_GotFocus(object sender, RoutedEventArgs e) {
            ClearTextIter(Test.Queue);
        }

        private void TxtQueueIter_LostFocus(object sender, RoutedEventArgs e) {
            UpdateTextIter(Test.Queue);
        }

        private void TxtQueueIter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (ulong.TryParse(this.txtQueueIter.Text, out ulong i)) {
                    rs.IterationsQueue = i;
                    this.txtLinkedIter.Focus();
                    UpdateSettings(Test.Queue);
                }
            }
        }

        private void TxtLinkedIter_GotFocus(object sender, RoutedEventArgs e) {
            ClearTextIter(Test.LinkedList);
        }

        private void TxtLinkedIter_LostFocus(object sender, RoutedEventArgs e) {
            UpdateTextIter(Test.LinkedList);
        }

        private void TxtLinkedIter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (ulong.TryParse(this.txtLinkedIter.Text, out ulong i)) {
                    rs.IterationsLinkedList = i;
                    this.txtTreeIter.Focus();
                    UpdateSettings(Test.LinkedList);
                }
            }
        }

        private void TxtTreeIter_GotFocus(object sender, RoutedEventArgs e) {
            ClearTextIter(Test.Tree);
        }

        private void TxtTreeIter_LostFocus(object sender, RoutedEventArgs e) {
            UpdateTextIter(Test.Tree);
        }

        private void TxtTreeIter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (ulong.TryParse(this.txtTreeIter.Text, out ulong i)) {
                    rs.IterationsTree = i;
                    this.grpApp.Focus();
                    UpdateSettings(Test.Tree);
                }
            }
        }
            
        #endregion
    }
}
