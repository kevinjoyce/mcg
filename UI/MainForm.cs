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
                    initRawPage();
                    initRawPage();
                    break;
                case 1:
                    //MessageBox.Show("tabPage2 is Selected");
                    LoadDataTocmbStdFirst();
                    initStdPage();
                    initStdPage();
                    setStdComponentDisable();
                    break;
                case 2:
                    //MessageBox.Show("tabPage3 is Selected");
                    LoadDataTocmbElecFirst();
                    initElecPage();
                    initElecPage();
                    setElecComponentDisalbe();
                    break;
                case 3:
                    //MessageBox.Show("tabPage4 is Selected");
                    LoadDataTocmbLineFirst();
                    initLinePage();
                    initLinePage();
                    SetLineComponetDisable();
                    break;
                case 4:
                    //MessageBox.Show("tabPage5 is Selected");
                    LoadDataTocmbMetalFirst();
                    initMetalPage();
                    initMetalPage();
                    SetMetalComponetDisable();
                    break;
                case 5:
                    //MessageBox.Show("tabPage5 is Selected");
                    LoadDataTocmbAssistantFirst();
                    initAssistantPage();
                    initAssistantPage();
                    SetAssistantComponetDisable();
                    break;
                case 6:
                    initContractPage();
                    initContractPage();                    
                    break;
                case 7:
                    LoadDataTocmbMlineFirst();
                    initMlinePage();
                    initMlinePage();
                    SetMlineComponetDisable();
                    break;
                case 8:
                    LoadDataTocmbProductionFirst();
                    initProductionPage();
                    initProductionPage();
                    SetProductionComponetDisable();
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

        private void LoadDataTocmbMetalFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbMetalFirst, "5");
        }


        private void LoadDataTocmbAssistantFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbAssistantFirst, "6");
        }

        
        private void LoadDataTocmbMlineFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbMlineFirst, "8");
        }

        private void LoadDataTocmbProductionFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbProductionFirst, "9");
        }

        

        private void cmbRawLenWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateCodeRaw();
        }

        private void cmbRawLenWidth_Click(object sender, EventArgs e)
        {

        }

        private void cmbMetalSurface_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        

        

        
        
        
    }
}
