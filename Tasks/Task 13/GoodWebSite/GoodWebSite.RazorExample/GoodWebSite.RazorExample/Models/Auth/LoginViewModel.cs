﻿namespace GoodWebSite.RazorExample.Models.Auth;

public class LoginViewModel
{
    public string UserName { get; set; }

    public string Password { get; set; }
    
    public bool IsPersistent { get; set; }
}