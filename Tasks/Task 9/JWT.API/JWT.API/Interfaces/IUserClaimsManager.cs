using System.Security.Claims;
using JWT.API.DAL.Entities;

namespace JWT.API.Interfaces;

public interface IUserClaimsManager
{
    public List<Claim> GetUserClaims(User user);
}