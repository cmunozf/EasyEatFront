namespace EasyEat.Models
{
    public partial class ProductoModel
    {
        #region Members 
        private int _productoId;
        private string _nombre;
        private double _precio;
        private string _categoria;
        private string _restaurante;
        #endregion
        #region Propierties 
        public int ProductoId
        {
            get { return _productoId; }
            set { _productoId = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public double precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public string categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        public string restaurante
        {
            get { return _restaurante; }
            set { _restaurante = value; }
        }
        #endregion
    }
}
