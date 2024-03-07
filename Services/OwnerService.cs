﻿using Informatics.MauiDbClientTest.Contexts;
using Informatics.MauiDbClientTest.Models;


using Microsoft.EntityFrameworkCore;
namespace Informatics.MauiDbClientTest.Services;

public class OwnerService : IOwnerService
{
    private UniversityContext _context;
    public OwnerService(UniversityContext context)
    {
        _context = context;
    }
    
    public async Task<Owner> SaveOwnerAsync(Owner owner)
    {
        _context.Owners.Add(owner);
        await _context.SaveChangesAsync();
        return owner;


    }
    public async Task<Owner> DeleteOwnerAsync(string ownerId)
    {
        var owner = await _context.Owners.FindAsync(ownerId);
        if (owner == null)
        {
            return null;
        }
        _context.Owners.Remove(owner);
        await _context.SaveChangesAsync();
        return owner;
    }
    
    public async Task<Owner> GetOwnerAsync(string ownerId)
    {
        return await _context.Owners.FindAsync(ownerId);

    }
    
    public async Task<IEnumerable<Owner>> GetOwnersAsync()
    {
        return await _context.Owners.ToListAsync();
    }
    public async Task<Owner> UpdateOwnerAsync(Owner owner)
    {
        _context.Entry(owner).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return owner;
    }

}

