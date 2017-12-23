using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    partial class MainForm
    {

        private void cmbContractFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.cmbContractFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbContractSecond, "2", this.cmbContractFirst.SelectedValue.ToString());
            GenerateContractCode();
        }

        private void cmbContractSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void txtContractNo_TextChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }
        
        private String ContractLevelCode()
        {
            if (this.cmbContractSecond.Text != "")
                return this.cmbContractSecond.SelectedValue.ToString();
            else if (this.cmbContractFirst.Text != "")
                return this.cmbContractFirst.SelectedValue.ToString();
            else
                return "";
        }
        //工艺流程编码生成
        private void GenerateContractCode()
        {
            this.txtContractCode.Text = "7."
                + this.ContractLevelCode()+"."
                + this.txtContractNo.Text + "."
                + Utility.getRadioButtonCode(this.rdoContractC, "C")
                + Utility.getRadioButtonCode(this.rdoContractNC, "0")
                + Utility.getRadioButtonCode(this.rdoContractZ, "Z")
                + Utility.getRadioButtonCode(this.rdoContractNZ, "0")
                + Utility.getRadioButtonCode(this.rdoContractH, "H")
                + Utility.getRadioButtonCode(this.rdoContractNH, "0")
                + Utility.getRadioButtonCode(this.rdoContractM, "M")
                + Utility.getRadioButtonCode(this.rdoContractNM, "0")
                + Utility.getRadioButtonCode(this.rdoContractP, "P")
                + Utility.getRadioButtonCode(this.rdoContractD, "D")
                + Utility.getRadioButtonCode(this.rdoContractNPD, "0")
                + Utility.getRadioButtonCode(this.rdoContractCQ_C, "C")
                + Utility.getRadioButtonCode(this.rdoContractCQ_Q, "Q")
                + Utility.getRadioButtonCode(this.rdoContractCQ_NO, "0")
                + "." + this.txtCNo.Text + this.txtPno.Text + this.txtContractSerialNum.Text;
        }

        private void rdoContractC_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractZ_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractNZ_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractH_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractNH_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractM_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractNM_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractP_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractD_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractNPD_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void txtContractSerialNum_TextChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }
        private void rdoContractCQ_C_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractCQ_Q_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void rdoContractCQ_NO_CheckedChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }
        private void txtCNo_TextChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }

        private void txtPno_TextChanged(object sender, EventArgs e)
        {
            GenerateContractCode();
        }
        private void txtContractSerialNum_Click(object sender, EventArgs e)
        {
            ContractFlowNoGenerator contractFlowNoGenerator = new ContractFlowNoGenerator();
            this.txtContractSerialNum.Text = Utility.getFlowNoCode(contractFlowNoGenerator);
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            if (!Utility.IsCorrectMaterialCode(txtContractCode.Text))
            {
                MessageBox.Show("编码错误，请检查输入");
                return;
            }
            Clipboard.SetDataObject(txtContractCode.Text);
            MessageBox.Show("编码复制成功");
        }

        private void btnContractClear_Click(object sender, EventArgs e)
        {
            initContractPage();
        }

        private void initContractPage()
        {
            this.txtContractNo.Text = "";
            this.txtContractCode.Text = "";
            this.txtContractSerialNum.Text = "";
            this.rdoContractC.Checked = false;
            this.rdoContractNC.Checked = false;
            this.rdoContractNH.Checked = false;
            this.rdoContractM.Checked = false;
            this.rdoContractNM.Checked = false;
            this.rdoContractH.Checked = false;
            this.rdoContractP.Checked = false;
            this.rdoContractNPD.Checked = false;
            this.rdoContractD.Checked = false;
            this.rdoContractZ.Checked = false;
            this.rdoContractNZ.Checked = false;
        }
    }
}
