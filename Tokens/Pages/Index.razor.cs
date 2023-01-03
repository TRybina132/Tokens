namespace Tokens.Pages;

public partial class Index
{
    private string _token1 = "";
    private string _token2;
    
    private async Task OnToken1Click()
    {
        _token1 = await Clipboard.Default.GetTextAsync();
        Console.WriteLine(_token1);
    }
}