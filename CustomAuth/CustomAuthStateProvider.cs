using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomAuth
{
    public class MyAuthenticationStateProvider : AuthenticationStateProvider
    {        
        private bool IsAuthenticated { get; set; }
        private string userName { get; set; }
        public void setAuthentication(string _userName)
        {
            IsAuthenticated = !string.IsNullOrEmpty(_userName);
            userName = _userName;                 
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;

            if (IsAuthenticated)
            {
                identity = new ClaimsIdentity(new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,userName)

                        }, "CustomAuth");
            }
            else
            {
                identity = new ClaimsIdentity();
            }           
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
        
    }
}

