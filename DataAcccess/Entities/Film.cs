using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Entities
{
    [Table("film")]
    public class Film
    {
        [Column(name: "film_id")]
        public long Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(name: "title")]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(name: "description")]
        public string Description { get; set; }

        // public List<Actor> Actors { get; set; }
        public List<FilmActor> FilmActors { get; set; }
        //[Required]
        //[Column(name: "release_year")]
        //public string ReleaseYear { get; set; }
    }
}
