using System.Resources;

namespace MauiApp1;

public static class Resources
{
    public static ResourceManager Strings { get; } = new ResourceManager("MauiApp1.Resources.Strings", typeof(Resources).Assembly);
}