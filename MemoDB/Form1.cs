using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MemoDB
{
    public partial class Form1 : Form
    {
        MemoConnection mCon = new MemoConnection();
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mCon.Open();
            updateDataGrid(mCon);
            mCon.Close();

            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "タイトル";
            dataGridView1.Columns[2].HeaderText = "更新日時";
            dataGridView1.Columns[2].Width = 280;

        }
        private void updateDataGrid(MemoConnection con)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT mid,title,utime FROM memo", con.getConnection());
            table.Clear();
            adp.Fill(table);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit();

            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                MemoDAO dao = new MemoDAO(mCon.getConnection());

                mCon.Open();
                dao.insert(formEdit.memo);
                updateDataGrid(mCon);
                mCon.Close();
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            DataRowView rowView = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
            DataRow row = rowView.Row;
            int mid = (int)row["mid"];

            MemoDAO dao = new MemoDAO(mCon.getConnection());

            mCon.Open();
            Memo memo = dao.findById(mid);

            FormEdit formEdit = new FormEdit();
            formEdit.memo = memo;

            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                dao.update(memo);
                updateDataGrid(mCon);
            }
            mCon.Close();



        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DataRowView rowView = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
            DataRow row = rowView.Row;
            int mid = (int)row["mid"];

            if (DialogResult.Yes == MessageBox.Show("本当に削除してもいいですか？",
        "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                MemoDAO dao = new MemoDAO(mCon.getConnection());

                mCon.Open();
                dao.delete(mid);
                updateDataGrid(mCon);
                mCon.Close();


            }
        }
    }
}
