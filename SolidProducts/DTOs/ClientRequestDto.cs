namespace SolidProducts.DTOs;
public class ClientRequestDto
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required int DocumentNumber { get; set; }
    public int DocumentTypeId { get; set; }
}