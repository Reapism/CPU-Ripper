using System;

namespace CPU_Ripper.util {

    /// <summary>
    /// The <see cref="Specs"/> class.
    /// <para>Contains information about the current
    /// computer specs. Implements IComputerSpecs</para> 
    /// <para>Author: Reapism / Anthony Jaghab (c), all rights reserved.</para>
    /// </summary>

    public class Specs : IComputerSpecs {
        /// <summary>
        /// The machine name for this instance.
        /// </summary>
        public string MachineName => Environment.MachineName;

        /// <summary>
        /// The username for this instance.
        /// </summary>
        public string UserName => Environment.UserName;

        /// <summary>
        /// The network name for this instance.
        /// </summary>
        public string NetworkName => Environment.UserDomainName;

        /// <summary>
        /// The system directory for this instance.
        /// </summary>
        public string SystemDirectory => Environment.SystemDirectory;

        /// <summary>
        /// The CLR version for this machine instance.
        /// </summary>
        public Version CLRVersion => Environment.Version;

        /// <summary>
        /// The number of ticks since the machine started for this instance.
        /// </summary>
        public int TickCount => Environment.TickCount;

        /// <summary>
        /// The platform for this instance.
        /// </summary>
        public string Platform => Environment.OSVersion.Platform.ToString();

        /// <summary>
        /// The service pack version for this instance.
        /// </summary>
        public string ServicePack => Environment.OSVersion.ServicePack;

        /// <summary>
        /// The OS version for this machine instance.
        /// </summary>
        public Version OSVersion => Environment.OSVersion.Version;

        /// <summary>
        /// The logical processors (threads) for this CPU instance.
        /// </summary>
        public int ThreadCount => Environment.ProcessorCount;

        /// <summary>
        /// Returns a string containing information about the
        /// current users machine.
        /// </summary>
        /// <returns></returns>

        public override string ToString() =>
          $"Machine Name: {Environment.MachineName}\n" +
            $"User: {Environment.UserName}\n" +
            $"Network: {}\n" +
            $"System path: {Environment.SystemDirectory}\n" +
            $"CLR version: {Environment.Version}\n" +
            $"Ticks: {Environment.TickCount.ToString("n0")}\n" +
            $"Platform: {Environment.OSVersion.Platform.ToString()}\n" +
            $"Service Pack: {Environment.OSVersion.ServicePack}\n" +
            $"OS Version: {Environment.OSVersion.Version.ToString()}\n" +
            $"Threads: {Environment.ProcessorCount}\n";




    }
}
