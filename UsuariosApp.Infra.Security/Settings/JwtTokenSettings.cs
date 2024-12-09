using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Security.Settings
{
    public class JwtTokenSettings
    {
        /// <summary>
        /// Chave para criptografia / assinatura do TOKEN
        /// </summary>
        public static string SecretKey = "EB1AB146-C07B-48D0-81FD-C42AF391790F";

        /// <summary>
        /// Tempo de expiração do TOKEN em horas
        /// </summary>
        public static int ExpirationInHours = 1;
    }
}
