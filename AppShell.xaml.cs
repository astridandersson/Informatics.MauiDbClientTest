
using Microsoft.EntityFrameworkCore;

using Informatics.MauiDbClientTest.Pages;


namespace Informatics.MauiDbClientTest;
public partial class AppShell : Shell
{
public AppShell()
{
InitializeComponent();
Routing.RegisterRoute(nameof(PetsDetailsPage), typeof(PetsDetailsPage));
Routing.RegisterRoute(nameof(OwnerDetailsPage), typeof(OwnerDetailsPage));
}
}
