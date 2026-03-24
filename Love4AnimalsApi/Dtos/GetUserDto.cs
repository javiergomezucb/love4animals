namespace Love4AnimalsApi.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; }
    }

    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}