using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;

namespace LifeOptimizer.Server.Services
{
    public class StorageElementService : IStorageElementService
    {
        private readonly IStorageElementRepository _StorageElementRepository;

        public StorageElementService(IStorageElementRepository StorageElementRepository)
        {
            _StorageElementRepository = StorageElementRepository;
        }

        public async Task<StorageElement> CreateStorageElementAsync(StorageElementDto storageElementDto)
        {
            // Convert DTO to domain entity
            var storageElement = new StorageElement
            {
                Name = storageElementDto.Name,
                Type = storageElementDto.Type,
                ParentId = storageElementDto.ParentId,
                RoomId = storageElementDto.RoomId
            };

            // Add any additional business logic here (e.g., validation)

            // Pass the domain entity to the repository
            return await _StorageElementRepository.AddStorageElementAsync(storageElement);
        }

    }
}
