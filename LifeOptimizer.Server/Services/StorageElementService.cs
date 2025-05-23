﻿using AutoMapper;
using LifeOptimizer.Application.Dtos;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Infrastructure.Data;

namespace LifeOptimizer.Server.Services
{
    public class StorageElementService : IStorageElementService
    {
        private readonly AppDbContext _context;
        private readonly IStorageElementRepository _storageElementRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _user;

        public StorageElementService(AppDbContext context, IStorageElementRepository storageElementRepository, IMapper mapper, IUserContextService user)
        {
            _context = context;
            _storageElementRepository = storageElementRepository;
            _mapper = mapper;
            _user = user;

        }

        public async Task<StorageElementReturnDto> CreateStorageElementByIdAsync(CreateStorageElementDto storageElementDto)
        {
            // Convert DTO to domain entity
            var userId = _user.GetCurrentUserId();
            var element = _mapper.Map<StorageElement>(storageElementDto);
            element.UserId = userId;

            var savedElement = await _storageElementRepository.CreateStorageElementAsync(element);

            return _mapper.Map<StorageElementReturnDto>(savedElement);
        }

    }
}
