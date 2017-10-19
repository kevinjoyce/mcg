using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strWhere = "iLevel1ID = 1";
            MaterialCodeGenerator.BLL.MaterialCode tab = new MaterialCodeGenerator.BLL.MaterialCode();
            List<MaterialCodeGenerator.Model.MaterialCode> list = tab.GetModelList(strWhere);

            this.comboBox1.DataSource = list;
            this.comboBox1.DisplayMember = "cLevel1Name";
            this.comboBox1.ValueMember = "iLevel1ID";
            this.comboBox1.Text = "";
        }
    }
}
