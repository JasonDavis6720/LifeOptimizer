using LifeOptimizer.Application.Interfaces;


namespace LifeOptimizer.Infrastructure.Services
{
    public class StubUserContextService : IUserContextService
    {
        public string GetCurrentUserId()
        {
            // This is a stub implementation. In a real application, this method would return the ID of the currently authenticated user.
            return "stub-user-id";
        }
    }
}