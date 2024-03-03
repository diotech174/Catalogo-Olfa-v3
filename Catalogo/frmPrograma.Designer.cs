namespace Catalogo
{
    partial class frmPrograma
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrograma));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPastaArquivos = new System.Windows.Forms.TextBox();
            this.btnBuscarImagens = new System.Windows.Forms.Button();
            this.btnSaidaArquivo = new System.Windows.Forms.Button();
            this.txtSaidaArquivo = new System.Windows.Forms.TextBox();
            this.btnGerarPdf = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbxTabela = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblConexaoStatus = new System.Windows.Forms.Label();
            this.btnConfigurarConexao = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbxFont = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFont = new System.Windows.Forms.Label();
            this.cbxTamanho = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxEspacamento = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMoeda = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPastaArquivos
            // 
            this.txtPastaArquivos.Location = new System.Drawing.Point(12, 73);
            this.txtPastaArquivos.Name = "txtPastaArquivos";
            this.txtPastaArquivos.ReadOnly = true;
            this.txtPastaArquivos.Size = new System.Drawing.Size(318, 23);
            this.txtPastaArquivos.TabIndex = 1;
            // 
            // btnBuscarImagens
            // 
            this.btnBuscarImagens.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarImagens.Image")));
            this.btnBuscarImagens.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBuscarImagens.Location = new System.Drawing.Point(336, 71);
            this.btnBuscarImagens.Name = "btnBuscarImagens";
            this.btnBuscarImagens.Size = new System.Drawing.Size(131, 24);
            this.btnBuscarImagens.TabIndex = 2;
            this.btnBuscarImagens.Text = "Pasta Origem";
            this.btnBuscarImagens.UseVisualStyleBackColor = true;
            this.btnBuscarImagens.Click += new System.EventHandler(this.btnBuscarImagens_Click);
            // 
            // btnSaidaArquivo
            // 
            this.btnSaidaArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnSaidaArquivo.Image")));
            this.btnSaidaArquivo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaidaArquivo.Location = new System.Drawing.Point(336, 103);
            this.btnSaidaArquivo.Name = "btnSaidaArquivo";
            this.btnSaidaArquivo.Size = new System.Drawing.Size(131, 24);
            this.btnSaidaArquivo.TabIndex = 4;
            this.btnSaidaArquivo.Text = "Saída PDF";
            this.btnSaidaArquivo.UseVisualStyleBackColor = true;
            this.btnSaidaArquivo.Click += new System.EventHandler(this.btnSaidaArquivo_Click);
            // 
            // txtSaidaArquivo
            // 
            this.txtSaidaArquivo.Location = new System.Drawing.Point(12, 103);
            this.txtSaidaArquivo.Name = "txtSaidaArquivo";
            this.txtSaidaArquivo.ReadOnly = true;
            this.txtSaidaArquivo.Size = new System.Drawing.Size(318, 23);
            this.txtSaidaArquivo.TabIndex = 3;
            // 
            // btnGerarPdf
            // 
            this.btnGerarPdf.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarPdf.Image")));
            this.btnGerarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarPdf.Location = new System.Drawing.Point(12, 367);
            this.btnGerarPdf.Name = "btnGerarPdf";
            this.btnGerarPdf.Size = new System.Drawing.Size(457, 46);
            this.btnGerarPdf.TabIndex = 11;
            this.btnGerarPdf.Text = "Gerar PDF";
            this.btnGerarPdf.UseVisualStyleBackColor = true;
            this.btnGerarPdf.Click += new System.EventHandler(this.btnGerarPdf_Click);
            // 
            // cbxTabela
            // 
            this.cbxTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTabela.FormattingEnabled = true;
            this.cbxTabela.Location = new System.Drawing.Point(12, 163);
            this.cbxTabela.Name = "cbxTabela";
            this.cbxTabela.Size = new System.Drawing.Size(274, 23);
            this.cbxTabela.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tabela de Preço";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblConexaoStatus);
            this.groupBox1.Controls.Add(this.btnConfigurarConexao);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexão Banco de Dados";
            // 
            // lblConexaoStatus
            // 
            this.lblConexaoStatus.AutoSize = true;
            this.lblConexaoStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConexaoStatus.Location = new System.Drawing.Point(6, 22);
            this.lblConexaoStatus.Name = "lblConexaoStatus";
            this.lblConexaoStatus.Size = new System.Drawing.Size(55, 21);
            this.lblConexaoStatus.TabIndex = 0;
            this.lblConexaoStatus.Text = "wait...";
            // 
            // btnConfigurarConexao
            // 
            this.btnConfigurarConexao.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigurarConexao.Image")));
            this.btnConfigurarConexao.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnConfigurarConexao.Location = new System.Drawing.Point(320, 19);
            this.btnConfigurarConexao.Name = "btnConfigurarConexao";
            this.btnConfigurarConexao.Size = new System.Drawing.Size(131, 24);
            this.btnConfigurarConexao.TabIndex = 1;
            this.btnConfigurarConexao.Text = "Configurar";
            this.btnConfigurarConexao.UseVisualStyleBackColor = true;
            this.btnConfigurarConexao.Click += new System.EventHandler(this.btnConfigurarConexao_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 419);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(457, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // cbxFont
            // 
            this.cbxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFont.FormattingEnabled = true;
            this.cbxFont.Location = new System.Drawing.Point(16, 22);
            this.cbxFont.Name = "cbxFont";
            this.cbxFont.Size = new System.Drawing.Size(225, 23);
            this.cbxFont.TabIndex = 0;
            this.cbxFont.SelectedIndexChanged += new System.EventHandler(this.cbxFont_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tamanho";
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFont.Location = new System.Drawing.Point(-1, 0);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(60, 27);
            this.lblFont.TabIndex = 0;
            this.lblFont.Text = "ABC";
            // 
            // cbxTamanho
            // 
            this.cbxTamanho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTamanho.FormattingEnabled = true;
            this.cbxTamanho.Items.AddRange(new object[] {
            "11",
            "12",
            "14",
            "16",
            "18",
            "22",
            "24",
            "26",
            "28",
            "32",
            "38",
            "42",
            "48"});
            this.cbxTamanho.Location = new System.Drawing.Point(17, 79);
            this.cbxTamanho.Name = "cbxTamanho";
            this.cbxTamanho.Size = new System.Drawing.Size(66, 23);
            this.cbxTamanho.TabIndex = 2;
            this.cbxTamanho.SelectedIndexChanged += new System.EventHandler(this.cbxTamanho_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblFont);
            this.panel1.Location = new System.Drawing.Point(292, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 158);
            this.panel1.TabIndex = 10;
            // 
            // cbxEspacamento
            // 
            this.cbxEspacamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEspacamento.FormattingEnabled = true;
            this.cbxEspacamento.Items.AddRange(new object[] {
            "35",
            "38",
            "42",
            "48",
            "50",
            "56",
            "60",
            "66",
            "70",
            "78",
            "80",
            "88",
            "90",
            "98"});
            this.cbxEspacamento.Location = new System.Drawing.Point(89, 79);
            this.cbxEspacamento.Name = "cbxEspacamento";
            this.cbxEspacamento.Size = new System.Drawing.Size(78, 23);
            this.cbxEspacamento.TabIndex = 4;
            this.cbxEspacamento.SelectedIndexChanged += new System.EventHandler(this.cbxEspacamento_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Espaçamento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxEspacamento);
            this.groupBox2.Controls.Add(this.cbxFont);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbxTamanho);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 158);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Moeda";
            // 
            // cbxMoeda
            // 
            this.cbxMoeda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMoeda.FormattingEnabled = true;
            this.cbxMoeda.Items.AddRange(new object[] {
            "REAL",
            "DOLLAR",
            "EURO"});
            this.cbxMoeda.Location = new System.Drawing.Point(292, 163);
            this.cbxMoeda.Name = "cbxMoeda";
            this.cbxMoeda.Size = new System.Drawing.Size(175, 23);
            this.cbxMoeda.TabIndex = 8;
            // 
            // frmPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(479, 451);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxMoeda);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTabela);
            this.Controls.Add(this.btnGerarPdf);
            this.Controls.Add(this.btnSaidaArquivo);
            this.Controls.Add(this.txtSaidaArquivo);
            this.Controls.Add(this.btnBuscarImagens);
            this.Controls.Add(this.txtPastaArquivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo";
            this.Load += new System.EventHandler(this.frmPrograma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtPastaArquivos;
        private Button btnBuscarImagens;
        private Button btnSaidaArquivo;
        private TextBox txtSaidaArquivo;
        private Button btnGerarPdf;
        private FolderBrowserDialog folderBrowserDialog2;
        private ComboBox cbxTabela;
        private Label label1;
        private GroupBox groupBox1;
        private Label lblConexaoStatus;
        private Button btnConfigurarConexao;
        private ProgressBar progressBar1;
        private ComboBox cbxFont;
        private Label label3;
        private Label lblFont;
        private ComboBox cbxTamanho;
        private Panel panel1;
        private ComboBox cbxEspacamento;
        private Label label4;
        private GroupBox groupBox2;
        private Label label2;
        private ComboBox cbxMoeda;
    }
}