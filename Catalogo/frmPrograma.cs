using System.Windows.Forms;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Font;
using iText.Kernel.Font;
using System.Collections;
using MySqlConnector;
using iText.Kernel.Pdf.Canvas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;
using System.Drawing.Text;
using iText.Layout.Font;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Catalogo
{
    public partial class frmPrograma : Form
    {
        private string connectionString = "";

        public frmPrograma()
        {
            InitializeComponent();
        }

        private void btnBuscarImagens_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Tag = "Selecione a pasta das imagens";
            folderBrowserDialog1.ShowDialog();
            txtPastaArquivos.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnSaidaArquivo_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.Tag = "Selecione a pasta de saída do arquivo";
            folderBrowserDialog2.ShowDialog();
            txtSaidaArquivo.Text = folderBrowserDialog2.SelectedPath;
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            Dados dados = new Dados();

            if (txtPastaArquivos.Text == "")
            {
                MessageBox.Show("Informe a pasta de origem!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPastaArquivos.Focus();
                return;
            }

            if (txtSaidaArquivo.Text == "")
            {
                MessageBox.Show("Informe a pasta de saída!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaidaArquivo.Focus();
                return;
            }

            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
                using (var pdfWriter = new PdfWriter(@"" + txtSaidaArquivo.Text + "\\"+timestamp+"-Catalogo.pdf"))
                {
                    using (var pdf = new PdfDocument(pdfWriter))
                    {
                        var document = new Document(pdf);

                        // Lista de caminhos das imagens no diretório
                        var imagens = Directory.GetFiles(@"" + txtPastaArquivos.Text, "*.jpg")
                       .Union(Directory.GetFiles(@"" + txtPastaArquivos.Text, "*.png"))
                       .OrderBy(f => Path.GetFileName(f))
                       .ToArray();

                        progressBar1.Value = 0;
                        progressBar1.Maximum = imagens.Count();
                        int progresso = 0;

                        this.Enabled = false;

                        foreach (var imagemPath in imagens)
                        {
                            pdf.AddNewPage();

                            // Obtém o tamanho da página
                            var pageSize = pdf.GetDefaultPageSize();

                            // Obtém o tamanho da imagem
                            var imagem = iText.IO.Image.ImageDataFactory.Create(imagemPath);
                            var imagemWidth = 500;
                            var imagemHeight = 500;

                            // Calcula as coordenadas para centralizar a imagem
                            var x = (pageSize.GetWidth() - imagemWidth) / 2;
                            var y = (pageSize.GetHeight() - imagemHeight) / 2;

                            // Desenha a imagem como plano de fundo na página
                            var canvasProduto = new PdfCanvas(pdf.GetLastPage());

                            // Adiciona um background com imagem à página
                            var backgroundImagem = iText.IO.Image.ImageDataFactory.Create(@"resources/background.png");
                            canvasProduto.AddImage(backgroundImagem, pageSize.GetWidth(), 0, 0, pageSize.GetHeight(), 0, 0, false);
                            canvasProduto.AddImage(imagem, imagemWidth, 0, 0, imagemHeight, x, y, false);

                            // Adiciona o nome do arquivo abaixo da imagem
                            var nomeArquivo = new FileInfo(imagemPath).Name;

                            // Adiciona o nome do arquivo com fonte e tamanho personalizados
                            string file = nomeArquivo.Replace(".png", "").Replace(".PNG", "").Replace(".jpg", "").Replace(".JPG", "");

                            // Cria um novo Canvas para os parágrafos
                            var canvasParagrafos = new PdfCanvas(pdf.GetLastPage());

                            var paragrafo1 = new Paragraph(file)
                                .SetFont(PdfFontFactory.CreateFont("c:\\windows\\fonts\\arial.ttf", PdfEncodings.IDENTITY_H, true))
                                .SetFontSize(28);

                            string tabela = cbxTabela.Text;
                            string[] arr = tabela.Split(" - ");

                            double preco = dados.getPreco(file, arr[0]);
                            double peso = dados.getPeso(arr[0]);

                            string valorFormatado = "";

                            switch (cbxMoeda.Text)
                            {
                                case "REAL":
                                    valorFormatado = preco.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                                    break;

                                case "DOLLAR":
                                    valorFormatado = preco.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                                    break;

                                case "EURO":
                                    valorFormatado = preco.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-EU"));
                                    break;

                                default:
                                    valorFormatado = preco.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                                    break;
                            }

                            var paragrafo2 = new Paragraph(valorFormatado)
                                .SetFont(PdfFontFactory.CreateFont("c:\\windows\\fonts\\arial.ttf", PdfEncodings.IDENTITY_H, true))
                                .SetFontSize(28);

                            string paragrafo3 = String.Format("{0:0.00}", peso);

                            // Define as coordenadas corretas para os parágrafos
                            var paragrafoX = 250; //(Convert.ToInt32(pageSize.GetWidth()) - Convert.ToInt32(paragrafo1.GetWidth())) / 3;
                            var paragrafoY = (pageSize.GetHeight() + imagemHeight) / 11;

                            ComboBoxItem font = (ComboBoxItem)cbxFont.SelectedItem;

                            int espacamento = 35;
                            if (cbxEspacamento.Text != "")
                            {
                                espacamento = Convert.ToInt16(cbxEspacamento.Text);
                            }

                            // Adiciona os parágrafos à página
                            canvasParagrafos
                                .BeginText()
                                .SetFontAndSize(PdfFontFactory.CreateFont(font.Value, PdfEncodings.IDENTITY_H, true), Convert.ToInt32(cbxTamanho.Text))
                                .MoveText(paragrafoX, paragrafoY)
                                .ShowText(file)
                                .MoveText(0, -espacamento)
                                .ShowText(valorFormatado)
                                .MoveText(0, -espacamento)
                                .ShowText("Peso Kg. " + paragrafo3)
                                .SetWordSpacing(10)
                                .EndText();

                            var worker = new BackgroundWorker();
                            worker.WorkerReportsProgress = true;
                            worker.DoWork += (sender, e) =>
                            {
                                progresso++;
                                worker.ReportProgress(progresso);
                            };

                            worker.ProgressChanged += (sender, e) =>
                            {
                                progressBar1.Value = e.ProgressPercentage;
                            };

                            worker.RunWorkerCompleted += (sender, e) =>
                            {
                                if (progressBar1.Value == progressBar1.Maximum)
                                {
                                    MessageBox.Show("PDF gerado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Enabled = true;
                                }
                            };

                            // Inicia o trabalho em segundo plano
                            worker.RunWorkerAsync();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show($"Erro ao criar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Conectar()
        {
            string host = Properties.Settings.Default.host;
            string db = Properties.Settings.Default.db;
            string user = Properties.Settings.Default.user;
            string password = Properties.Settings.Default.password;

            connectionString = "Server=" + host + ";Database=" + db + ";User Id=" + user + ";Password=" + password + ";";

            using MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Dados d = new Dados();
                ArrayList tabelas = d.getTabelas();

                cbxTabela.Items.Clear();

                foreach (Tabelas tabela in tabelas)
                {
                    cbxTabela.Items.Add(tabela.id + " - " + tabela.descricao);
                }

                cbxTabela.SelectedIndex = 0;

                lblConexaoStatus.Text = "Conexão bem sucedida!";
                lblConexaoStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblConexaoStatus.Text = "Conexão falhou!";
                lblConexaoStatus.ForeColor = Color.Red;
                MessageBox.Show($"Erro ao conectar com o banco de dados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPrograma_Load(object sender, EventArgs e)
        {
            Conectar();

            CarregarFontes();

            if (Properties.Settings.Default.tamanho > 0)
            {
                cbxTamanho.Text = Properties.Settings.Default.tamanho.ToString();
            } else
            {
                cbxTamanho.SelectedIndex = 0;
            }

            if (Properties.Settings.Default.Espacamento > 0)
            {
                cbxEspacamento.Text = Properties.Settings.Default.Espacamento.ToString();
            }
            else
            {
                cbxEspacamento.SelectedIndex = 0;
            }

            cbxMoeda.SelectedIndex = 0;
        }

        private void btnConfigurarConexao_Click(object sender, EventArgs e)
        {
            frmDatabase frmDatabase = new frmDatabase(this);
            frmDatabase.ShowDialog();
        }

        private void cbxFont_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBoxItem font =(ComboBoxItem)cbxFont.SelectedItem;
            Properties.Settings.Default.font = font.Value;
            Properties.Settings.Default.Save();

            if (cbxTamanho.Text != "")
            {
                lblFont.Font = new Font(cbxFont.Text, Convert.ToInt32(cbxTamanho.Text), FontStyle.Regular);
            }
        }

        private void cbxEspacamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Espacamento = Convert.ToInt16(cbxEspacamento.Text);
            Properties.Settings.Default.Save();
        }

        private void cbxTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.tamanho = Convert.ToInt32(cbxTamanho.Text);
            Properties.Settings.Default.Save();

            if (cbxFont.SelectedItem != null)
            {
                Font myFont = new Font(cbxFont.Text, Convert.ToInt32(cbxTamanho.Text), FontStyle.Regular);
                lblFont.Font = myFont;
            }
            else
            {
                Font myFont = new Font(cbxFont.Text, Convert.ToInt32(cbxTamanho.Text), FontStyle.Regular);
                lblFont.Font = myFont;
            }
        }

        private void CarregarFontes()
        {
            int i = 0;
            int selected = 0;

            string[] arquivos = Directory.GetFiles("c:\\Windows\\Fonts\\");
            ArrayList fonts = new ArrayList();

            foreach (string arquivo in arquivos)
            {
                string fontName = ObterNomeDaFonte(arquivo);
                ComboBoxItem item = new ComboBoxItem(arquivo, fontName);

                if (arquivo.IndexOf(".ttf") > -1)
                {
                    if (!fonts.Contains(fontName)) {

                        cbxFont.Items.Add(item);
                        fonts.Add(fontName);

                        if (arquivo == Properties.Settings.Default.font)
                        {
                            selected = i;
                        }

                        i++;
                    }
                }
            }
            cbxFont.SelectedIndex = selected;
        }

        private string ObterNomeDaFonte(string caminhoArquivoTTF)
        {
            try
            {
                // Criando uma coleção de fontes privadas
                using (PrivateFontCollection fontCollection = new PrivateFontCollection())
                {
                    // Adicionando a fonte à coleção
                    fontCollection.AddFontFile(caminhoArquivoTTF);

                    // Verificando se há pelo menos uma fonte na coleção
                    if (fontCollection.Families.Length > 0)
                    {
                        // Retornando o nome da primeira fonte na coleção
                        return fontCollection.Families[0].Name;
                    }
                    else
                    {
                        return "Fonte não encontrada.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Lidando com exceções, se ocorrerem
                return $"Erro ao obter o nome da fonte: {ex.Message}";
            }
        }

        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ComboBoxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}