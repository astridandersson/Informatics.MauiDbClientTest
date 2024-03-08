using Informatics.MauiDbClientTest.Contexts;
using Informatics.MauiDbClientTest.Models;
using Informatics.MauiDbClientTest.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // Add this using directive
using System.Threading.Tasks; // Add this using directive



namespace Informatics.MauiDbClientTest.Services;

public class PetService : IPetService

{
    private UniversityContext _context;
    public PetService(UniversityContext context)
    {
        _context = context;
    }


//    public async Task<Pet> SavePetAsync(Pet pet)
//     {
    
//         // Check if the pet is a dog and its age is less than 1 year
//         if (pet.PetAge < 1)
//         {
//             // You may choose to handle this situation, e.g., throw an exception or return null
//             throw new InvalidOperationException("Dogs must be at least 1 year old.");
//         }

//      //   If the check passes, proceed to add the pet
//         _context.Pets.Add(pet);
//         await _context.SaveChangesAsync();
//         return pet;
//     }

    public async Task<Pet> DeletePetAsync(string petId)
    {
        var pet = await _context.Pets.FindAsync(petId);

        if (pet == null)
        {
            return null;
        }
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> GetPetAsync(string petId)
    {
        return await _context.Pets.FindAsync(petId);
    }
    public async Task<IEnumerable<Pet>> GetPetsAsync()
    {
        return await _context.Pets.ToListAsync();
    }
    
    public async Task<Pet> UpdatePetAsync(Pet pet)
    {
        _context.Entry(pet).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return pet;
    }
    
public async Task<Pet> SavePetAsync(Pet pet)
{
// Set the DepartmentName property to the Department.Name value
pet.OwnerId = pet.Owner.OwnerId;
// Set the Department property to null to avoid PK violation
pet.Owner = null;
// if -1 then add new employee


_context.Entry(pet).State = EntityState.Modified;

await _context.SaveChangesAsync();
return pet;
}
}







