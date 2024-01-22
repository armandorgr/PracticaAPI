using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo.Messages
{
    /*
     Esta clase solo sirve para representar el mensaje quue se pasa desde el viewModel al C# asociado a la vista.
     */
    public partial class RegisteredMessage
    {
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public RegisteredMessage(string message) { this.message = message; }
    }
}
