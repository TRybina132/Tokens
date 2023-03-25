using DataStorage.Models;
using DataStorage.Services;
using DataStorage.Services.Abstractions;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Tokens;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        
        builder.Services.AddMudServices();

        builder.Services.Configure<DatabaseSettings>(settings =>
        {
            settings.FilePath = FileSystem.Current + "/tokens.sqlite";
        });

        builder.Services.AddScoped<ITokenStorageService, TokenStorageService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}