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
                    LoadDataTocmbContractFirst();
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

        private void LoadDataTocmbContractFirst()
        {
            LevelSearchor.searchAndSetLevel1(this.cmbContractFirst, "7");
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

        //private void txtElecU_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecI_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecCapacity_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecBlock_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecSize_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void txtCap_TextChanged(object sender, EventArgs e)
        {
            //电压、电容
            if (this.txtElecU.Enabled && this.txtCap.Enabled)
                GenerateUCapCode();
        }

        //private void txtElecGroupNum_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void txtElecPower_TextChanged(object sender, EventArgs e)
        {
            if (this.txtElecU.Enabled && this.txtElecPower.Enabled)
                GenerateUPowerCode();
        }

        //private void rdoContractCQ_C_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbACDC_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecColor_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        

        

        

        

        //private void txtThick_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtDM_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void rdoNPD_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void rdoD_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void rdoP_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbStdSecond_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbStdFirst_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbACDC_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecDelay_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecNull_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecTouchPointNum_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecColor_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecDist_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtColNum_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtElecSupportPointNum_TextChanged(object sender, EventArgs e)
        //{

        //}

        
        

        

        
        
        
    }
}
