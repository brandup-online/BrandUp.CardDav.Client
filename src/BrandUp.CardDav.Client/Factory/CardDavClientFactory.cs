﻿using BrandUp.Carddav.Client.Client;
using BrandUp.Carddav.Client.Options;
using Microsoft.Extensions.Logging;

namespace BrandUp.Carddav.Client.Factory
{
    public class CardDavClientFactory : ICardDavClientFactory
    {
        readonly IHttpClientFactory httpClientFactory;
        readonly ILogger<CardDavClient> logger;

        public CardDavClientFactory(IHttpClientFactory httpClientFactory, ILogger<CardDavClient> logger)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region ICardDavClientFactory

        public CardDavClient CreateClient(CardDavOptions options)
        {
            var client = httpClientFactory.CreateClient();

            return new CardDavClient(client, logger, options);
        }

        #endregion
    }

    public interface ICardDavClientFactory
    {
        CardDavClient CreateClient(CardDavOptions options);
    }
}
