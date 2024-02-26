using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Entities
{
    [Table("actor")]
    public class Actor
    {
        [Column(name: "actor_id")]
        public long Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(name: "first_name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(name: "last_name")]
        public string LastName { get; set; }
        //   public List<Film> Films { get; set; }
        public List<FilmActor> FilmActors { get; set; }

        //[Required]
        //[Column(name: "last_update")]
        //public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
    }
}
