using System;

namespace CPU_Ripper.util {

    /// <summary>
    /// The <see cref="BaseComputerSpecs"/> class.
    /// Represents the base computer specs representing
    /// a score of 50.<para> Implements 
    /// <see cref="IComputerSpecs"/>.</para> 
    /// </summary>
    public class BaseComputerSpecs : IComputerSpecs {


        /// <summary>
        /// Default machine name.
        /// </summary>
        public string MachineName => "Default Machine";

        /// <summary>
        /// Default username.
        /// </summary>
        public string UserName => "Default";

        /// <summary>
        /// Default network name.
        /// </summary>
        public string NetworkName => throw new NotImplementedException();

        /// <summary>
        /// Default system directory path.
        /// </summary>
        public string SystemDirectory => throw new NotImplementedException();

        /// <summary>
        /// Default CLR version.
        /// </summary>
        public Version CLRVersion => throw new NotImplementedException();

        /// <summary>
        /// Default tick count.
        /// </summary>
        public int TickCount => throw new NotImplementedException();

        /// <summary>
        /// Default platform.
        /// </summary>
        public string Platform => throw new NotImplementedException();

        /// <summary>
        /// Default service pack.
        /// </summary>
        public string ServicePack => throw new NotImplementedException();

        /// <summary>
        /// Default OS version.
        /// </summary>
        public Version OSVersion => throw new NotImplementedException();

        /// <summary>
        /// Default thread count.
        /// </summary>
        public int ThreadCount => throw new NotImplementedException();
    }
}
