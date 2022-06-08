using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareMercado
{
    public partial class frmPrincipal : Form
    {
        double valorTotal;

        public frmPrincipal()
        {
            InitializeComponent();

            // Estilizando a listView
            lsvInfoProduto.View = View.Details;
            lsvInfoProduto.FullRowSelect = true;
            lsvInfoProduto.GridLines = true;

            // Criando as colunas (Estilização)
            lsvInfoProduto.Columns.Add("Nome Produto", 200, HorizontalAlignment.Left);
            lsvInfoProduto.Columns.Add("Quantidade", 100, HorizontalAlignment.Left);
            lsvInfoProduto.Columns.Add("Preço", 100, HorizontalAlignment.Left);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            string nome = inpProduto.Text;
            int quantidade = int.Parse(inpQuantidade.Text);
            double valor = double.Parse(inpValor.Text);

            double valor_venda = (quantidade * valor);
            valorTotal = valorTotal + (quantidade * valor);
            lblTotal.Text = $"{valorTotal.ToString("C")}";

            // Criando um Item e adicionando ele no primeiro campo
            ListViewItem lvi = new ListViewItem(nome);
            lsvInfoProduto.Items.Add(lvi);
            // Criando os subitems e os adicionando
            lvi.SubItems.Add($"{quantidade}");
            lvi.SubItems.Add($"{valor_venda.ToString("C")}");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            lsvInfoProduto.Items.Clear();
            valorTotal = 0;
            inpProduto.Text = "";
            inpQuantidade.Text = "";
            inpValor.Text = "";
            lblTotal.Text = "R$ 00,00";
        }
    }
}
