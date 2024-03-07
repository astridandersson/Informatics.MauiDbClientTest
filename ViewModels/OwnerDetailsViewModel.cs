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
public Owner Owner {

get => _owner;
set

{
_owner = value;
OnPropertyChanged(nameof(Owner));
}
}
public ICommand SaveOwnerCommand { get; private set; }
public ICommand DeleteOwnerCommand { get; private set; }

public event PropertyChangedEventHandler? PropertyChanged;
public OwnerDetailsViewModel(IOwnerService ownerService)
{
_ownerService = ownerService;
SaveOwnerCommand = new Command(SaveOwner);
DeleteOwnerCommand = new Command(DeleteOwner);

}


private async void SaveOwner()
{
await _ownerService.SaveOwnerAsync(Owner);
Shell.Current.GoToAsync("..");
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

// public async Task LoadOwnerAsync(string ownerId)
// {
// Owner = await _ownerService.GetOwnerAsync(ownerId);
// }

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


