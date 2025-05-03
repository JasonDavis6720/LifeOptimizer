//using LifeOptimizer.Server.Data;
//using LifeOptimizer.Server.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//public class UserService : IUserService
//{
//    private readonly ApplicationDbContext _context;

//    public UserService(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<IEnumerable<User>> GetAllUsersAsync()
//    {
//        return await _context.Users.ToListAsync(); // Return all users directly
//    }


//    public async Task<User> GetUserByIdAsync(string id)
//    {
//        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
//        return user;
//    }

//    public async Task<User> CreateUserAsync(User user, string password)
//    {
//        var passwordHasher = new PasswordHasher<User>();
//        user.PasswordHash = passwordHasher.HashPassword(user, password);

//        _context.Users.Add(user);
//        await _context.SaveChangesAsync();
//        return user;
//    }
//}
