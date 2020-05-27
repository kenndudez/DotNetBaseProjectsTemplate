using System;

namespace DOTNET.BaseProjectTemplate.Core.Configuration
{
    public class OpenIddictServerConfig
    {
        public string SecretKey { get; set; }
        public string Authority { get; set; }
        public bool RequireHttps { get; set; }
    }

    public class ActiveDirectoryConfig
    {
        public bool AllowADLogin { get; set; }
        public string AppId { get; set; }
        public string BaseUrl { get; set; }
        public bool AuthenticateAPI { get; set; }
        public string ApiUser { get; set; }
        public string ApiPassword { get; set; }

        public static string Authenticate() => "/api/Service/AuthenticateUser";
    }
}
