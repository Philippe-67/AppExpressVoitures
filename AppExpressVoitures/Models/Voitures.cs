using System.ComponentModel.DataAnnotations;

namespace AppExpressVoitures.Models
{
    public class Voitures
    {
        [Key]
        public int VinID { get; set; }
        public DateTime DateAchat { get; set; }
        public string Marque { get; set; }
        public string Finition { get; set; }
        public string Modele { get; set; }
        public DateTime? DateVente { get; set; }
        public float PrixAchat { get; set; }
        public float PrixVente { get; set; }
        public bool VoitureDisponible { get; set; }
        // Liste des réparations associées à la voiture
        public ICollection<Reparations>? Reparations { get; set; }

    }
}

