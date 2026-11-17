using System;
using System.Data;
using System.Windows.Forms;

public partial class frmPets : Form
{
    private ClienteRepository clienteRepo = new ClienteRepository();

    public frmPets()
    {
        InitializeComponent();
        CarregarClientesCombo();
        CarregarGrid();
    }

    private void CarregarClientesCombo()
    {
        DataTable dt = clienteRepo.Listar();
        cmbClientes.DataSource = dt;
        cmbClientes.DisplayMember = "nome"; // Exibe o nome do cliente
        cmbClientes.ValueMember = "id";     // Pega o ID do cliente
    }

    private void btnCadastrar_Click(object sender, EventArgs e)
    {
        // REGRA DE NEGÓCIO: Pet deve estar associado a um cliente
        if (cmbClientes.SelectedValue == null)
        {
            MessageBox.Show("Selecione um cliente válido para associar ao Pet!", "Regra de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtNomePet.Text) || string.IsNullOrWhiteSpace(txtEspecie.Text))
        {
            MessageBox.Show("Preencha o nome e a espécie do pet!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int clienteId = Convert.ToInt32(cmbClientes.SelectedValue);
        Pet pet = new Pet(txtNomePet.Text, txtEspecie.Text, txtRaca.Text, clienteId);
        
        PetRepository repo = new PetRepository();
        repo.Inserir(pet);

        MessageBox.Show("Pet cadastrado e associado ao cliente com sucesso!");
        CarregarGrid();
        txtNomePet.Clear();
        txtEspecie.Clear();
        txtRaca.Clear();
    }

    private void CarregarGrid()
    {
        PetRepository repo = new PetRepository();
        dgvPets.DataSource = repo.ListarComClientes();
    }
}
