// <copyright file="MusicPlayer.cs" company="Mark-James McDougall">
// Licensed under the GNU GPL v3 License. See LICENSE in the project root for license information.
// </copyright>
namespace MusicSharp
{
    using System;
    using System.IO;
    using SharpAudio;
    using SharpAudio.Codec;

    /// <summary>
    /// A cross-platform audio implementation using SharpAudio.
    /// </summary>
    public class MusicPlayer : IPlayer
    {
        private AudioEngine audioEngine = AudioEngine.CreateDefault();
        private SoundStream soundStream;

        public MusicPlayer()
        {
        }

        public bool IsAudioPlaying { get; set; }

        public string LastFileOpened { get; set; }

        public TimeSpan CurrentTime()
        {
            TimeSpan zeroTime = new TimeSpan(0);

            if (this.soundStream.IsPlaying)
            {
                return this.soundStream.Position;
            }
            else
            {
                return zeroTime;
            }
        }

        public void DecreaseVolume()
        {
            throw new NotImplementedException();
        }

        public void IncreaseVolume()
        {
            throw new NotImplementedException();
        }

        public void OpenFile(string path)
        {
            this.soundStream = new SoundStream(File.OpenRead(path), this.audioEngine);

            this.soundStream.Volume = 50.0f;
            this.soundStream.Play();
        }

        public void OpenStream(string streamURL)
        {
            throw new NotImplementedException();
        }

        public void PlayFromPlaylist(string path)
        {
            throw new NotImplementedException();
        }

        public void PlayPause()
        {
            throw new NotImplementedException();
        }

        public void SeekBackwards()
        {
            throw new NotImplementedException();
        }

        public void SeekForward()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public TimeSpan TrackLength()
        {
            return this.soundStream.Duration;
        }
    }
}
