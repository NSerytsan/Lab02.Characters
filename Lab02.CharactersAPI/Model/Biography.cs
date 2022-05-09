using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Model
{
    [Table("Biography")]
    public class Biography
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
    }
}
