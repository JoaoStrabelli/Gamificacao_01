using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JRJ.Modas
{
    public class CategoriaModel
    {
        public long? CategoriaID { get; set; }
        public Guid CategoriaIDGUID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public static List<CategoriaModel> categorias = new List<CategoriaModel>();
    }
}