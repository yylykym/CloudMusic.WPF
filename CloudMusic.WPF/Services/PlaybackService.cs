using CloudMusic.WPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace CloudMusic.WPF.Services
{
    public class PlaybackService
    {

        private readonly MediaPlayer _player = new();

        public double PositionSeconds => _player.Position.TotalSeconds;

        public double DurationSeconds =>
            _player.NaturalDuration.HasTimeSpan
                ? _player.NaturalDuration.TimeSpan.TotalSeconds
                : 0;

        public PlaybackService()
        {
            _player.MediaOpened += (_, _) =>
            {
                System.Diagnostics.Debug.WriteLine("音频加载成功");
            };

            _player.MediaFailed += (_, e) =>
            {
                System.Diagnostics.Debug.WriteLine(
                    $"音频加载失败：{e.ErrorException.Message}");
            };
        }

        public void Play(Track track) 
        {
            _player.Open(new Uri(track.FilePath, UriKind.Absolute));
            _player.Play();
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void Resume()
        {
            _player.Play();
        }
    }
}
