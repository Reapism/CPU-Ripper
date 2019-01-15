using System.Windows.Controls;
using System.Windows.Threading;

namespace CPU_Ripper.util {

    #region

    /// <summary>
    /// The <see cref="RipperAnimation"/> class.
    /// <para>Fades </para>
    /// <para>Author: Reapism / Anthony Jaghab (c), all rights reserved.</para>
    /// </summary>

    public class RipperAnimation {

        #region Instance members

        private System.Timers.Timer timer;
        private Button ctrl;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>

        public RipperAnimation(ref Button ctrl) {
            this.timer = new System.Timers.Timer();
            this.timer.Elapsed += Timer_Elapsed;
            this.ctrl = ctrl;
        }

        /// <summary>
        /// Presets for the fade animation.
        /// </summary>

        public enum RipperTimer {
            /// <summary>
            /// Every 25 milliseconds, opacity +- .01 unit.
            /// </summary>
            CHILL,

            /// <summary>
            /// Every 10 milliseconds, opacity +- .01 unit.
            /// </summary>
            SMOOTH,

            /// <summary>
            /// Every 5 milliseconds, opacity +- .01 unit.
            /// </summary>
            MEDIUM,

            /// <summary>
            /// Every 2 milliseconds, opacity +- .01 unit.
            /// </summary>
            FAST,
        }

        /// <summary>
        /// Takes a <see cref="RipperTimer"/> and converts it to
        /// the respective interval.
        /// </summary>
        /// <param name="rt">A <see cref="RipperTimer"/> type to pass.</param>
        /// <returns></returns>

        private int GetInterval(RipperTimer rt) {
            switch (rt) {

                case RipperTimer.CHILL: {
                    return 25;
                }

                case RipperTimer.SMOOTH: {
                    return 10;
                }

                case RipperTimer.MEDIUM: {
                    return 5;
                }

                case RipperTimer.FAST: {
                    return 2;
                }

                default: {
                    return 5;
                }
            }
        }

        public void FadeIn(RipperTimer rt) =>
            FadeIn(GetInterval(rt));


        public void FadeIn(int milliseconds) {
            this.timer.Interval = (double)milliseconds;
            this.timer.Start();
        }

        public void FadeOut(RipperTimer rt) =>
            FadeOut(GetInterval(rt));


        public void FadeOut(int milliseconds) {
            this.timer.Interval = (double)milliseconds;
            this.timer.Start();

        }

         private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            Dispatcher.CurrentDispatcher.InvokeAsync(() => {      
                    if (this.ctrl.Opacity > 0.0) {
                        this.ctrl.Opacity -= 0.01;
                    } else {
                        this.timer.Stop();
                        this.ctrl.Opacity = 0.0;
                    }
            });
        }

    }

    #endregion
}
