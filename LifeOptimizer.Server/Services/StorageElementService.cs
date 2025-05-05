using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Infrastructure.Data;

namespace LifeOptimizer.Server.Services
{
    public class StorageElementService : IStorageElementService
    {
        private readonly AppDbContext _context;
        private readonly IStorageElementRepository _StorageElementRepository;

        public StorageElementService(AppDbContext context, IStorageElementRepository StorageElementRepository)
        {
            _context = context;
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

            // Save the StorageElement
            _context.StorageElements.Add(storageElement);
            await _context.SaveChangesAsync();

            // Eagerly load the Room navigation property
            _context.Entry(storageElement).Reference(se => se.Room).Load();

            return storageElement;
        }

    }
}
