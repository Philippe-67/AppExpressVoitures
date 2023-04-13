using System.ComponentModel.DataAnnotations;

namespace AppExpressVoitures.Models
{
    public class Reparations
    {
        [Key]
        public int ReparationId { get; set; }
        public DateTime DatePriseEnCharge { get; set; }
        public DateTime? DateDelivrance { get; set; }

        // Clé étrangère pour la voiture associée à la réparation
        public int VinId { get; set; }
        public Voitures? Voiture { get; set; }
    }
}
