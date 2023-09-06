﻿using eShop.Distribution.Exceptions;
using eShop.Distribution.MessageHandlers;
using eShop.Distribution.Services;
using eShop.Messaging.Models;

namespace eShop.Distribution.Tests.MessageHandlers
{
    public class ViberUserCreateAccountUpdateMessageHandlerShould
    {
        [Fact]
        public async Task CreateNewAccount()
        {
            // Arrange

            var message = new ViberUserCreateAccountUpdateMessage
            {
                IsSuccess = true,
                AccountId = Guid.NewGuid(),
                ProviderId = Guid.NewGuid(),
            };

            var accountService = new Mock<IAccountService>();
            accountService
                .Setup(e => e.CreateNewAccountAsync(message.AccountId.Value, message.ProviderId.Value))
                .Returns(Task.CompletedTask);

            var sut = new ViberUserCreateAccountUpdateMessageHandler(accountService.Object);

            // Act

            await sut.HandleMessageAsync(message);

            // Assert

            accountService.VerifyAll();
        }

        [Fact]
        public async Task HandleAccountAlreadyExistsException()
        {
            // Arrange

            var message = new ViberUserCreateAccountUpdateMessage
            {
                IsSuccess = true,
                AccountId = Guid.NewGuid(),
                ProviderId = Guid.NewGuid(),
            };

            var accountService = new Mock<IAccountService>();
            accountService
                .Setup(e => e.CreateNewAccountAsync(message.AccountId.Value, message.ProviderId.Value))
                .ThrowsAsync(new AccountAlreadyExistsException());

            var sut = new ViberUserCreateAccountUpdateMessageHandler(accountService.Object);

            // Act

            await sut.HandleMessageAsync(message);

            // Assert

            accountService.VerifyAll();
        }
    }
}