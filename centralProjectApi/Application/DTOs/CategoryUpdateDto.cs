﻿namespace centralProjectApi.Application.DTOs
{
    public class CategoryUpdateDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
