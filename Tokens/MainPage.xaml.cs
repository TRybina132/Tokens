namespace Tokens;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    protected override void OnAppearing()
    {
        // Remove safe areas
#if IOS
        
        var scene = UIKit.UIApplication.SharedApplication.ConnectedScenes.ToArray<UIKit.UIWindowScene>().FirstOrDefault();
        if (scene != null)
        {
            int factor = DeviceDisplay.Current.MainDisplayInfo.Orientation switch
            {
                DisplayOrientation.Portrait => 2,
                DisplayOrientation.Landscape => 3,
                _ => 2
            };
            
            if (DeviceInfo.Current.Idiom == DeviceIdiom.Tablet)
                factor = 2;

            var windowScene = (UIKit.UIWindowScene)scene;
            var safeArea = windowScene.Windows.FirstOrDefault()?.SafeAreaInsets;
            Padding =  new Thickness(
                -(safeArea.Value.Left), //left
                Padding.Top, //safeArea.Value.Top, //-(safeArea.Value.Top * 2),// top, 
                -(safeArea.Value.Right), //right
                -(safeArea.Value.Bottom * factor)); //bottom
        }
#endif
	
    }
}