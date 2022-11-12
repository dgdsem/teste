using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testeSelecao.Interfaces;

namespace testeSelecao.Models
{
    public class Conta : IConta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int idConta { get; set; }
        [Required, Column(Order = 1)]
        [StringLength(50)]
        public string nome { get; set; }
        [Required, Column(Order = 2)]
        [StringLength(100)]
        public string descricao { get; set; }
    }
}
