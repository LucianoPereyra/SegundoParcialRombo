using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;
using System.Windows.Forms;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRombos : Form
    {

        private RepositorioRombos repositorio;
        private int cantidadRombos;
        private List<Rombo> rombos;

        public frmRombos()
        {
            InitializeComponent();
            repositorio = new RepositorioRombos();
            rombos = repositorio.GetLista();
        }

        private void CargarComboContornos(ref ToolStripComboBox tsCboBordes)
        {
            var listaBordes = Enum.GetValues(typeof(Contorno));
            foreach (var item in listaBordes)
            {
                tsCboBordes.Items.Add(item);
            }
            tsCboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            tsCboBordes.SelectedIndex = 0;

        }

        private void frmElipses_Load(object sender, EventArgs e)
        {
            CargarComboContornos(ref tsCboContornos);

            MostrarDatosGrilla();

        }

        public void MostrarDatosGrilla()
        {
            LimpiarGrilla(dgvDatos);
            foreach (var item in rombos)
            {
                var r = ConstruirFila(dgvDatos);
                SetearFila(r, item);
                AgregarFila(r, dgvDatos);
            }
            MostrarCantidadRegistros();
        }

        public void AgregarFila(DataGridViewRow row, DataGridView dgv)
        {
            dgv.Rows.Add(row);
        }

        public void SetearFila(DataGridViewRow row, Rombo obj)
        {

            row.Cells[colMayor.Index].Value = obj.DiagonalMayor;
            row.Cells[colMenor.Index].Value = obj.DiagonalMenor;
            row.Cells[colBorde.Index].Value = obj.Contorno;
            row.Cells[colLado.Index].Value = obj.ObtenerLado().ToString("N2");
            row.Cells[colPerimetro.Index].Value = obj.ObtenerPerimetro().ToString("N2");
            row.Cells[colArea.Index].Value = obj.ObtenerArea().ToString("N2");

            row.Tag = obj;

        }

        public DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;
        }

        public void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }

        public void MostrarCantidadRegistros()
        {
            cantidadRombos = repositorio.GetCantidad();
            txtCantidad.Text = cantidadRombos.ToString();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRomboAE form = new frmRomboAE() { Text = "Agregar rombo" };
            DialogResult dr = form.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            Rombo? rombo = form.GetRombo();

            if(!repositorio.Existe(rombo))
            {
                repositorio.Agregar(rombo);
                rombos = repositorio.GetLista();
                MostrarDatosGrilla();

                string msg = $"Rombo {rombo.Contorno} agregado\nArea: {rombo.ObtenerArea().ToString("N2")}\nPerimetro: {rombo.ObtenerPerimetro().ToString("N2")}";

                MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Este rombo ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count == 0) return;

            DialogResult dr = MessageBox.Show("¿Estas seguro de esto?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            var rBorrar = dgvDatos.SelectedRows[0];
            var rombo = rBorrar.Tag as Rombo;

            repositorio.Eliminar(rombo);
            rombos = repositorio.GetLista();
            MostrarDatosGrilla();

            MessageBox.Show("Rombo eliminado!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            rombos = repositorio.GetLista();
            MostrarDatosGrilla();
        }

        private void lado09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rombos = repositorio.OrdernarPorLado();
            MostrarDatosGrilla();
        }

        private void lado90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rombos = repositorio.OrdernarPorLadoDescendente();
            MostrarDatosGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
