using Informatics.MauiDbClientTest.Models;
using Microsoft.Maui.Controls;
using Informatics.MauiDbClientTest.ViewModel;
using Informatics.MauiDbClientTest.Contexts;
using Microsoft.Maui.Controls;

namespace Informatics.MauiDbClientTest.Pages;

[QueryProperty(nameof(PetId), "petId")]
public partial class PetsDetailsPage : ContentPage
{
    private string _petId = string.Empty;
    public string PetId
    {
        get => _petId;
        set
        {
            _petId = value;
            LoadPet();
        }
    }
    public PetsDetailsPage(PetsDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        LoadOwners();

    }

    private void LoadOwners()
    {
        ((PetsDetailsViewModel)BindingContext).LoadOwners();
    }

    private void LoadPet()
    {
        (BindingContext as PetsDetailsViewModel)?.LoadPetAsync(_petId);

        //((PetsDetailsViewModel)BindingContext).LoadOwners();

    } 
}


