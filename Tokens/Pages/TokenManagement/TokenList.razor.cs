using Data.Models;
using DataStorage.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Tokens.Pages.TokenManagement;

public partial class TokenList
{
    private List<Token> _tokens = new List<Token>();

    [Inject]
    protected IDialogService DialogService { get; set; }

    [Inject]
    ITokenStorageService TokenStorageService { get; set; }

    protected override void OnInitialized()
    {
        var result = TokenStorageService.GetAllItems();
        if (result.IsSuccess)
        {
            _tokens = result.Collection.ToList();
        }
    }
}