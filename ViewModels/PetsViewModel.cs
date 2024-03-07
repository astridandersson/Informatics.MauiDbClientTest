using System.Windows.Input;
using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest.Services;
using Informatics.MauiDbClientTest.Pages;
using System.Collections.ObjectModel;


namespace Informatics.MauiDbClientTest.ViewModel
{
public class PetsViewModel
{
private readonly IPetService _petService;
public ObservableCollection<Pet> Pets { get; set; }

public ICommand OpenAddPetCommand { get; private set; }

public ICommand OpenPetDetailsCommand { get; private set; }

public ICommand RefreshCommand { get; private set; }


public PetsViewModel(IPetService petService)
{
_petService = petService;
Pets = new ObservableCollection<Pet>();
OpenAddPetCommand = new Command(OpenAddPet);
OpenPetDetailsCommand = new Command<string>(OpenPetDetails);
RefreshCommand = new Command(async () => await LoadPetsAsync());

}
private void OpenAddPet()
{

OpenPetDetails(string.Empty);

}
private void OpenPetDetails(string PetId)
{
var route = $"{nameof(PetsDetailsPage)}?petId={PetId}";
Shell.Current.GoToAsync(route);
}

private async Task LoadPetsAsync()
{
   
        var pets = await _petService.GetPetsAsync();

        Pets.Clear();

        foreach (var pet in pets)
        {
            Pets.Add(pet);
        }
    
}
    
}

}

