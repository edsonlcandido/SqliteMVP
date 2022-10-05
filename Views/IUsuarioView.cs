using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqliteMVP.Views
{
    public interface IUsuarioView
    {
        string usuarioId { get; set; }
        string usuarioNome { get; set; }
    }
}