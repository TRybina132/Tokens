using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Data.Models;
using Tokens.Pages.Dialogs;
using DataStorage.Services.Abstractions;

namespace Tokens.Pages;

public partial class Index
{
    private string _token1 = "Press to paste token";
    private string _token2 = "Press to paste token";
    private string _currentIconPath = "img/question.svg";
    private bool? _areEqual;

    [Inject]
    protected IDialogService DialogService { get; set; }

    [Inject]
    ITokenStorageService TokenStorageService { get; set; }

    [Inject]
    NavigationManager NavManager { get; set; }

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
        var token = new Token
        {
            Value = tokenValue
        };
        var parameters = new DialogParameters
        {
            ["token"] = token
        };
        var dialog = await DialogService
            .ShowAsync<CreateTokenDialog>("Create token", parameters);
        var result = await dialog.Result;
        if (result.Canceled is false)
        {
            var res = TokenStorageService.Save(token);
            Console.WriteLine("saved");
        }
    }

    private void GoToCollection() =>
        NavManager.NavigateTo("/TokenList");
}