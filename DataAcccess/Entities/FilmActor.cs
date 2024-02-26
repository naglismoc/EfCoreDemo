using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Entities
{
    public class FilmActor
    {
        [Key, Column(Order = 0)]
        [ForeignKey("film_id")]
        public long FilmId { get; set; }
        public Film Film { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("actor_id")]
        public long ActorId { get; set; }
        public Actor Actor { get; set; }

    }
}
