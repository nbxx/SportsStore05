using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.WebApp.Abstract;

namespace Vic.SportsStore.WebApp.Concrete
{
    public class InMemoryAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            var result = false;

            if (username == "abc" && password == "def")
            {
                result = true;
            }

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}