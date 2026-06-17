using Microsoft.AspNetCore.Components;

namespace blazorwasm.Services;

public class NavigationHandler
{
    readonly NavigationManager _manager;
    readonly Uri _base;
    public NavigationHandler(NavigationManager manager)
    {
        _manager = manager;
        _base = new Uri(manager.BaseUri);
        Home = new (Text: "/", () => NavigateTo(Paths.Home));

        Items =
        [ 
            new (Text: "/solutions", () => NavigateTo(Paths.Solutions)),
            new (Text: "/consulting", () => NavigateTo(Paths.Consulting)),
            new (Text: "/about", () => NavigateTo(Paths.About)),
            new (Text: "/giving_back", () => NavigateTo(Paths.GivingBack)), 
        ];
    }

    public NavigationLinks[] Items = [];
    public NavigationLinks Home { get; }
    public bool IsHome 
        => _manager.Uri.Equals(_manager.BaseUri, StringComparison.OrdinalIgnoreCase);

    void NavigateTo(string path)
        => _manager.NavigateTo(path);

    public record NavigationLinks(string Text, Action OnClick);

    public static class Paths
    {
        public const string Home = "/";
        public const string Solutions = "/solutions";
        public const string Consulting = "/consulting";
        public const string About = "/about";
        public const string GivingBack = "/giving-back";
    }


}