namespace EasyEat.Models
{
    public partial class PagoModel
    {
        #region Members 
        private int _pagoId;
        private double _valor;
        private string _tipoPago;
        private string _estado;
        #endregion
        #region Propierties 
        public int PagoId
        {
            get { return _pagoId; }
            set { _pagoId = value; }
        }
        public double valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public string tipoPago
        {
            get { return _tipoPago; }
            set { _tipoPago = value; }
        }
        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        #endregion
    }
}
