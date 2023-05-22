using System.ComponentModel.DataAnnotations;

namespace ParcialJuanPabloGomezRamirez.DAL.Entities
{
    public class Ticket
    {
        [Key]
        public Guid id { get; set; }
        public DateTime? UseDate { get; set; } //NULL
        public bool IsUsed { get; set; }

        [MaxLength(11)]
        public string? EntranceGate { get; set; } //NULL


    }
}
