using System.ComponentModel;
using System.Windows.Input;
using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest.Pages;
using Informatics.MauiDbClientTest.Services;



namespace Informatics.MauiDbClientTest.ViewModel
{
    public class OwnerDetailsViewModel : INotifyPropertyChanged
    {
        private readonly IOwnerService _ownerService;
        private Owner _owner;
        public Owner Owner
        {

            get => _owner;
            set

            {
                _owner = value;
                OnPropertyChanged(nameof(Owner));
            }
        }

        public string OwnerId { get; set; }

        public string OwnerName
        {
            get => Owner.OwnerName;
            set
            {
                if (Owner.OwnerName != value)
                {
                    Owner.OwnerName = value;
                    OnPropertyChanged(nameof(OwnerName));
                }
            }
        }

        public string OwnerPhoneNumber
        {
            get => Owner.OwnerPhoneNumber;
            set
            {
                if (Owner.OwnerPhoneNumber != value)
                {
                    Owner.OwnerPhoneNumber = value;
                    OnPropertyChanged(nameof(OwnerPhoneNumber));
                }
            }
        }

        public string OwnerEmail
        {
            get => Owner.OwnerEmail;
            set
            {
                if (Owner.OwnerEmail != value)
                {
                    Owner.OwnerEmail = value;
                    OnPropertyChanged(nameof(OwnerEmail));
                }
            }
        }

        public string OwnerAddress
        {
            get => Owner.OwnerAddress;
            set
            {
                if (Owner.OwnerAddress != value)
                {
                    Owner.OwnerAddress = value;
                    OnPropertyChanged(nameof(OwnerAddress));
                }
            }
        }
        public ICommand SaveOwnerCommand { get; private set; }
        public ICommand DeleteOwnerCommand { get; private set; }
        public ICommand UpdateOwnerCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public OwnerDetailsViewModel(IOwnerService ownerService)
        {
            _ownerService = ownerService;
            SaveOwnerCommand = new Command(SaveOwner);
            DeleteOwnerCommand = new Command(DeleteOwner);
            UpdateOwnerCommand = new Command(UpdateOwner);

        }

        public Action<string, string, string> DisplayAlertAction { get; set; }
        /* private async void SaveOwner()
        {
            await _ownerService.SaveOwnerAsync(Owner);
            Shell.Current.GoToAsync("..");
        } */

        private async void SaveOwner()
        {
            try
            {
                await _ownerService.SaveOwnerAsync(Owner);
                Shell.Current.GoToAsync("..");
            }
            catch (InvalidOperationException ex)
            {
                // Check if the exception message contains the specific detail about duplicate key
                if (ex.Message.Contains("another instance with the same key value for {'OwnerId'}"))
                {
                    DisplayAlertAction?.Invoke("Save Error", "An owner with the same ID already exists. Please use a unique ID.", "OK");
                    _ownerService.DetachEntity(Owner);
                }
                else
                {
                    DisplayAlertAction?.Invoke("Error", "An unexpected error occurred while saving the owner.", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlertAction?.Invoke("Error", "An unexpected error occurred.", "OK");
            }
        }




        private async void UpdateOwner()
        {
            try
            {
                // Attempt to update the owner...
                await _ownerService.UpdateOwnerAsync(Owner);
                Shell.Current.GoToAsync("..");
            }
            catch (System.InvalidOperationException ex)
            {
                DisplayAlertAction?.Invoke("Update Error", "Owner ID value is essential for maintaining consistent information in the system and should not be changed. Try adding a new Owner instead.", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlertAction?.Invoke("Error", "An unexpected error occurred.", "OK");
            }
        }



        private async void DeleteOwner()
        {
            await _ownerService.DeleteOwnerAsync(Owner.OwnerId);
            Shell.Current.GoToAsync("..");
        }

        private void OpenOwnerDetails(string ownerId)
        {
            var route = $"{nameof(OwnerDetailsPage)}?ownerId={ownerId}";
            Shell.Current.GoToAsync(route);
        }


        public async Task LoadOwnerAsync(string ownerId)
        {
            Owner = await _ownerService.GetOwnerAsync(ownerId);
            if (Owner == null)
            {
                Owner = new Owner();
                Owner.OwnerId = ownerId;
            }

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


