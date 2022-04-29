namespace Examen2;
public partial class Form2 : Form {

    private CheckedListBox listaMonedas;
    private Button aceptarButton;
    private Button cancelarButton;
    private List<string> monedasTotales;

    public Form2(Dictionary<string, double> valoresMonedas) {
        this.Text = "Seleccione la moneda";
        listaMonedas = new CheckedListBox();
        aceptarButton = new Button();
        cancelarButton = new Button();

        monedasTotales = new List<string>();

        foreach (string llave in valoresMonedas.Keys) {
            monedasTotales.Add(llave);
        }

        InitializeComponent();
        InicializarComponentes();
    }

    private void InicializarComponentes() {
        //Inicializamos CHECKEDLISTBOX

        listaMonedas.AutoSize = true;
        listaMonedas.Location = new Point(10, 10);
        listaMonedas.Size = new Size(240, 130);

        foreach(string moneda in monedasTotales) {
            listaMonedas.Items.Add(moneda);
        }
       

        this.Controls.Add(listaMonedas);

        //Inicializamos BUTTONS
        aceptarButton.Text = "Aceptar";
        aceptarButton.AutoSize = true;
        aceptarButton.Width = 110;
        aceptarButton.Location = new Point(140, 150);
        aceptarButton.Click += new EventHandler(AceptarButton_Click);
        
        cancelarButton.Text = "Cancelar";
        cancelarButton.AutoSize = true;
        cancelarButton.Width = 110;
        cancelarButton.Location = new Point(10, 150);
        cancelarButton.Click += new EventHandler(CancelarButton_Click);

        this.Controls.Add(aceptarButton);
        this.Controls.Add(cancelarButton);
    }

    public List<string> GetMonedasMarcadas() {
        List <string> monedasMarcadas = new List<string> ();
        

        foreach (int indexChecked in listaMonedas.CheckedIndices) {
            monedasMarcadas.Add(monedasTotales[indexChecked]);
        }

        return monedasMarcadas;
    }

    private void AceptarButton_Click(object? sender, EventArgs e) {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void CancelarButton_Click(object? sender, EventArgs e) {
        this.Close();
    }


}

