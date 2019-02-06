using System;

namespace CPU_Ripper.util {

    /// <summary>
    /// The <see cref="IComputerSpecs"/> interface.
    /// Represents generialized properties that Computer specs might have.
    /// </summary>
    public interface IComputerSpecs {

        /// <summary>
        /// Gets a machine name.
        /// </summary>
        string MachineName { get; }
        
        /// <summary>
        /// Gets a username.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Gets a network name.
        /// </summary>
        string NetworkName { get; }

        /// <summary>
        /// Gets a system directory.
        /// </summary>
        string SystemDirectory { get; }

        /// <summary>
        /// Gets a CLR version.
        /// </summary>
        Version CLRVersion { get; }

        /// <summary>
        /// Gets the number of ticks since a system started.
        /// </summary>
        int TickCount { get; }

        /// <summary>
        /// Gets the platform on a machine.
        /// </summary>
        string Platform { get; }

        /// <summary>
        /// Gets a service pack for a machine.
        /// </summary>
        string ServicePack { get; }

        /// <summary>
        /// Gets the OS version from a machine.
        /// </summary>
        Version OSVersion { get; }

        /// <summary>
        /// Gets the number of logical processors (threads) for a CPU.
        /// </summary>
        int ThreadCount { get; }

    }
}
