using System.Security.Claims;
using GoodWebSite.RazorExample.DAL.Entities;

namespace GoodWebSite.RazorExample.Interfaces;

public interface IUserClaimsManager
{ 
    IEnumerable<Claim> GetUserClaims(User user);
}