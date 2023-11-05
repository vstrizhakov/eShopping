﻿using AutoMapper;
using eShop.Catalog.Models.Announces;
using eShop.Catalog.Services;
using eShop.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace eShop.Catalog.Hubs
{
    [Authorize]
    public class AnnouncesHub : Hub<IAnnouncesHubClient>
    {
        private readonly IAnnouncesService _announcesService;
        private readonly IMapper _mapper;

        public AnnouncesHub(IAnnouncesService announcesService, IMapper mapper)
        {
            _announcesService = announcesService;
            _mapper = mapper;
        }

        public async Task Subscribe(SubscribeToAnnounceRequest request)
        {
            var announceId = request.AnnounceId;

            var userId = Context.User.GetAccountId();
            var announce = await _announcesService.GetAnnounceAsync(announceId);
            if (announce == null || announce.OwnerId != userId)
            {
                throw new InvalidOperationException("The specified announce doesn't exist.");
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, announceId.ToString());

            var mappedAnnounce = _mapper.Map<Announce>(announce);
            await Clients.Caller.AnnounceUpdated(mappedAnnounce);
        }

        public async Task Unsubscribe(UnsubscribeFromAnnounceRequest request)
        {
            var announceId = request.AnnounceId;

            var userId = Context.User.GetAccountId();
            var announce = await _announcesService.GetAnnounceAsync(announceId);
            if (announce == null || announce.OwnerId != userId)
            {
                throw new InvalidOperationException("The specified announce doesn't exist.");
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, announceId.ToString());
        }
    }
}