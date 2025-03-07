using Application.Contracts;
using Application.Dots;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace UI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<UserResultDTO> RegisterAsync(UserDTO registerDTO)
        {
            try
            {
                if (registerDTO.Password != registerDTO.ConfirmPassword)
                {
                    return new UserResultDTO { Success = false, Errors = new[] { "Password and Confirm Password do not match" } };
                }

                var user = new ApplicationUser { UserName = registerDTO.Email, Email = registerDTO.Email };


                var result = _userManager.CreateAsync(user, registerDTO.Password);

                if (result.Result.Succeeded)
                {
                    return new UserResultDTO { Success = true };
                }
                return new UserResultDTO
                { 
                    Success = false, 
                    Errors = result.Result.Errors.Select(e => e.Description) 
                };
            }
            catch (Exception ex) 
            {
                return new UserResultDTO
                {
                    Success = false,
                    Errors = new[] { ex.Message }
                };
            }
        }
        public async Task<UserResultDTO> LoginAsync(UserDTO loginDTO)
        {
            var result = _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);
            try
            {
                if (result.Result.Succeeded)
                {
                    return new UserResultDTO { Success = true };
                }
                return new UserResultDTO
                {
                    Success = false,
                    Errors = new[] { "Invalid login attempt" }
                };
            }
            catch (Exception ex)
            {
                return new UserResultDTO
                {
                    Success = false,
                    Errors = new[] { ex.Message }
                };
            }

        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        
        }
        public async Task<UserDTO > GetUserByIdAsync(int userId)
        {
            var user = _userManager.FindByIdAsync(userId.ToString());
            try
            {
                if (user == null)
                {
                    return null;
                }
                return new UserDTO
                {
                    Id = user.Id,
                    Email = user.Result.Email
                };

            }
            catch (Exception ex)
            {
               
                 throw new Exception(ex.Message);
            }

        }



            public async   Task<IEnumerable<UserDTO>> GetAllUsersAsync()
            {
                var users = _userManager.Users.ToList();
                return users.Select(user => new UserDTO
                {
                  
                    Email = user.Email
                });
            }







        }
   }
