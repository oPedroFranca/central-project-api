namespace centralProjectApi.Application.DTOs
{
    public class CategoryCreateDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
