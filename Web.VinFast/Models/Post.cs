﻿namespace Web.VinFast.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
