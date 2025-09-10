﻿namespace centralProjectApi.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }  
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
