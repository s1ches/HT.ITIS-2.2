using GoodWebSite.DAL.Entities;

namespace GoodWebSite.Interfaces;

public interface ISignInManager
{
    bool TryPasswordSignIn(User user, string password, bool isPersistent);
}