﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuth.Providers
{
	public abstract class AmazonApi : OAuthApi
	{
		public AmazonApi(string identifier, string clientId, string clientSecret, HttpMessageHandler handler = null) : base(identifier, clientId, clientSecret, handler)
		{
			TokenUrl = "https://api.amazon.com/auth/o2/token";
		}


		protected override Authenticator CreateAuthenticator(string[] scope)
		{
			return new AmazonAuthenticator
			{
				Scope = scope.ToList(),
				ClientId = ClientId,
			};
		}
	}

	public class AmazonAuthenticator : Authenticator
	{
		public override string BaseUrl { get; set; } = "https://www.amazon.com/ap/oa?";
		public override Uri RedirectUrl { get; set; } = new Uri("http://localhost");
		public override async Task<Dictionary<string, string>> GetTokenPostData(string clientSecret)
		{
			var data = await base.GetTokenPostData(clientSecret);
			data["redirect_uri"] = RedirectUrl.AbsoluteUri;
			return data;
		}
	}
}
