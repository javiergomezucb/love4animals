namespace Love4AnimalsApi.Models;
public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } = "Voluntario"; // Nuevo: Rol
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Nuevo: Fecha registro

    public User(int id, string name, string email) {
        Id = id; Name = name; Email = email;
    }
}