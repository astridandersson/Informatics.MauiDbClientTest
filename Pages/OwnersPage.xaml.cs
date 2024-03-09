using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest.ViewModel;

namespace Informatics.MauiDbClientTest.Pages;
public partial class OwnersPage : ContentPage
{
	public OwnersPage(OwnerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	private void OnOwnerSelected(object sender, SelectionChangedEventArgs e)
	{
		var owner = e.CurrentSelection.FirstOrDefault() as Owner;
		if (owner != null)
		{
			var viewModel = BindingContext as OwnerViewModel;
			viewModel?.OpenOwnerDetailsCommand.Execute(owner.OwnerId);
		}
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		// Refresh the list every time the page appears
		var viewModel = BindingContext as OwnerViewModel;
		viewModel?.RefreshCommand.Execute(null);
	}
}
