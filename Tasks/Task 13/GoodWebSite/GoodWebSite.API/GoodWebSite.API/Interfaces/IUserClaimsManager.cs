using System.Security.Claims;
using GoodWebSite.DAL.Entities;

namespace GoodWebSite.Interfaces;

public interface IUserClaimsManager
{ 
    IEnumerable<Claim> GetUserClaims(User user);
}