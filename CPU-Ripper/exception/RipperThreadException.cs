using System;

namespace CPU_Ripper.exception {

    /// <summary>
    /// The <see cref="RipperThreadException"/> class.
    /// <para>Represents a <see cref="RipperThreadException"/> with a custom
    /// messsage.</para>
    /// </summary>

    public class RipperThreadException : Exception {

        private string exceptionMsg;

        /// <summary>
        /// Default parameterized constructor which holds 
        /// a custom <seealso cref="RipperThreadException"/>
        /// message.
        /// </summary>
        /// <param name="exceptionMsg">The custom 
        /// <seealso cref="RipperThreadException"/> message.</param>

        public RipperThreadException(string exceptionMsg) {
            this.exceptionMsg = exceptionMsg;
        }

        /// <summary>
        /// Returns a string describing this 
        /// particular <see cref="RipperThreadException"/>.
        /// </summary>
        /// <returns>A string containing the <see cref="RipperThreadException"/></returns>

        public override string ToString() => $"A RipperThreadException was generated. -> { this.exceptionMsg }.";


    }
}
