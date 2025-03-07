using Application.Dots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public    interface IUserService
    {
        Task <UserResultDTO> RegisterAsync( UserDTO registerDTO);
        Task<UserResultDTO> LoginAsync(UserDTO loginDTO);
        Task LogoutAsync();
        Task<UserDTO> GetUserByIdAsync( int userId);
        Task<IEnumerable <UserDTO>> GetAllUsersAsync();

    }
}
