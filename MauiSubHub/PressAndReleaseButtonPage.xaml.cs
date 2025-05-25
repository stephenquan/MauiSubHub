namespace MauiSubHub;

public partial class PressAndReleaseButtonPage : ContentPage
{
    public AppViewModel VM { get; }

    public PressAndReleaseButtonPage(AppViewModel VM)
    {
        this.BindingContext = this.VM = VM;
        InitializeComponent();
    }

    void OnButtonPressed(object sender, EventArgs e)
    {
        VM.SelectedListItem?.Start((Button)sender);
    }

    void OnButtonReleased(object sender, EventArgs e)
    {
        VM.SelectedListItem?.Stop();
    }

    void AddPlayer(object sender, EventArgs e)
    {
        string name = $"Audio_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.mp3";
        VM.UserItems.Add(new MediaInfo(name));
        VM.SelectedListItem = VM.UserItems[VM.UserItems.Count - 1];
    }
}
