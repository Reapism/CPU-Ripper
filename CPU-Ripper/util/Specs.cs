using System;

namespace CPU_Ripper.util {

    /// <summary>
    /// The <see cref="Specs"/> class.
    ///<para>Contains information about the current
    ///computer specs.</para> 
    ///<para>Author: Reapism / Anthony Jaghab (c), all rights reserved.</para>
    /// </summary>

    public class Specs {

        /// <summary>
        /// Returns a string containing information about the
        /// current users machine.
        /// </summary>
        /// <returns></returns>

        public override string ToString() =>
          $"Machine Name: {Environment.MachineName}\n" +
            $"User: {Environment.UserName}\n" +
            $"Network: {Environment.UserDomainName}\n" +
            $"System path: {Environment.SystemDirectory}\n" +
            $"CLR version: {Environment.Version}\n" +
            $"Ticks: {Environment.TickCount.ToString("n0")}\n" +
            $"Platform: {Environment.OSVersion.Platform.ToString()}\n" +
            $"Service Pack: {Environment.OSVersion.ServicePack}\n" +
            $"OS Version: {Environment.OSVersion.Version.ToString()}\n" +
            $"Threads: {Environment.ProcessorCount}\n";




    }
}
