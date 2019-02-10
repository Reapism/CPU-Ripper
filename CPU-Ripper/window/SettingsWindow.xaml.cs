using CPU_Ripper.exception;
using CPU_Ripper.util;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPU_Ripper.window {
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window {

        #region Instance members and Properties.

        private RipperSettings rs;

        /// <summary>
        /// Represents each test function as an enumerated data-type.
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

        /// <summary>
        /// Represents each application setting in <see cref="SettingsWindow"/>.
        /// </summary>
        private enum AppSettings {

            /// <summary>
            /// Automatically checks for updates
            /// on application load.
            /// </summary>
            AutoUpdates,

            /// <summary>
            /// Fluid load preloads all application 
            /// windows for nice visual effects.
            /// </summary>
            FluidLoad,

            /// <summary>
            /// Glues the settings window to be 
            /// side-by-side with the main window.
            /// </summary>
            Glue,

            /// <summary>
            /// Opacity for the forms.
            /// </summary>
            Opacity,
        }

        #endregion

        #region Constructor and methods.

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

            this.chkAutoUpdates.IsEnabled = Properties.Settings.Default.auto_updates;
            this.chkFluidLoad.IsEnabled = Properties.Settings.Default.fluid_loading;
            this.chkGlue.IsEnabled = Properties.Settings.Default.glue;

            this.sliderOpacity.Value = Properties.Settings.Default.opacity;
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
        /// <param name="txtBoxes">One or many <see cref="TextBox"/>(s).</param>

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
                    return this.txtSuccIter;
                }

                case Test.Boolean: {
                    return this.txtBoolIter;
                }

                case Test.Queue: {
                    return this.txtQueueIter;
                }

                case Test.LinkedList: {
                    return this.txtSuccIter;
                }

                case Test.Tree: {
                    return this.txtTreeIter;
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
                    Properties.Settings.Default.iter_successor = this.rs.IterationsSuccessorship;
                    break;
                }

                case Test.Boolean: {
                    Properties.Settings.Default.iter_bool = this.rs.IterationsBoolean;
                    break;
                }

                case Test.Queue: {
                    Properties.Settings.Default.iter_queue = this.rs.IterationsQueue;
                    break;
                }

                case Test.LinkedList: {
                    Properties.Settings.Default.iter_linkedlist = this.rs.IterationsLinkedList;
                    break;
                }

                case Test.Tree: {
                    Properties.Settings.Default.iter_tree = this.rs.IterationsTree;
                    break;
                }
            }

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Updates a particular <see cref="AppSettings"/> setting in the
        /// application settings and saves the change.
        /// </summary>
        /// <param name="updateMe">A <see cref="AppSettings"/> which refers
        /// to a particular <see cref="Ripper"/> test.</param>

        private void UpdateSettings(AppSettings updateMe) {

            switch (updateMe) {
                case AppSettings.AutoUpdates: {
                    Properties.Settings.Default.auto_updates = this.rs.AutoCheckForUpdates;
                    break;
                }

                case AppSettings.FluidLoad: {
                    Properties.Settings.Default.fluid_loading = this.rs.FluidLoading;
                    break;
                }

                case AppSettings.Glue: {
                    Properties.Settings.Default.glue = this.rs.Glue;
                    break;
                }

                case AppSettings.Opacity: {
                    Properties.Settings.Default.opacity = this.rs.Opacity;
                    break;
                }
            }

            Properties.Settings.Default.Save();
        }

        private void FocusTextBox(TextBox t) {
            t.BorderBrush = new SolidColorBrush(Colors.DarkOliveGreen);

        }

        private void LostFocusTextBox(TextBox t) {
            t.BorderBrush = Brushes.Transparent;
        }

        #endregion

        #region Events and Event methods.

        private void ChkFluidLoad_Checked(object sender, RoutedEventArgs e) {
            // Uses coalescing operator because isChecked is nullable.
            if (chkFluidLoad.IsChecked ?? true) {
                return; // if we are null, get out of method.
            }
            this.rs.FluidLoading = chkFluidLoad.IsChecked.Value;
            UpdateSettings(AppSettings.FluidLoad);
        }

        private void ChkAutoUpdates_Checked(object sender, RoutedEventArgs e) {
            this.rs.AutoCheckForUpdates = chkAutoUpdates.IsChecked.Value;
            UpdateSettings(AppSettings.AutoUpdates);
        }

        private void ChkGlue_Checked(object sender, RoutedEventArgs e) {
            this.rs.Glue = chkGlue.IsChecked.Value;
            UpdateSettings(AppSettings.Glue);
        }

        private void ChkFluidLoad_Unchecked(object sender, RoutedEventArgs e) {
            this.rs.FluidLoading = chkFluidLoad.IsChecked.Value;
            UpdateSettings(AppSettings.FluidLoad);
        }

        private void ChkAutoUpdates_Unchecked(object sender, RoutedEventArgs e) {
            this.rs.AutoCheckForUpdates = chkAutoUpdates.IsChecked.Value;
            UpdateSettings(AppSettings.AutoUpdates);
        }

        private void ChkGlue_Unchecked(object sender, RoutedEventArgs e) {
            this.rs.Glue = chkGlue.IsChecked.Value;
            UpdateSettings(AppSettings.Glue);
        }

        private void SliderOpacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            // logic

            UpdateSettings(AppSettings.Opacity); // update the settings.
        }

        private void TxtSuccIter_GotFocus(object sender, RoutedEventArgs e) {
            ClearTextIter(Test.Successorship);
            FocusTextBox((TextBox)sender);
        }

        private void TxtSuccIter_LostFocus(object sender, RoutedEventArgs e) {
            UpdateTextIter(Test.Successorship);
        }

        private void TxtSuccIter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (ulong.TryParse(this.txtSuccIter.Text, out ulong i)) {
                    this.rs.IterationsSuccessorship = i;
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
                    this.rs.IterationsBoolean = i;
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
                    this.rs.IterationsQueue = i;
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
                    this.rs.IterationsLinkedList = i;
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
                    this.rs.IterationsTree = i;
                    this.grpApp.Focus();
                    UpdateSettings(Test.Tree);
                }
            }
        }

        #endregion
    }
}
