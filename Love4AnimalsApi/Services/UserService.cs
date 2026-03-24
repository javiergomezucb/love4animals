using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public GetUserDto? GetUser(int id)
        {
            var user = _userRepository.getUser(id);
            if (user == null) return null;

            return new GetUserDto { Id = user.Id, Name = user.Name, Email = user.Email };
        }

        public void CreateUser(CreateUserDto userDto)
        {
            var newUser = new User(0, userDto.Name, userDto.Email);
            _userRepository.addUser(newUser);
        }

        public void UpdateUser(int id, UpdateUserDto userDto)
        {
            var user = _userRepository.getUser(id);
            if (user != null)
            {
                user.Name = userDto.Name;
                user.Email = userDto.Email;
            }
        }

        public void DeleteUser(int id)
        {
            
        }
    }
}