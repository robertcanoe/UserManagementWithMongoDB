partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private const int ControlMargin = 10;
    private const int ControlHeight = 30;
    private const int ButtonWidth = 150;

    private System.Windows.Forms.TableLayoutPanel mainLayout;
    private System.Windows.Forms.GroupBox grpCreateUser;
    private System.Windows.Forms.GroupBox grpUpdateUser;
    private System.Windows.Forms.GroupBox grpDeleteUser;
    private System.Windows.Forms.GroupBox grpUserList;

    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.TextBox txtUserId;
    private System.Windows.Forms.TextBox txtNewUsername;
    private System.Windows.Forms.TextBox txtNewEmail;
    private System.Windows.Forms.TextBox txtUserIdToDelete;

    private System.Windows.Forms.Button btnCreateUser;
    private System.Windows.Forms.Button btnUpdateUser;
    private System.Windows.Forms.Button btnDeleteUser;
    private System.Windows.Forms.Button btnRefreshList;

    private System.Windows.Forms.ListBox lstUsers;

    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.Label lblUserId;
    private System.Windows.Forms.Label lblNewUsername;
    private System.Windows.Forms.Label lblNewEmail;
    private System.Windows.Forms.Label lblUserIdToDelete;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 600);
        this.MinimumSize = new System.Drawing.Size(800, 500);
        this.Text = "Gestión de Usuarios Profesional";
        this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        // Main Layout
        this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
        this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.mainLayout.ColumnCount = 2;
        this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
        this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
        this.mainLayout.RowCount = 3;
        this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
        this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
        this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
        this.mainLayout.Padding = new System.Windows.Forms.Padding(ControlMargin);
        this.mainLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;

        // Create User Group
        this.grpCreateUser = new System.Windows.Forms.GroupBox();
        InitializeCreateUserGroup();
        this.mainLayout.Controls.Add(this.grpCreateUser, 0, 0);

        // Update User Group
        this.grpUpdateUser = new System.Windows.Forms.GroupBox();
        InitializeUpdateUserGroup();
        this.mainLayout.Controls.Add(this.grpUpdateUser, 0, 1);

        // Delete User Group
        this.grpDeleteUser = new System.Windows.Forms.GroupBox();
        InitializeDeleteUserGroup();
        this.mainLayout.Controls.Add(this.grpDeleteUser, 0, 2);

        // User List Group
        this.grpUserList = new System.Windows.Forms.GroupBox();
        InitializeUserListGroup();
        this.mainLayout.Controls.Add(this.grpUserList, 1, 0);
        this.mainLayout.SetRowSpan(this.grpUserList, 3);

        this.Controls.Add(this.mainLayout);
    }

    private void InitializeCreateUserGroup()
    {
        this.grpCreateUser.Text = "Crear Nuevo Usuario";
        this.grpCreateUser.Dock = System.Windows.Forms.DockStyle.Fill;

        var layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Padding = new Padding(ControlMargin);

        // Username
        this.lblUsername = CreateLabel("Nombre de Usuario:");
        this.txtUsername = CreateTextBox();
        layout.Controls.Add(this.lblUsername, 0, 0);
        layout.Controls.Add(this.txtUsername, 1, 0);

        // Email
        this.lblEmail = CreateLabel("Email:");
        this.txtEmail = CreateTextBox();
        layout.Controls.Add(this.lblEmail, 0, 1);
        layout.Controls.Add(this.txtEmail, 1, 1);

        // Button
        this.btnCreateUser = CreateButton("Crear Usuario");
        this.btnCreateUser.Anchor = AnchorStyles.Right;
        this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
        layout.Controls.Add(this.btnCreateUser, 1, 2);

        this.grpCreateUser.Controls.Add(layout);
    }

    private void InitializeUpdateUserGroup()
    {
        this.grpUpdateUser.Text = "Actualizar Usuario Existente";
        this.grpUpdateUser.Dock = System.Windows.Forms.DockStyle.Fill;

        var layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Padding = new Padding(ControlMargin);

        // User ID
        this.lblUserId = CreateLabel("ID de Usuario:");
        this.txtUserId = CreateTextBox();
        layout.Controls.Add(this.lblUserId, 0, 0);
        layout.Controls.Add(this.txtUserId, 1, 0);

        // New Username
        this.lblNewUsername = CreateLabel("Nuevo Nombre:");
        this.txtNewUsername = CreateTextBox();
        layout.Controls.Add(this.lblNewUsername, 0, 1);
        layout.Controls.Add(this.txtNewUsername, 1, 1);

        // New Email
        this.lblNewEmail = CreateLabel("Nuevo Email:");
        this.txtNewEmail = CreateTextBox();
        layout.Controls.Add(this.lblNewEmail, 0, 2);
        layout.Controls.Add(this.txtNewEmail, 1, 2);

        // Button
        this.btnUpdateUser = CreateButton("Actualizar Usuario");
        this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
        layout.Controls.Add(this.btnUpdateUser, 1, 3);

        this.grpUpdateUser.Controls.Add(layout);
    }

    private void InitializeDeleteUserGroup()
    {
        this.grpDeleteUser.Text = "Eliminar Usuario";
        this.grpDeleteUser.Dock = System.Windows.Forms.DockStyle.Fill;

        var layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Padding = new Padding(ControlMargin);

        // User ID to Delete
        this.lblUserIdToDelete = CreateLabel("ID de Usuario:");
        this.txtUserIdToDelete = CreateTextBox();
        layout.Controls.Add(this.lblUserIdToDelete, 0, 0);
        layout.Controls.Add(this.txtUserIdToDelete, 1, 0);

        // Button
        this.btnDeleteUser = CreateButton("Eliminar Usuario");
        this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
        layout.Controls.Add(this.btnDeleteUser, 1, 1);

        this.grpDeleteUser.Controls.Add(layout);
    }

    private void InitializeUserListGroup()
    {
        this.grpUserList.Text = "Lista de Usuarios";
        this.grpUserList.Dock = System.Windows.Forms.DockStyle.Fill;

        var layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;
        layout.RowCount = 2;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, ControlHeight + ControlMargin));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.Padding = new Padding(ControlMargin);

        // List Box
        this.lstUsers = new ListBox();
        this.lstUsers.Dock = DockStyle.Fill;
        this.lstUsers.Font = new Font("Consolas", 9.75F);
        this.lstUsers.HorizontalScrollbar = true;

        // Refresh Button
        this.btnRefreshList = CreateButton("Actualizar Lista");
        this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
        this.btnRefreshList.Anchor = AnchorStyles.Right;

        layout.Controls.Add(this.btnRefreshList, 0, 0);
        layout.Controls.Add(this.lstUsers, 0, 1);

        this.grpUserList.Controls.Add(layout);
    }

    private TextBox CreateTextBox()
    {
        return new TextBox()
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 0, ControlMargin),
            Height = ControlHeight
        };
    }

    private Label CreateLabel(string text)
    {
        return new Label()
        {
            Text = text,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            Margin = new Padding(0, 0, ControlMargin, 0)
        };
    }

    private Button CreateButton(string text)
    {
        return new Button()
        {
            Text = text,
            Size = new Size(ButtonWidth, ControlHeight),
            Margin = new Padding(0, ControlMargin, 0, 0),
            Anchor = AnchorStyles.Right
        };
    }

    // Resto de la inicialización de eventos y componentes
}