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
            
            this.SetComponentDisabled();
            LoadDataToCmbRawFirst();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        

        private void tbControlMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tbControlMaterial.SelectedIndex)
            {
                case 0:
                    //MessageBox.Show("tabPage1 is Selected");
                    LoadDataToCmbRawFirst();
                    break;
                case 1:
                    //MessageBox.Show("tabPage2 is Selected");
                    LoadDataTocmbStdFirst();
                    break;
                case 2:
                    //MessageBox.Show("tabPage3 is Selected");
                    LoadDataTocmbElecFirst();
                    break;
                case 3:
                    //MessageBox.Show("tabPage4 is Selected");
                    LoadDataTocmbLineFirst();
                    break;
                case 4:
                    //MessageBox.Show("tabPage5 is Selected");
                    //LoadDataTocmbMetalFirst();
                    break;
                case 5:
                    //MessageBox.Show("tabPage5 is Selected");
                    //LoadDataTocmbEquipFirst();
                    break;
                case 8:
                    //LoadDataTocmbProductionFirst();
                    break;
            }
        }

        

        private void LoadDataToCmbRawFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbRawFirst, "1");
        }
        private void LoadDataTocmbStdFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbStdFirst, "2");
        }

        private void LoadDataTocmbElecFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbElecFirst, "3");
        }

        private void LoadDataTocmbLineFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbLineFirst, "4");
        }

        private void txtElecSerialNum_Click(object sender, EventArgs e)
        {

        }

        private void txtElecSerialNum_TextChanged(object sender, EventArgs e)
        {

        }

        


        
    }
}
