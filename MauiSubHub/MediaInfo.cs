using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiSubHub;

public partial class MediaInfo : ObservableObject
{
    [ObservableProperty]
    public partial string Name { get; set; } = string.Empty;
    public TimeSpan Position => stopwatch.Elapsed;
    IDispatcherTimer? timer { get; set; } = null;
    Stopwatch stopwatch { get; } = new Stopwatch();
    public MediaInfo(string name)
    {
        Name = name;
    }

    [RelayCommand]
    public void Start(View sender)
    {
        stopwatch.Start();
        timer = sender.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMicroseconds(16);
        timer.Tick += (s, e) => { OnPropertyChanged(nameof(Position)); };
        timer.Start();
    }

    [RelayCommand]
    public void Stop()
    {
        if (timer is not null)
        {
            timer.Stop();
            timer = null;
        }
        stopwatch.Stop();
    }
}
