using GoodWebSite.RazorExample.DAL.Entities;

namespace GoodWebSite.RazorExample.Interfaces;

public interface ISignInManager
{
    bool TryPasswordSignIn(User user, string password, bool isPersistent);
}