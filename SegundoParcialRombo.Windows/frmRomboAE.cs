using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {

        private Rombo rombo;
        public frmRomboAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (rombo != null)
            {

                txtDiagonalMayor.Text = rombo.DiagonalMayor.ToString();
                txtDiagonalMenor.Text = rombo.DiagonalMenor.ToString();

                switch (rombo.Contorno)
                {
                    case Contorno.Solido:
                        rbtSolido.Checked = true;
                        break;
                    case Contorno.Punteado:
                        rbtPunteado.Checked = true;
                        break;
                    case Contorno.Rayado:
                        rbtRayado.Checked = true;
                        break;
                    case Contorno.Doble:
                        rbtDoble.Checked = true;
                        break;
                }

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {

                if (rombo is null)
                {

                    rombo = new Rombo();

                }

                rombo.DiagonalMayor = int.Parse(txtDiagonalMayor.Text);
                rombo.DiagonalMenor = int.Parse(txtDiagonalMenor.Text);
                rombo.Lado = rombo.ObtenerLado();

                if (rbtSolido.Checked)
                {
                    rombo.Contorno = Contorno.Solido;
                }
                else if (rbtPunteado.Checked)
                {
                    rombo.Contorno = Contorno.Punteado;
                }
                else if (rbtRayado.Checked)
                {
                    rombo.Contorno = Contorno.Rayado;
                }
                else
                {
                    rombo.Contorno = Contorno.Doble;
                }

                DialogResult = DialogResult.OK;

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Rombo GetRombo()
        {
            return rombo;
        }

        public void SetRombo(Rombo rom)
        {
            rombo = rom;
        }

        public bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (!int.TryParse(txtDiagonalMayor.Text, out int diagonalMayor) || diagonalMayor <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMayor, "Ingrese un valor valido!");
            }

            if (!int.TryParse(txtDiagonalMenor.Text, out int diagonalMenor) || diagonalMenor <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMenor, "Ingrese un valor valido!");
            }

            return valido;

        }

        private void frmRomboAE_Load(object sender, EventArgs e)
        {

        }
    }
}
