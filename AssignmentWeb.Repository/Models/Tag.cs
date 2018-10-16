using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWeb.Repository.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public string TagId { get; set; }

        public List<PostTag> PostTags { get; set; }

    }
}
