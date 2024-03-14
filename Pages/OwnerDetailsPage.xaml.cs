using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest.Contexts;
using Informatics.MauiDbClientTest.ViewModel;


namespace Informatics.MauiDbClientTest.Pages;

[QueryProperty(nameof(OwnerId), "ownerId")]

public partial class OwnerDetailsPage : ContentPage
{
    private string _ownerId;
    public string OwnerId
    {
        get => _ownerId;
        set
        {
            _ownerId = value;
            LoadOwner();
        }
    }

    public OwnerDetailsPage(OwnerDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        viewModel.DisplayAlertAction = (title, message, cancel) => DisplayAlert(title, message, cancel);
    }
    private void LoadOwner()
    {
        (BindingContext as OwnerDetailsViewModel)?.LoadOwnerAsync(_ownerId);
    }
    
}