using System.ComponentModel;
using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest;
using Informatics.MauiDbClientTest.Services;
using Informatics.MauiDbClientTest.Contexts;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Informatics.MauiDbClientTest.Pages;
using AVFoundation;

namespace Informatics.MauiDbClientTest.ViewModel
{
    public class PetsDetailsViewModel : INotifyPropertyChanged
    {
        private Pet _pet;
        private readonly IPetService _petService;

        // added readonly

        private IOwnerService _ownerService;
        private ObservableCollection<Owner> _owners;

        private Owner _selectedOwner;

        private string _petId;
        private string _petName;
        private string _petBreed;
        private int _petAge;
        private string _ownerId;

        public Owner SelectedOwner
        {
            get => _selectedOwner;
            set
            {
                if (_selectedOwner != value)
                {
                    _selectedOwner = value;
                    OnPropertyChanged(nameof(SelectedOwner));

                    if (Pet != null && value != null)
                    {
                        Pet.Owner = value;
                        OwnerId = value.OwnerId;
                    }

                    OnPropertyChanged(nameof(Pet));
                }
            }
        }

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

        public string PetName
        {
            get => Pet.PetName;
            set
            {
                if (Pet.PetName != value)
                {
                    Pet.PetName = value;
                    OnPropertyChanged(nameof(PetName));
                }
            }
        }

        public string PetBreed
        {
            get => Pet.PetBreed;
            set
            {
                if (Pet.PetBreed != value)
                {
                    Pet.PetBreed = value;
                    OnPropertyChanged(nameof(PetBreed));
                }
            }
        }

        public int PetAge
        {
            get => Pet.PetAge;
            set
            {
                if (Pet.PetAge != value)
                {
                    Pet.PetAge = value;
                    OnPropertyChanged(nameof(PetAge));
                }
            }
        }

        public string OwnerId
        {
            get => Pet.Owner.OwnerId;
            set
            {
                if (Pet.Owner.OwnerId != value)
                {
                    Pet.Owner.OwnerId = value;
                    OnPropertyChanged(nameof(OwnerId));
                }
            }
        }

        public ICommand SavePetCommand { get; private set; }
        public ICommand DeletePetCommand { get; private set; }
        public ICommand UpdatePetCommand { get; private set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public PetsDetailsViewModel(IPetService petService, IOwnerService ownerService)
        {
            _pet = new Pet();
            _petService = petService;
            _ownerService = ownerService;
            _owners = new ObservableCollection<Owner>();
            SavePetCommand = new Command(SavePet);
            DeletePetCommand = new Command(DeletePet);
            UpdatePetCommand = new Command(async () => UpdatePet());
        }

        private async Task UpdatePet()
        {
            if (!string.IsNullOrEmpty(Pet.PetId) && Pet.PetAge > 2)
            {
                await _petService.UpdatePetAsync(Pet);
            } else {
                await Application.Current.MainPage.DisplayAlert("Error", "PetId is empty or pet age is less than 2.", "OK");
                

            }
           await Shell.Current.GoToAsync("..");

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
            if (!string.IsNullOrEmpty(Pet.PetId) && Pet.PetAge > 2)
            {
                await _petService.SavePetAsync(Pet);

            } else {
            await Application.Current.MainPage.DisplayAlert("Error", "PetId is empty or pet age is less than 2.", "OK");

            }
            Shell.Current.GoToAsync("..");
        }
    




        private async void DeletePet()
        {
            await _petService.DeletePetAsync(Pet.PetId);
            await Shell.Current.GoToAsync("..");
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