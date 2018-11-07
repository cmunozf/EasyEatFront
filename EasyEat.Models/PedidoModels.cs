namespace EasyEat.Models
{
    public partial class PedidoModel
    {
        #region Members 
        private int _pedidoId;
        private int _tiempoEspera;
        private string _productos;
        private double _total;
        private string _restaurante;
        #endregion
        #region Propierties 
        public int PedidoId
        {
            get { return _pedidoId; }
            set { _pedidoId = value; }
        }
        public int tiempoEspera
        {
            get { return _tiempoEspera; }
            set { _tiempoEspera = value; }
        }
        public string productos
        {
            get { return _productos; }
            set { _productos = value; }
        }
        public double total
        {
            get { return _total; }
            set { _total = value; }
        }
        public string restaurante
        {
            get { return _restaurante; }
            set { _restaurante = value; }
        }
        #endregion
    }
}
