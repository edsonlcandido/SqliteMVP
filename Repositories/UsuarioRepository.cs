using SqliteMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SqliteMVP.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string CONNECTION_STRING = @"Data SOurce=dataBase.db;Version=3;";
        public void adicionar(UsuarioModel usuarioModel)
        {
            SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING);
            SQLiteCommand command = new SQLiteCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = @"INSERT INTO usuario (
                        nome
                    )
                    VALUES (
                        @nome
                    );";
            command.Parameters.Add("@nome", System.Data.DbType.String).Value = usuarioModel.nome;           
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void deletar(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public void editar(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioModel> listar()
        {
            List<UsuarioModel> listaUsuario = new List<UsuarioModel>();
            SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING);
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT id,
                                           nome
                                      FROM usuario;";
            command.Connection = connection;
            connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    UsuarioModel usuarioModel = new UsuarioModel();
                    usuarioModel.id = (Int64)reader["id"];
                    usuarioModel.nome = reader["nome"].ToString();
                    listaUsuario.Add(usuarioModel);
                }
            }
            return listaUsuario;
        }
    }
}
