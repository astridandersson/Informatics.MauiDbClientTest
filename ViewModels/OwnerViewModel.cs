using System.Collections.ObjectModel;
using System.Windows.Input;
using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest.Pages;
using Informatics.MauiDbClientTest.Services;



namespace Informatics.MauiDbClientTest.ViewModel
{
    public class OwnerViewModel
    {
        private readonly IOwnerService _ownerService;
        public ObservableCollection<Owner> Owners { get; set; }
        public ICommand OpenAddOwnerCommand { get; private set; }
        public ICommand OpenOwnerDetailsCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        

        public OwnerViewModel(IOwnerService ownerService)
        {
            _ownerService = ownerService;
            Owners = new ObservableCollection<Owner>();
            OpenAddOwnerCommand = new Command(OpenAddOwner);
            OpenOwnerDetailsCommand = new Command<string>(OpenOwnerDetails);
            RefreshCommand = new Command(async () => await LoadOwnersAsync());
        }

        private void OpenAddOwner()
        {
            OpenOwnerDetails(string.Empty);
        }

        private void OpenOwnerDetails(string OwnerId)
        {
            var route = $"{nameof(OwnerDetailsPage)}?ownerId={OwnerId}";
            Shell.Current.GoToAsync(route);
        }

        private async Task LoadOwnersAsync()
        {
            var owners = await _ownerService.GetOwnersAsync();
            Owners.Clear();
            foreach (var owner in owners)
            {
                Owners.Add(owner);
            }
        }
    }
}





