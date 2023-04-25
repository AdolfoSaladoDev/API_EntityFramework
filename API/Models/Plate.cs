using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("Plate")]
    public class Plate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("FK_Menu")]
        public int MenuId { get; set; }

        [JsonIgnore]
        public Menu FK_Menu { get; set; }

        [JsonIgnore]
        public List<Ingredient> ingredients { get; set; }
    }
}
