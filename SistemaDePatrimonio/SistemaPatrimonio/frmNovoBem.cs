using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaPatrimonio
{
    public partial class frmNovoBem : Form
    {

        //SELECT CONCAT(numero,' / ', anexo) AS sala FROM tblsala
        //SELECT CONCAT(numero,'|', anexo) AS valor, CONCAT(anexo,' - ',numero,' - ',descricao) AS display FROM tblsala
        DataSetPatrimonioTableAdapters.tblbemTableAdapter _Bem = new DataSetPatrimonioTableAdapters.tblbemTableAdapter();
        DataSetPatrimonioTableAdapters.tbltipoTableAdapter _TipoBem = new DataSetPatrimonioTableAdapters.tbltipoTableAdapter();
        DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter _Func = new DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter();
        DataSetPatrimonioTableAdapters.tblsalaTableAdapter _Sala = new DataSetPatrimonioTableAdapters.tblsalaTableAdapter();

        public int tipoOperacao = 0;
        public int numeroBemOriginal = 0;

        public frmNovoBem()
        {
            InitializeComponent();
            cbTipoBem.ValueMember = "idTipo";
            cbTipoBem.DisplayMember = "descricao";
            cbTipoBem.DataSource = _TipoBem.GetDataOrdenado();
        }

        private void frmNovoBem_Shown(object sender, EventArgs e)
        {
            if (tipoOperacao == 0)
            {
                this.Text = "Inserir Novo Bem / Equipamento";
                tabControl1.TabPages[0].Text = "Novo Bem / Equipamento";
                cbResponsavel.ValueMember = "siape";
                cbResponsavel.DisplayMember = "Nome";
                cbResponsavel.DataSource = _Func.GetDataByOrdenado();

                //cbSala.ValueMember = "idSala";
                //cbSala.DisplayMember = "descricao";
                //cbSala.DataSource = _Sala.GetDataByOrdenado();

                DataSetPatrimonio.tblsalaDataTable dtSala = _Sala.GetDataByOrdenado();
                DataTable dtAux = new DataTable();
                dtAux.Columns.Add("idSala", typeof(int));
                dtAux.Columns.Add("sala", typeof(string));
                foreach (var item in dtSala)
                {
                    dtAux.Rows.Add(item.idSala, item.anexo + " - " + item.descricao + " - " + item.numero.ToString());
                }
                cbSala.ValueMember = "idSala";
                cbSala.DisplayMember = "sala";
                cbSala.DataSource = dtAux;

                groupBoxRespLoc.Enabled = true;
            }
            else
            {
                this.Text = "Editar Bem / Equipamento";
                tabControl1.TabPages[0].Text = "Editar Bem / Equipamento";
                groupBoxRespLoc.Enabled = false;
            }

            txtNumPatrimonio.Focus();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //tipoOperacao: 0 - Inserção / 1 - Atualização
                if (tipoOperacao == 0)
                {
                    _Bem.InsertInicial((String.IsNullOrEmpty(txtNumPatrimonio.Text.Trim()) ? null : txtNumPatrimonio.Text),
                        txtDescricao.Text, Convert.ToInt32(cbTipoBem.SelectedValue));
                    //SELECT LAST_INSERT_ID(idBem) as ultimo from tblbem order by idBem desc limit 1
                    DataSetPatrimonio.tblbemDataTable dtBem = _Bem.GetUltimoResgistro();
                    DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
                    _Mov.InsertQuery(Convert.ToInt32(dtBem[0].idBem), cbResponsavel.SelectedValue.ToString(), Convert.ToInt32(cbSala.SelectedValue), "Primeiro Responsável pelo Bem.");
                }
                else
                {
                    _Bem.UpdateDadosIniciais((String.IsNullOrEmpty(txtNumPatrimonio.Text.Trim()) ? null : txtNumPatrimonio.Text),
                        txtDescricao.Text, Convert.ToInt32(cbTipoBem.SelectedValue), numeroBemOriginal);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Cadastrar / Editar o Bem / Equipamento.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
