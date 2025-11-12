using PadelClubSystem.Abstractions;

namespace PadelClubSystem.Entities
{
    public class Anio : IEntidad
    {
        public Anio()
        {
            CoutasPorSocios = new HashSet<CuotaPorSocio>();
        }

        public Anio(int numero)
        {
            this.SetAnio(numero);
        }


        #region Properties
        public int Id { get; set; }
        public int Numero { get; private set; }
        #endregion
        #region Virtual
        public virtual ICollection<CuotaPorSocio> CoutasPorSocios { get; set; }
        #endregion
        #region setters y getters
        public void SetAnio(int anio)
        {
            if (anio < 0)
                throw new ArgumentException("El año debe ser mayor a 0.");
            Numero = anio;
        }
        public string GetName()
        {
            return string.Join(": ", "Año", Numero.ToString());
        }
        #endregion
    }
}
