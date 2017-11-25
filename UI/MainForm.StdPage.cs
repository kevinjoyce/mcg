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
        private void cmbStdFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            setStdComponentDisable();
            if (this.cmbStdFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbStdSecond, "2", this.cmbStdFirst.SelectedValue.ToString());
            GenerateStdLevelCode();
        }

        private void cmbStdSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            setStdComponentDisable();
            if (this.cmbStdSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错

            if (this.cmbStdSecond.SelectedValue.ToString() == "11" || this.cmbStdSecond.SelectedValue.ToString() == "12")
            {
                setStdComponentEnable();
            }

            GenerateStdLevelCode();
        }

        //端面、长度填好后编码生成

        private void GenerateStdDMLength() 
        {
            GenerateStdLevelCode();
            GenerateStdWorkFlowCode();
            GenerateStdFlowNo();
            this.txtStdCode.Text = this.txtStdCode.Text + "." + this.txtStdDM.Text + "." + this.txtStdLength.Text;
        }

        //流水号填好后的编码生成
        private void GenerateStdFlowNo() 
        {
            if (this.cmbStdFirst.Text == "") return;
            GenerateStdLevelCode();
            GenerateStdWorkFlowCode();
            if(this.txtStdSerialNum.Text!="")
                this.txtStdCode.Text = this.txtStdCode.Text + "." + this.txtStdSerialNum.Text;
        }

        private void txtStdSerialNum_Click(object sender, EventArgs e)
        {
            StdFlowNoGenerator stdFlowNoGenerator = new StdFlowNoGenerator();
            this.txtStdSerialNum.Text = Utility.getFlowNoCode(stdFlowNoGenerator);
        }


        //工艺流程编码生成
        private void GenerateStdWorkFlowCode() 
        {
            GenerateStdLevelCode();
            this.txtStdCode.Text = this.txtStdCode.Text + "."
                + Utility.getRadioButtonCode(this.rdoC, "C")
                + Utility.getRadioButtonCode(this.rdoNC, "0")
                + Utility.getRadioButtonCode(this.rdoZ, "Z")
                + Utility.getRadioButtonCode(this.rdoNZ, "0")
                + Utility.getRadioButtonCode(this.rdoH, "H")
                + Utility.getRadioButtonCode(this.rdoNH, "0")
                + Utility.getRadioButtonCode(this.rdoM, "M")
                + Utility.getRadioButtonCode(this.rdoNM, "0")
                + Utility.getRadioButtonCode(this.rdoP, "P")
                + Utility.getRadioButtonCode(this.rdoD, "D")
                + Utility.getRadioButtonCode(this.rdoNPD, "0")
                + Utility.getRadioButtonCode(this.rdoCQ_C, "C")
                + Utility.getRadioButtonCode(this.rdoCQ_Q, "Q")
                + Utility.getRadioButtonCode(this.rdoCQ_NO, "0");
        }

        //一级、二级编码生成
        private void GenerateStdLevelCode() 
        {
            if(this.cmbStdSecond.Text !="")
                this.txtStdCode.Text = "2." + this.cmbStdSecond.SelectedValue.ToString();
            else if(this.cmbStdFirst.Text != "")
                this.txtStdCode.Text = "2." + this.cmbStdFirst.SelectedValue.ToString();
        }

        private void setStdComponentDisable() 
        {
            this.txtStdDM.Enabled = false;
            this.txtStdLength.Enabled = false;
        }

        private void setStdComponentEnable()
        {
            this.txtStdDM.Enabled = true;
            this.txtStdLength.Enabled = true;
        }

        private void rdoC_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoNC_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoZ_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoNZ_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoH_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoNH_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoM_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoNM_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoP_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoD_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void rdoNPD_CheckedChanged(object sender, EventArgs e)
        {
            GenerateStdWorkFlowCode();
        }

        private void txtStdSerialNum_TextChanged(object sender, EventArgs e)
        {
            GenerateStdFlowNo();
        }

        private void txtStdDM_TextChanged(object sender, EventArgs e)
        {
            GenerateStdDMLength();
        }

        private void txtStdLength_TextChanged(object sender, EventArgs e)
        {
            GenerateStdDMLength();
        }

        private void btnCopyStandard_Click(object sender, EventArgs e)
        {
                  
        
            if (!Utility.IsCorrectMaterialCode(txtStdCode.Text))
            {
                MessageBox.Show("编码错误，请检查输入");
                return;
            }
        
            Clipboard.SetDataObject(txtStdCode.Text);
            MessageBox.Show("编码复制成功");
        }

        private void initStdPage() 
        {
            this.cmbStdFirst.Text = "";
            this.cmbStdSecond.Text = "";
            this.txtStdCode.Text = "";
            this.txtStdDM.Text = "";
            this.txtStdLength.Text = "";
            this.txtStdSerialNum.Text = "";
            this.rdoC.Checked = false;
            this.rdoNC.Checked = false;
            this.rdoNH.Checked = false;
            this.rdoM.Checked = false;
            this.rdoNM.Checked = false;
            this.rdoH.Checked = false;
            this.rdoP.Checked = false;
            this.rdoNPD.Checked = false;
            this.rdoD.Checked = false;
            this.rdoZ.Checked = false;
            this.rdoNZ.Checked = false;
        }

    }
}
