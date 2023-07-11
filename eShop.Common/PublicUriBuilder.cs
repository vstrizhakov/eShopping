﻿using Microsoft.Extensions.Options;

namespace eShop.Common
{
    internal class PublicUriBuilder : IPublicUriBuilder
    {
        private readonly PublicUriConfiguration _configuration;

        public PublicUriBuilder(IOptions<PublicUriConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public string Path(string relativePath)
        {
            var uri = new Uri(_configuration.Host, relativePath);
            return uri.ToString();
        }
    }
}