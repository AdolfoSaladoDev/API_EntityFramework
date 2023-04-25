using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("Ingredient")]
    public class Ingredient
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }


        [ForeignKey("FK_Plate")]
        public int PlateId { get; set; }

        [JsonIgnore]
        public Plate FK_Plate { get; set; }

    }
}
