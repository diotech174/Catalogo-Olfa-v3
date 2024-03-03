using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class frmDatabase : Form
    {
        frmPrograma frmPrograma;

        public frmDatabase(frmPrograma frmPrograma)
        {
            InitializeComponent();
            this.frmPrograma = frmPrograma;
        }

        private void frmDatabase_Load(object sender, EventArgs e)
        {
            string host = Properties.Settings.Default.host;
            string db = Properties.Settings.Default.db;
            string user = Properties.Settings.Default.user;
            string password = Properties.Settings.Default.password;

            txtHost.Text = host;
            txtDB.Text = db;
            txtUser.Text = user;
            txtPassword.Text = password;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtHost.Text == "")
            {
                MessageBox.Show("Informe o IP ou a URL do host!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHost.Focus();
                return;
            }

            if (txtDB.Text == "")
            {
                MessageBox.Show("Informe o nome do banco de dados!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDB.Focus();
                return;
            }

            if (txtUser.Text == "")
            {
                MessageBox.Show("Informeo usuário do banco de dados!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Informe a senha do usuário do banco de dados!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            Properties.Settings.Default.host = txtHost.Text;
            Properties.Settings.Default.db = txtDB.Text;
            Properties.Settings.Default.user = txtUser.Text;
            Properties.Settings.Default.password = txtPassword.Text;

            // Salvar as alterações
            Properties.Settings.Default.Save();

            frmPrograma.Conectar();
            Close();
        }
    }
}
