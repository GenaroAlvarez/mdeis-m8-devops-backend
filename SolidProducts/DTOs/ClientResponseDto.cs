using SolidProducts.Entities;

namespace SolidProducts.DTOs;

public class ClientResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Code { get; set; } = string.Empty;
    public required ClientGroup ClientGroup { get; set; }
    public DateTime CreatedAt { get; set; }

}
