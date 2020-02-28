using System.ComponentModel;

namespace CdAppTwo.Models
{
    public class Songs
    {
        // Properties
        public int Id { get; set; }
        [DisplayName("Låttitel")]
        public string SongName { get; set; }
        [DisplayName("Speltid")]
        public int Playtime { get; set; }
        [DisplayName("Titel")]
        public int CdId { get; set; }

        public Cd CD { get; set; }
    }
}