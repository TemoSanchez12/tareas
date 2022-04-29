namespace Examen2; 
public partial class Form1 : Form {
    
    private Panel panelRespuesta;

    private Label labelMoneda;
    private Label labelMonto;
    private ComboBox listaMonedas;
    private TextBox textBoxMonto;
    private Button calcularButton;

    private Dictionary<string, double> valoresMonedas;
    private Dictionary<string, int> simbolosMonedas;

    public Form1() {
        this.Text = "Conversor de monedas";

        panelRespuesta = new Panel();
        listaMonedas = new ComboBox();
        labelMoneda = new Label();
        labelMonto = new Label();
        textBoxMonto = new TextBox();
        calcularButton = new Button();
        valoresMonedas = new Dictionary<string, double>();
        simbolosMonedas = new Dictionary<string, int>();


        simbolosMonedas.Add("USD - Dolar Estadounidense", 36);
        simbolosMonedas.Add("MXN - Peso Mexicano", 36);
        simbolosMonedas.Add("CAD - Dolar Canadiense", 36);
        simbolosMonedas.Add("EUR - Euro", 128);
        simbolosMonedas.Add("JPY - Yen Japones", 165);
        simbolosMonedas.Add("BTC - Bitcoin", 63);
        simbolosMonedas.Add("ETH - Ethereum ", 63);


        valoresMonedas.Add("USD - Dolar Estadounidense", 1);
        valoresMonedas.Add("MXN - Peso Mexicano", 21.23);
        valoresMonedas.Add("CAD - Dolar Canadiense", 1.28);
        valoresMonedas.Add("EUR - Euro", 0.89);
        valoresMonedas.Add("JPY - Yen Japones", 113.05);
        valoresMonedas.Add("BTC - Bitcoin", 1/39658.90);
        valoresMonedas.Add("ETH - Ethereum ", 1 / 2909.43);

        InitializeComponent();
        InicializarComponentes();
    }

    private void InicializarComponentes() {
        //Inicialiamos PANEL
        panelRespuesta.Location = new Point(20, 110);
        panelRespuesta.Size = new Size(290, 270);
        panelRespuesta.BorderStyle = BorderStyle.Fixed3D;

        this.Controls.Add(panelRespuesta);


        // Inicializamos LABELS
        labelMoneda.Text = "Moneda";
        labelMonto.Text = "Monto";

        labelMoneda.AutoSize = true;
        labelMonto.AutoSize = true;

        labelMoneda.Location = new Point(20, 20);
        labelMonto.Location = new Point(200, 20);

        this.Controls.Add(labelMoneda);
        this.Controls.Add(labelMonto);

        // Inicializamos COMBOBOX
        listaMonedas.Name = "Monedas";
        listaMonedas.Size = new Size(160, 20);
        listaMonedas.Location = new Point(20, 40);

        foreach (string llave in valoresMonedas.Keys) {
            listaMonedas.Items.Add(llave);
        }

        this.Controls.Add(listaMonedas);

        // Inicializamos TEXTBOX
        textBoxMonto.Name = "TextBoxMonedas";
        textBoxMonto.Size = new Size(100, 20);
        textBoxMonto.Location = new Point(200, 40);

        this.Controls.Add(textBoxMonto);

        // Inicializamos BUTTONS
        calcularButton.Text = "Calcular";
        calcularButton.AutoSize = true;
        calcularButton.Width = 100;
        calcularButton.Location = new Point(200, 70);
        calcularButton.Click += new EventHandler(CalcularButton_Click);

        this.Controls.Add(calcularButton);
        
    }

    private void CalcularButton_Click(Object? sender, EventArgs e) {
        string monedaSeleccionada = listaMonedas.SelectedItem.ToString();
        double montoIngresado = double.Parse(textBoxMonto.Text);

        Form2 ventanaMonedas = new Form2(valoresMonedas);
        List<string> monedasMarcadas;


        if (ventanaMonedas.ShowDialog() == DialogResult.OK) {
            monedasMarcadas = ventanaMonedas.GetMonedasMarcadas();

            if (monedaSeleccionada != "USD - Dolar Estadounidense") {
                montoIngresado = SerializarADolar(montoIngresado, monedaSeleccionada);
            }

            int indiceYRespuestas = 5;

            foreach (string moneda in monedasMarcadas) {
                Label label = new Label();
                label.Text = moneda;
                label.Location = new Point(5, indiceYRespuestas + 2);
                label.AutoSize = true;

                TextBox conversion = new TextBox();
                conversion.Location = new Point(180, indiceYRespuestas);
                conversion.AutoSize = true;
                conversion.Width = 100;

                string respuesta = Math.Round(montoIngresado * valoresMonedas[moneda], 2).ToString();
                string simbolo= Convert.ToChar(simbolosMonedas[moneda]).ToString();
                conversion.Text =  simbolo + " " +  respuesta;
                indiceYRespuestas += 30;

                panelRespuesta.Controls.Add(label);
                panelRespuesta.Controls.Add(conversion);
            }

            Button continuarButton = new Button();
            continuarButton.Location = new Point(20, 390);
            continuarButton.AutoSize = true;
            continuarButton.Text = "Continuar";

            continuarButton.Click += new EventHandler(ContinuarButton_Click);
            this.Controls.Add(continuarButton);

        } else {
            MessageBox.Show("A cancelado la operacion");
        }

    }

    private double SerializarADolar(double monto, string moneda) {
        return monto / valoresMonedas[moneda];
    }

    private void ContinuarButton_Click(object? sender, EventArgs e) {
        panelRespuesta.Controls.Clear();
        textBoxMonto.Text = "";

    }
}
