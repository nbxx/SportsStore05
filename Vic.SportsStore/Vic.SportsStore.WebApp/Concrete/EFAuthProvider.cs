using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.WebApp.Abstract;

namespace Vic.SportsStore.WebApp.Concrete
{
    public class EFAuthProvider : IAuthProvider
    {
        public EFDbContext Context { get; set; }

        public bool Authenticate(string username, string password)
        {
            var result = false;

            var adminUser = Context
                .AdminUsers
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (adminUser != null)
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