using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class UserFactory
    {
        public static User ToIdentityUser(RegisterViewModel registerViewModel)
        {
            return new User
            {
                UserName = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                PhoneNumber = registerViewModel.PhoneNumber,
                Email = registerViewModel.Email,
                EmailConfirmed = true
            };
        }
    }
}
