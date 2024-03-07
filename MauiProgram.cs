using Microsoft.Extensions.Logging;
using System.Reflection;
using Informatics.MauiDbClientTest.Contexts;
 using Informatics.MauiDbClientTest.Pages;
using Informatics.MauiDbClientTest.Services;
using Informatics.MauiDbClientTest.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


using Informatics.MauiDbClientTest.Models;




namespace Informatics.MauiDbClientTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		var assembly = Assembly.GetExecutingAssembly();
string appsettingsFileName = "Informatics.MauiDbClientTest.appsettings.json";
using (var stream = assembly.GetManifestResourceStream(appsettingsFileName))
{
if (stream != null)
{
builder.Configuration.AddJsonStream(stream);
}
}
builder.Services.AddDbContext<UniversityContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("PawsitivelyFunDaycareDatabase")
)

);
builder.Services.AddTransient<IPetService, PetService>();
builder.Services.AddTransient<IOwnerService, OwnerService>();
builder.Services.AddTransient<PetsDetailsViewModel>();
builder.Services.AddTransient<OwnerViewModel>();
builder.Services.AddTransient<OwnerDetailsViewModel>();
builder.Services.AddTransient<PetsViewModel>();
builder.Services.AddSingleton<PetsPage>();
builder.Services.AddSingleton<PetsDetailsPage>();
builder.Services.AddSingleton<OwnersPage>();
builder.Services.AddSingleton<OwnerDetailsPage>();




#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}



}
