using System.Collections.Generic;

namespace EasyEat.Models
{
    public partial class FacturaModel
    {
        #region Members 
        private int _facturaId;
        private List<ProductoModel> _productos;
        private double _total;
        private double _propina;
        private int _referenciaPago;
        #endregion
        #region Propierties 
        public int FacturaId
        {
            get { return _facturaId; }
            set { _facturaId = value; }
        }
        public List<ProductoModel> productos
        {
            get { return _productos; }
            set { _productos = value; }
        }
        public double total
        {
            get { return _total; }
            set { _total = value; }
        }
        public double propina
        {
            get { return _propina; }
            set { _propina = value; }
        }
        public int referenciaPago
        {
            get { return _referenciaPago; }
            set { _referenciaPago = value; }
        }
        #endregion
    }
}
