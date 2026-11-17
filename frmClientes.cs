using System;
using System.Windows.Forms;

public partial class frmClientes : Form
{
    public frmClientes()
    {
        InitializeComponent();
        CarregarGrid();
    }

    private void btnCadastrar_Click(object sender, EventArgs e)
    {
        // Validação básica
        if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtTelefone.Text))
        {
            MessageBox.Show("Preencha o nome e o telefone do cliente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Cliente cliente = new Cliente(txtNome.Text, txtTelefone.Text, txtEmail.Text);
        ClienteRepository repo = new ClienteRepository();
        repo.Inserir(cliente);

        MessageBox.Show("Cliente cadastrado com sucesso!");
        CarregarGrid();
        LimparCampos();
    }

    private void CarregarGrid()
    {
        ClienteRepository repo = new ClienteRepository();
        dgvClientes.DataSource = repo.Listar();
    }

    private void LimparCampos()
    {
        txtNome.Clear();
        txtTelefone.Clear();
        txtEmail.Clear();
        txtNome.Focus();
    }
}
