using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dropbox.Api;
using Microsoft.AspNetCore.Authorization;

namespace WorkOnlineDropbox.Controllers
{
    public class HomeController : Controller
    {
        private const string appId = "ob52ze9qj8ie7mo";
        private const string appSecret = "xq6j5gfne6f0c0u";
        private const string token = "paA3u5DURtAAAAAAAAAAC8xrqihjihw0nto5nT_8v6zU-zqQEyDZxPfhVF7GlP2A";
        private string oauth2State;
        public string AccessToken { get; private set; }
        public string UserId { get; private set; }
        public bool Result { get; private set; }
        private const string RedirectUri = "http://localhost:55448/Home/Authorized";

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Authorized()
        {
            var consumerKey = "your api key";
            var consumerSecret = "your api secret";

            var uri = new Uri("https://api.dropbox.com/1/oauth/request_token");

            var client = new DropboxClient(token, new DropboxClientConfig("SimpleBlogDemo"));

            var test = await client.Files.ListFolderAsync("");

            await client.Files.CreateFolderAsync("/test");
            var test2 = await client.Files.ListFolderAsync("");

            return View();
        }


        public IActionResult DropboxAuth()
        {
            this.oauth2State = Guid.NewGuid().ToString("N");
            Uri authorizeUri = DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Token, appId, new Uri(RedirectUri), state: oauth2State);
            return Redirect(authorizeUri.ToString());
        }
    }
}
