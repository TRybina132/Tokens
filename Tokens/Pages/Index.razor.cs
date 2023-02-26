using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Tokens.Pages;

public partial class Index
{
    private string _token1 = "Press to paste token";
    private string _token2 = "Press to paste token";
    private string _currentIconPath = "img/question.svg";
    private bool? _areEqual;

    private void CompareTokens() =>
        _areEqual = _token1.Equals(_token2);

    private async Task OnToken1Click() =>
        _token1 = await Clipboard.Default.GetTextAsync();

    private async Task OnToken2Click()
    {
        // TODO: Move paths to const
        _token2 = await Clipboard.Default.GetTextAsync();
        CompareTokens();
        _currentIconPath = _areEqual != null && _areEqual.Value ? "img/equal.svg" : "img/not-equal.svg";
        StateHasChanged();
    }

    private async Task SaveToken(string tokenValue)
    {

    }
}