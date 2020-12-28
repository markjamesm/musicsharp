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
        /// Start MusicSharp with the platform specific player implentation.
        /// </summary>
        public void StartMusicSharp()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                IPlayer player = new WinPlayer();

                Tui gui = new Tui(player);
                gui.Start();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                IPlayer player = new MusicPlayer();

                Tui gui = new Tui(player);
                gui.Start();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                IPlayer player = new MusicPlayer();

                Tui gui = new Tui(player);
                gui.Start();
            }

            throw new Exception("Cannot determine operating system!");
        }
    }
}
