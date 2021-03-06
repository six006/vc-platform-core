using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using VirtoCommerce.Platform.Core.Modularity;

namespace VirtoCommerce.Platform.Modules.External
{
    public class ExternalModulesClient : IExternalModulesClient
    {
        private readonly ExternalModuleCatalogOptions _options;
        public ExternalModulesClient(IOptions<ExternalModuleCatalogOptions> options)
        {
            _options = options.Value;
        }

        public Stream OpenRead(Uri address)
        {
            var webClient = new WebClient();
            if (!string.IsNullOrEmpty(_options.AuthorizationToken))
            {
                webClient.Headers["User-Agent"] = "Virto Commerce Manager";
                webClient.Headers["Accept"] = "application/octet-stream";
                webClient.Headers["Authorization"] = "token " + _options.AuthorizationToken;
            }
            return webClient.OpenRead(address);
        }
    }
}
