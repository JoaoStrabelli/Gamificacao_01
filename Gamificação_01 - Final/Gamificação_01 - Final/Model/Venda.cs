using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRJ.Modas
{
    public class VendaModel
    {
        public long VendaID { get; set; }
        public DateTime Data { get; set; }
        public ClienteModel? Cliente { get; set; }
        public List<VendaProdutoModel> vendaProduto { get; set; }
        public double Total
        {
            get
            {//LINQ
                try
                {
                    return vendaProduto!.Sum(p => p.Subtotal);
                }
                catch (NullReferenceException nrfe)
                {
                    throw new Exception($"Nota sem venda: {nrfe.Message}");
                }
            }
        }
    }
}