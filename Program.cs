using SqliteMVP.Presenters;
using SqliteMVP.Models;
using SqliteMVP.Repositories;
namespace SqliteMVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            UsuarioRepository usuarioRepository = new UsuarioRepository();

            ApplicationConfiguration.Initialize();
            Application.Run(new FormUsuarioListar(usuarioRepository));
        }
    }
}