using Informatics.MauiDbClientTest.Models;


namespace Informatics.MauiDbClientTest;

public interface IOwnerService
{
    Task<IEnumerable<Owner>> GetOwnersAsync();
    Task<Owner> GetOwnerAsync(string OwnerId);
    Task<Owner> SaveOwnerAsync(Owner owner);
    Task<Owner> UpdateOwnerAsync(Owner owner);
    Task<Owner> DeleteOwnerAsync(string OwnerId);



}
