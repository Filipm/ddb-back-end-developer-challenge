using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDHitPointsServices.Entities
{
    [Index(nameof(CharacterName))]
    [Table("HitPoints")]
    public class HitPoints
    {
        [Key()]
        public string CharacterName { get; set; } = "";

        [Required]
        public int CurrentHitPoints { get; set; }

        [Required]
        public int TemporaryHitPoints { get; set; }
    }
}
