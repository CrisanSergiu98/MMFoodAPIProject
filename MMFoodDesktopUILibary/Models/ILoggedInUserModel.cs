using System;

namespace MMFoodDesktopUILibary.Models
{
    public interface ILoggedInUserModel
    {
        DateTime CreateDate { get; set; }
        string Email { get; set; }
        string Id { get; set; }
        string Token { get; set; }
        string Username { get; set; }
    }
}