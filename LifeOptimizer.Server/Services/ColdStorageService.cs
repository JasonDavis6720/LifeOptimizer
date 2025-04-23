using System;
using System.Collections.Generic;
using LifeOptimizer.Server.Models;

namespace LifeOptimizer.Server.Services
{
    public class ColdStorageService
    {
        public void ValidateColdStorage(ColdStorage coldStorage)
        {
            if (coldStorage.Type == "Freezer")
            {
                if (coldStorage.IsFrostFree == null)
                {
                    throw new ArgumentException("IsFrostFree is required for freezers.");
                }

                if (coldStorage.LastDefrosted == default)
                {
                    throw new ArgumentException("LastDefrosted is required for freezers.");
                }
            }
        }

        public ColdStorage CreateColdStorage(string name, string type, bool? isFrostFree, DateTime? lastDefrosted, int roomId, int dwellingId)
        {
            var coldStorage = new ColdStorage
            {
                Name = name,
                Type = type,
                IsFrostFree = isFrostFree ?? false,
                LastDefrosted = lastDefrosted ?? DateTime.MinValue,
                RoomId = roomId,
                DwellingId = dwellingId
            };

            // Validate the cold storage object
            ValidateColdStorage(coldStorage);

            return coldStorage;
        }

        public void UpdateColdStorage(ColdStorage coldStorage, string type, bool? isFrostFree, DateTime? lastDefrosted)
        {
            coldStorage.Type = type;
            coldStorage.IsFrostFree = isFrostFree;
            coldStorage.LastDefrosted = lastDefrosted ?? coldStorage.LastDefrosted;

            // Validate the updated cold storage object
            ValidateColdStorage(coldStorage);
        }
    }
}
