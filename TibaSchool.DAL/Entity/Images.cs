using System.ComponentModel.DataAnnotations.Schema;

namespace TibaSchool.DAL.Entity
{
    public class Images
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }
    }
}