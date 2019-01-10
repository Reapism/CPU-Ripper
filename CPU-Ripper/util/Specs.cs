using System;

namespace CPU_Ripper.util {
    public class Specs {

        public Specs() {

        }

        public override string ToString() =>
          $"Machine Name: {Environment.MachineName}\n" +
            $"User: {Environment.UserName}\n" +
            $"Network: {Environment.UserDomainName}\n" +
            $"System path: {Environment.SystemDirectory}\n" +
            $"CLR version: {Environment.Version}\n" +
            $"Ticks: {Environment.TickCount}\n" +
            $"Platform: {Environment.OSVersion.Platform}\n" +
            $"Service Pack: {Environment.OSVersion.ServicePack}\n" +
            $"OS Version: {Environment.OSVersion.Version}\n" +
            $"Threads: {Environment.ProcessorCount}\n";




    }
}
