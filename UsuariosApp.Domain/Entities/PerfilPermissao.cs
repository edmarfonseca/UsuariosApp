﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Entities
{
    public class PerfilPermissao
    {
        #region Propriedades

        public Guid PerfilId { get; set; }
        public Guid PermissaoId { get; set; }

        #endregion

        #region Relacionamentos

        public Perfil? Perfil { get; set; }
        public Permissao? Permissao { get; set; }

        #endregion
    }
}
