namespace EasyEat.Models
{
    public partial class RestauranteModel
    {
        #region Members 
        private int _restauranteId;
        private string _tipoDocumento;
        private string _numeroDocumento;
        private string _nombre;
        private string _tipoRestaurante;
        private string _descripcion;
        private string _telefono;
        private string _direccion;
        #endregion
        #region Propierties 
        public int RestauranteId
        {
            get { return _restauranteId; }
            set { _restauranteId = value; }
        }
        public string tipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }
        public string numeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string tipoRestaurante
        {
            get { return _tipoRestaurante; }
            set { _tipoRestaurante = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        #endregion
    }
}
