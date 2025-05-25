using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MauiSubHub;

public partial class MediaInfo : ObservableObject
{
    [ObservableProperty]
    public partial string Name { get; set; } = string.Empty;
    public IDispatcherTimer? Timer { get; set; } = null;
    public Stopwatch Stopwatch { get; } = new Stopwatch();
    public TimeSpan Elapsed => Stopwatch.Elapsed;
    public MediaInfo(string name)
    {
        Name = name;
    }

    [RelayCommand]
    public void Start(View sender)
    {
        Stopwatch.Start();
        Timer = sender.Dispatcher.CreateTimer();
        Timer.Interval = TimeSpan.FromMicroseconds(16);
        Timer.Tick += (s, e) => { OnPropertyChanged(nameof(Elapsed)); };
        Timer.Start();
    }

    [RelayCommand]
    public void Stop()
    {
        if (Timer is not null)
        {
            Timer.Stop();
            Timer = null;
        }
        Stopwatch.Stop();
    }
}
