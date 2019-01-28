using System;

namespace CPU_Ripper.exception {

    /// <summary>
    /// The <see cref="RipperUnknownTestException"/> class.
    /// <para>Represents a <see cref="RipperUnknownTestException"/> with a custom
    /// messsage.</para>
    /// <para>Author: Reapism / Anthony Jaghab (c), all rights reserved.</para>
    /// </summary>

    public class RipperUnknownTestException : Exception {

        private string exceptionMsg;

        /// <summary>
        /// Default parameterized constructor which holds 
        /// a custom <seealso cref="RipperUnknownTestException"/>
        /// message.
        /// </summary>
        /// <param name="exceptionMsg">The custom 
        /// <seealso cref="RipperUnknownTestException"/> message.</param>

        public RipperUnknownTestException(string exceptionMsg) {
            this.exceptionMsg = exceptionMsg;
        }

        /// <summary>
        /// Returns a string describing this 
        /// particular <see cref="RipperUnknownTestException"/>.
        /// </summary>
        /// <returns>A string containing the <see cref="RipperUnknownTestException"/></returns>

        public override string ToString() => $"A RipperUnknownTestException was generated. -> { this.exceptionMsg }.";


    }
}
