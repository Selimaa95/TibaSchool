using System.ComponentModel.DataAnnotations.Schema;

namespace TibaSchool.DAL.Entity
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }

        public int FolderId { get; set; }
        [ForeignKey("FolderId")]
        public virtual Folder Folder { get; set; }

        public virtual IEnumerable<Images> Images { get; set; }
    }
}