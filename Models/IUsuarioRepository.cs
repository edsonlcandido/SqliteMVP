using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteMVP.Models
{
    public interface IUsuarioRepository
    {
        void adicionar(UsuarioModel usuarioModel);
        void editar(UsuarioModel usuarioModel);
        void deletar(UsuarioModel usuarioModel);
        IEnumerable<UsuarioModel> listar();
    }
}
