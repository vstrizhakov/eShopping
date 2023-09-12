﻿using AutoMapper;
using eShop.Common.Extensions;
using eShop.Distribution.Models;
using eShop.Distribution.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Distribution.Controllers
{
    [Route("api/distribution/clients")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public ClientsController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var accountId = User.GetAccountId().Value;
            var clientAccounts = await _accountRepository.GetAccountsByProviderIdAsync(accountId);
            var clients = _mapper.Map<IEnumerable<Client>>(clientAccounts);
            return Ok(clients);
        }

        [HttpPost("{clientId}/activate")]
        public async Task<ActionResult<Client>> ActivateClient([FromRoute] Guid clientId)
        {
            var accountId = User.GetAccountId().Value;
            var clientAccount = await _accountRepository.GetAccountByIdAsync(clientId, accountId);
            if (clientAccount == null)
            {
                return NotFound();
            }

            await _accountRepository.UpdateIsActivatedAsync(clientAccount, true);

            var response = _mapper.Map<Client>(clientAccount);
            return Ok(response);
        }

        [HttpPost("{clientId}/deactivate")]
        public async Task<ActionResult<Client>> DeactivateClient([FromRoute] Guid clientId)
        {
            var accountId = User.GetAccountId().Value;
            var clientAccount = await _accountRepository.GetAccountByIdAsync(clientId, accountId);
            if (clientAccount == null)
            {
                return NotFound();
            }

            await _accountRepository.UpdateIsActivatedAsync(clientAccount, false);

            var response = _mapper.Map<Client>(clientAccount);
            return Ok(response);
        }
    }
}
