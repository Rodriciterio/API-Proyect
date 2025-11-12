using PadelClubSystem.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Entities
{
    public class Socio : IEntidad
    {
        public Socio()
        {
            CoutasPorSocios = new HashSet<CuotaPorSocio>();
        }
        public Socio(string nombre, string apellido, string mail)
        {
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(mail);
        }
        #region Properties
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; private set; }
        [StringLength(30)]
        public string Apellido { get; private set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; private set; }
        public string TelefonoMovil { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaBaja { get; set; }
        #endregion

        #region Virtual
        public virtual ICollection<CuotaPorSocio> CoutasPorSocios { get; set; }
        #endregion

        #region setters y getters
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del socio no puede estar vacío.");
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido del socio no puede estar vacío.");
            Apellido = apellido;
        }
        public void SetEmail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail) || (!mail.Contains("@") && !mail.Contains(".com")))
                throw new ArgumentException("El email del socio no puede estar vacío, no contener un @ y no contener un .comke");
            Email = mail;
        }

        public string GetCompleteName()
        {
            return string.Join(", ", Apellido, Nombre);
        }
        #endregion
    }
}
