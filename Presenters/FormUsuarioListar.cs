using SqliteMVP.Models;
using SqliteMVP.Repositories;

namespace SqliteMVP.Presenters
{
    public partial class FormUsuarioListar : Form
    {
        private IUsuarioRepository _usuarioRepository;
        private BindingSource _bindingSource;
        private IEnumerable<UsuarioModel> _listaUsuarios;

        public FormUsuarioListar(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
            _bindingSource = new BindingSource();
            _listaUsuarios = _usuarioRepository.listar();
            _bindingSource.DataSource = _listaUsuarios;
            InitializeComponent();
        }

        private void FormUsuarioListar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _bindingSource;
        }
    }
}