using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CdAppTwo.Models
{
    public class Cd
    {
        // Properties
        public int Id { get; set; }
        [DisplayName("Titel")]
        public string CdTitle { get; set; }
        [DisplayName("Utgiven")]
        public int Year { get; set; }
        [DisplayName("Artist/Band")]
        public string Artist { get; set; }

        [DisplayName("Låtar")]
        public ICollection<Songs> Songs { get; set; }
    }
}
