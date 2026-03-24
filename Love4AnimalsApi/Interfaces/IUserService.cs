using Love4AnimalsApi.Dtos;

namespace Love4AnimalsApi.Interfaces
{
   public interface IUserService
    {
        GetUserDto? GetUser(int id); 
        void CreateUser(CreateUserDto user);
        void UpdateUser(int id, UpdateUserDto user);
        void DeleteUser(int id); 
    }
}