using System.Security.Claims;
using E.SUNBankDotNet.Domains;
using Microsoft.AspNetCore.Mvc;

namespace E.SUNBankDotNet.Controllers;

public class BaseController : Controller
{
    protected Customer GetCustomer()
    {
        var userId = User.FindFirstValue(ClaimTypes.Name);
        var email = User.FindFirstValue(ClaimTypes.Email);

        if (userId != null && email != null)
        {
            return new Customer
            {
                UserID = userId,
                Email = email,
            };
        }
        
        return new Customer();
    }
}