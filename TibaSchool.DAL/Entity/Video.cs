using System.ComponentModel.DataAnnotations.Schema;

namespace TibaSchool.DAL.Entity
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Path { get; set; }
        public string ImageName { get; set;}
        public int FolderId { get; set; }

        [ForeignKey("FolderId")]
        public virtual VideoFolder VideoFolder { get; set; }
    }
}