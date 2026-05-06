using System.ComponentModel.DataAnnotations; // 👈 Imprescindible para las validaciones

namespace Love4AnimalsApi.Dtos;

public class CreateCampaignDto
{
    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(100, ErrorMessage = "El título no puede pasar los 100 caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es necesaria para los donantes")]
    public string Description { get; set; } = string.Empty;

    [Range(1, 100000, ErrorMessage = "La meta debe ser un monto positivo entre 1 y 100,000")]
    public decimal GoalAmount { get; set; }
}

public class GetCampaignDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal GoalAmount { get; set; }
    public decimal AmountCollected { get; set; }
}