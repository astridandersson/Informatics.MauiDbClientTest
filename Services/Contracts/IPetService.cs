using Informatics.MauiDbClientTest.Models;



namespace Informatics.MauiDbClientTest;

public interface IPetService
{
Task<IEnumerable<Pet>> GetPetsAsync();
Task<Pet> GetPetAsync(string PetId);
Task<Pet> SavePetAsync(Pet pet);
Task<Pet> UpdatePetAsync(Pet pet);
Task<Pet> DeletePetAsync(string PetId);



}


