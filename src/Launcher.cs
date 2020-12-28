// <copyright file="Launcher.cs" company="Mark-James McDougall">
// Licensed under the GNU GPL v3 License. See LICENSE in the project root for license information.
// </copyright>

namespace MusicSharp
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The launcher class sets up MusicSharp to run based on the user's platform.
    /// </summary>
    public class Launcher
    {
        /// <summary>
        /// Returns the OS Platform the user is running on.
        /// </summary>
        /// <returns>The user's OS Platform.</returns>
        public static OSPlatform GetOperatingSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }

            throw new Exception("Cannot determine operating system!");
        }

        /// <summary>
        /// Start MusicSharp with the platform specific player implentation.
        /// </summary>
        public void StartMusicSharp()
        {
            if (GetOperatingSystem() == OSPlatform.Windows)
            {
                IPlayer player = new WinPlayer();

                Tui gui = new Tui(player);
                gui.Start();
            }

            if (GetOperatingSystem() == OSPlatform.Linux)
            {
                IPlayer player = new MusicPlayer();

                Tui gui = new Tui(player);
                gui.Start();
            }

            if (GetOperatingSystem() == OSPlatform.OSX)
            {
                IPlayer player = new MusicPlayer();

                Tui gui = new Tui(player);
                gui.Start();
            }
            else
            {
                Console.WriteLine("Error: Unable to determine operating system version.");
            }
        }
    }
}
