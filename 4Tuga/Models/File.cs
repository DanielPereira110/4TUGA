using System.ComponentModel.DataAnnotations;

namespace _4Tuga.Models
{
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }

        [Required]
        public virtual ApplicationUser Person { get; set; }
    }
}