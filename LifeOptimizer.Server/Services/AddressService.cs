using LifeOptimizer.Server.Data;
using Microsoft.EntityFrameworkCore;

public class AddressService : IAddressService
{
    private readonly ApplicationDbContext _context;

    public AddressService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Address>> GetAllAddressesAsync()
    {
        return await _context.Address.ToListAsync();
    }

    public async Task<Address> GetAddressByIdAsync(int id)
    {
        return await _context.Address.FindAsync(id);
    }

    public async Task<Address> CreateAddressAsync(Address address)
    {
        _context.Address.Add(address);
        await _context.SaveChangesAsync();
        return address;
    }
}

