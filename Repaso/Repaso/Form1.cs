namespace Repaso;
public partial class Form1 : Form {

    private Button button;

    public Form1() {
        button = new Button();
        InitializeComponent();
        InicializarComponentes();
    }
    private void InicializarComponentes() {
        button.Text = "Abrir Nueva Ventana";
        button.AutoSize = true;
        button.Location = new Point(10, 10);

        this.Controls.Add(button);
    }

    private void btnVentana_Click(Object? sender, EventArgs e) {
        Form2 frmVentana = new Form2();
        if (frmVentana.ShowDialog() == DialogResult.OK) {
            Label lblAgregado = new Label();
            lblAgregado.Text = "";
            lblAgregado.AutoSize = true;
            lblAgregado.Location = new Point(10, 30);
            this.Controls.Add(lblAgregado);
        }
    }
}

    
