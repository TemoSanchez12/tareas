
namespace Repaso;
public partial class Form2 : Form {

    private Label lblMensaje;
    private Button btnCerrar;

    public Form2() {
        btnCerrar = new Button();
        lblMensaje = new Label();
        InitializeComponent();
        InicializarComponentes();
    }

    private void InicializarComponentes() {

        this.Text = "Nueva Ventana";
        // Inicializamos Label
        lblMensaje.Text = "Esta es una nueva ventana";
        lblMensaje.AutoSize = true;
        lblMensaje.Location = new Point(80, 80);

        //Inicializamos Button
        btnCerrar.Text = "Cerrar";
        btnCerrar.AutoSize = true;
        btnCerrar.Location = new Point(90,100);
        btnCerrar.Click += new EventHandler(btnCerrar_Click);

        // Agregamos
        this.Controls.Add(btnCerrar);
        this.Controls.Add(lblMensaje);
    }

    private void btnCerrar_Click(Object? sender, EventArgs e) {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}

