
using Informatics.MauiDbClientTest.Models;

using Informatics.MauiDbClientTest.Contexts;
using Informatics.MauiDbClientTest.ViewModel;
 // Add this line to import the necessary namespace
using Microsoft.Maui.Controls;


using Microsoft.Maui.Controls;


namespace Informatics.MauiDbClientTest.Pages;
public partial class PetsPage : ContentPage
{
public PetsPage(PetsViewModel viewModel)
{

InitializeComponent();
BindingContext = viewModel;
}
private void OnPetSelected(object sender, SelectionChangedEventArgs e)
{
var pet = e.CurrentSelection.FirstOrDefault() as Pet;
if (pet != null)
{
var viewModel = BindingContext as PetsViewModel;
viewModel?.OpenPetDetailsCommand.Execute(pet.PetId);
}
}
// Used to refresh the list of employees when the page appears
// This is necessary because the list of employees may change when the user navigates
// back to this page after editing an employee.
protected override void OnAppearing()
{
base.OnAppearing();
// Refresh the list every time the page appears
var viewModel = BindingContext as PetsViewModel;
viewModel?.RefreshCommand.Execute(null);
}
}
