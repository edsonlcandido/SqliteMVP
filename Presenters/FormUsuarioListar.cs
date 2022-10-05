using SqliteMVP.Models;
using SqliteMVP.Repositories;

namespace SqliteMVP.Presenters
{
    public partial class FormUsuarioListar : Form, IUsuarioView
    {
        private IUsuarioRepository _usuarioRepository;
        private BindingSource _bindingSource;
        private IEnumerable<UsuarioModel> _listaUsuarios;

        public FormUsuarioListar(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
            _bindingSource = new BindingSource();
            //_listaUsuarios = _usuarioRepository.listar();
            //_bindingSource.DataSource = _listaUsuarios;
            InitializeComponent();
        }

        public string usuarioId { 
            get
            {
                return textBoxUsuarioId.Text;
            }
            set 
            {
                textBoxUsuarioId.Text = value;
            }
        }
        public string usuarioNome
        {
            get
            {
                return textBoxUsuarioNome.Text;
            }
            set
            {
                textBoxUsuarioNome.Text = value;
            }
        }

        private void FormUsuarioListar_Load(object sender, EventArgs e)
        {
            updateDataSource();
            dataGridView1.DataSource = _bindingSource;
        }

        private void updateDataSource()
        {
            _listaUsuarios = _usuarioRepository.listar();
            _bindingSource.DataSource = _listaUsuarios;
        }

        private void clearForm()
        {
            this.usuarioId = "";
            this.usuarioNome = "";
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.nome = this.usuarioNome;
            _usuarioRepository.adicionar(usuarioModel);
            updateDataSource();
            clearForm();
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            UsuarioModel usuarioModel = (UsuarioModel)_bindingSource.Current;
            this.usuarioId = usuarioModel.id.ToString();
            this.usuarioNome = usuarioModel.nome;
            buttonSalvar.Enabled = true;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.id = Convert.ToInt64(this.usuarioId);
            usuarioModel.nome = this.usuarioNome;
            _usuarioRepository.editar(usuarioModel);
            buttonSalvar.Enabled=false;
            updateDataSource();
            clearForm();
        }
    }
}