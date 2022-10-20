using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class UserFactory
    {
        public static User ToIdentityUser(UserViewModel registerViewModel)
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

        internal static UserViewModel ToViewModel(User user, string role)
        {
            return new UserViewModel
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = role,
            };
        }
    }
}
