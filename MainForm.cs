using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

public partial class MainForm : Form
{
    private readonly UserService userService;

    public MainForm()
    {
        InitializeComponent();
        try
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeuserAppConsoleDB");
            var usersCollection = database.GetCollection<User>("Users");
            var countersCollection = database.GetCollection<Counter>("Counters");
            var deletedIdsCollection = database.GetCollection<DeletedId>("DeletedIds");
            userService = new UserService(usersCollection, countersCollection, deletedIdsCollection);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al conectarse a la base de datos: {ex.Message}");
            Application.Exit();
        }
    }

    private void btnCreateUser_Click(object sender, EventArgs e)
    {
        try
        {
            userService.CrearUsuario(txtUsername.Text, txtEmail.Text);
            MessageBox.Show("Usuario creado exitosamente.");
            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear usuario: {ex.Message}");
        }
    }

    private void btnRefreshList_Click(object sender, EventArgs e)
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        try
        {
            var usuarios = userService.ListarUsuarios();
            lstUsers.Items.Clear();
            foreach (var usuario in usuarios)
            {
                lstUsers.Items.Add($"ID: {usuario.CustomId} | Usuario: {usuario.Username} | Email: {usuario.Email}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al listar usuarios: {ex.Message}");
        }
    }

    private void btnUpdateUser_Click(object sender, EventArgs e)
    {
        try
        {
            userService.ActualizarUsuario(txtUserId.Text, txtNewUsername.Text, txtNewEmail.Text);
            MessageBox.Show("Usuario actualizado exitosamente.");
            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar usuario: {ex.Message}");
        }
    }

    private void btnDeleteUser_Click(object sender, EventArgs e)
    {
        try
        {
            userService.EliminarUsuario(txtUserIdToDelete.Text);
            MessageBox.Show("Usuario eliminado exitosamente.");
            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar usuario: {ex.Message}");
        }
    }
}