using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWeb.Repository.Models
{
    [Table("Post")]
    public class Post
    {
        private static readonly char delimiter = ',';

        [Key]
        public int PostId { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }
    
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<PostTag> PostTags { get; set; }

        [NotMapped]
        public List<string> TagList { get; set; }

    }
}
