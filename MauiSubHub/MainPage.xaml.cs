namespace MauiSubHub;

public partial class MainPage : ContentPage
{
    public AppViewModel VM { get; }

    public MainPage(AppViewModel VM)
    {
        this.BindingContext = this.VM = VM;

        InitializeComponent();
    }

    async void OnNavigate(object? sender, EventArgs e)
    {
        Button btn = (Button)sender!;
        await Shell.Current.GoToAsync(btn.CommandParameter.ToString()!);
    }
}
