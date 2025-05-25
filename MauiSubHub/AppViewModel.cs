using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MauiSubHub;

public partial class AppViewModel : ObservableObject
{
    public ObservableCollection<MediaInfo> UserItems { get; } = [];

    [ObservableProperty]
    public partial MediaInfo? SelectedListItem { get; set; }
}
