using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWeb.Repository.Models
{
    public class PostTag
    {
        [ForeignKey("Post")]
        public int PostId { get; set; }

        public Post Post { get; set; }

        [ForeignKey("Tag")]
        public string TagId { get; set; }

        public Tag Tag { get; set; }

    }
}
