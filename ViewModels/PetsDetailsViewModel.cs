using System.ComponentModel;
using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest;
using Informatics.MauiDbClientTest.Services;
using Informatics.MauiDbClientTest.Contexts;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Informatics.MauiDbClientTest.Pages;


namespace Informatics.MauiDbClientTest.ViewModel
{
    public class PetsDetailsViewModel : INotifyPropertyChanged
    {
        private Pet _pet;
        private readonly IPetService _petService;

        // added readonly

        private  IOwnerService _ownerService;
        private ObservableCollection<Owner> _owners;

        public Pet Pet
        {
            get => _pet;
            set
            {
                _pet = value;
                OnPropertyChanged(nameof(Pet));
            }
        }

        public ObservableCollection<Owner> Owners
        {
            get => _owners;
            set
            {
                _owners = value;
                OnPropertyChanged(nameof(Owners));
            }
        }

        public ICommand SavePetCommand { get; private set; }
        public ICommand DeletePetCommand { get; private set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public PetsDetailsViewModel(IPetService petService, IOwnerService ownerService)
        {
            _petService = petService;
            _ownerService = ownerService;
            _owners = new ObservableCollection<Owner>();
            SavePetCommand = new Command(SavePet);
            DeletePetCommand = new Command(DeletePet);
        }

        public async Task LoadPetAsync(string petId)
        {
            Pet = await _petService.GetPetAsync(petId);
            
            if (Pet == null)
            {
                Pet = new Pet();
                Pet.PetId = petId;
            }
        }
        

        private async void SavePet()
        {
            await _petService.SavePetAsync(Pet);
            Shell.Current.GoToAsync("..");

        }
        


        private async void DeletePet()
        {
            await _petService.DeletePetAsync(Pet.PetId);
            Shell.Current.GoToAsync("..");
        }

        private void OpenPetDetails(string petId)
{
var route = $"{nameof(PetsDetailsPage)}?petId={petId}";
Shell.Current.GoToAsync(route);
}

        public async void LoadOwners()
        {
            var owners = await _ownerService.GetOwnersAsync();
            Owners = new ObservableCollection<Owner>(owners);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}




