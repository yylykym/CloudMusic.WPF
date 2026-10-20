using CloudMusic.WPF.Models;
using CloudMusic.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Threading;

namespace CloudMusic.WPF.ViewModels;

public partial class PlayerBarViewModel : ObservableObject
{
    private readonly PlaybackService _playback = new();
    private readonly DispatcherTimer _timer;

    [ObservableProperty]
    public partial double PositionSeconds { get; set; }

    [ObservableProperty]
    public partial double DurationSeconds { get; set; }

    public PlayerBarViewModel()
    {
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000)
        };

        var watch = System.Diagnostics.Stopwatch.StartNew();
        double previousTime = 0;
        double previousPosition = 0;

        _timer.Tick += (_, _) =>
        {
            double now = watch.Elapsed.TotalSeconds;
            double position = _playback.PositionSeconds;

            System.Diagnostics.Debug.WriteLine(
                $"间隔：{now - previousTime:F3}s，" +
                $"播放推进：{position - previousPosition:F3}s");

            previousTime = now;
            previousPosition = position;

            DurationSeconds = Math.Max(1, _playback.DurationSeconds);
            PositionSeconds = position;
        };
    }

    [RelayCommand]
    private void Start()
    {
        var track = new Track
        {
            Title = "测试歌曲",
            Artist = "测试歌手",
            FilePath = @"D:\M500002YcfLY32QmRd.mp3"
        };

        PositionSeconds = 0;
        DurationSeconds = 1;

        _playback.Play(track);
        _timer.Start();
    }
}