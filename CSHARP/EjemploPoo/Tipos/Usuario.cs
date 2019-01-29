//csc /t:library Usuario.cs /out:Tipos.dll

namespace Tipos
{
    public class Usuario
    {
        //Variables de instancia / Campos / Fields
        private string email;

        //Propiedad "automática" que genera la variable y los accesos
        public string Password { get; set; }

        //Métodos de acceso
        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        //Propiedad
        public string Email
        {
            //Acceso get
            get { return email; }
            //Acceso set
            set { email = value; }
        }
    }
}
