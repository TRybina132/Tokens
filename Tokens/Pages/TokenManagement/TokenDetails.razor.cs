using Data.Models;
using DataStorage.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Tokens.Pages.TokenManagement;

public partial class TokenDetails
{
    [Parameter]
    public string Id { get; set; }

    [Inject]
    protected IDialogService DialogService { get; set; }

    [Inject]
    private ITokenStorageService TokenStorageService { get; set; }

    [Inject]
    private NavigationManager NavManager { get; set; }

    private Token _token;
    private bool _isFailed;

    protected override void OnInitialized()
    {
        var result = TokenStorageService.GetItem(Int32.Parse(Id));
        if (result.IsSuccess)
        {
            _token = result.Value;
        }
        else if (result.IsFailed)
        {
            _isFailed = true;
        }
    }

    private void GoBack() =>
        NavManager.NavigateTo("/TokenList");
}   