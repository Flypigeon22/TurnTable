using Plugin.Maui.Audio;

namespace MauiApp3;

public partial class Imagemusic : ContentPage
{
    public Imagemusic(IAudioManager audioManager)
    {
        InitializeComponent();
        this.audioManager = audioManager;
        food.Text = MainPage.food;

    }

    private List<string> imageUrls = new List<string>
        {
            "url1.jpg",
            "url2.jpg",
            "url3.jpg",
            "url4.jpg",
            "url5.jpg",
            "url6.jpg",
            "url7.jpg",
            "url8.jpg",
            "url9.jpg",
            "url10.jpg",
            "url11.jpg",
            "url12.jpg",

        };

    private List<string> musie = new List<string>
        {
            "a1.m4a",
            "a2.m4a",
            "a3.m4a",
            "a4.m4a",
            "a5.m4a",
            "a6.m4a",
            "a7.m4a",
            "a8.m4a",
            "a9.m4a",
            "a10.m4a",
            "a11.m4a",
            "a12.m4a",
             
        };
    private readonly IAudioManager audioManager;

   
    protected override void OnAppearing()
    {
        base.OnAppearing();
        DisplayRandomImage();
    }

    private async void DisplayRandomImage()
    {

        Random random = new Random();
        int randomIndex = random.Next(0, imageUrls.Count);
        string randomImageUrl = imageUrls[randomIndex];
        string randommusic = musie[randomIndex];
        ImageControl.Source = randomImageUrl;
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(randommusic));
        player.Play();

    }

}