using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoDB
{
    public partial class FormEdit : Form
    {
        internal Memo memo = null;
        public FormEdit()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            string body = textBoxBody.Text;
            if (memo == null)
            {
                memo = new Memo(0, title, body, new DateTime());
            }
            else
            {
                memo.Title = title;
                memo.Body = body;
            }
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            if(memo == null)
            {
                this.Text = "追加";
            }
            else
            {
                textBoxTitle.Text = memo.Title;
                textBoxBody.Text = memo.Body;
            }
        }
    }
}
