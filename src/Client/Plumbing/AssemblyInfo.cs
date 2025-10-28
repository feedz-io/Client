using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Feedz.IntegrationTests")]
[assembly: InternalsVisibleTo("Feedz.Client.Tests")]

// Fix to make init fields work
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}