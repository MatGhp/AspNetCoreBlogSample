using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace AspNetCoreBlogSample.Hubs
{
    public class PostHub : Hub
    {
        public static void FetchPost()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PostHub>();
            context.Clients.All.displayPost();
        }
    }
}
