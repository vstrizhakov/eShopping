﻿using eShopping.Catalog.Entities;

namespace eShopping.Catalog.Repositories
{
    public interface IAnnounceRepository
    {
        Task<IEnumerable<Announce>> GetAnnouncesAsync(Guid ownerId);
        Task<Announce?> GetAnnounceAsync(Guid id, Guid ownerId);
        Task CreateAnnounceAsync(Announce announce);
        Task DeleteAnnounceAsync(Announce announce);
        Task UpdateAnnounceAsync(Announce announce);
    }
}
