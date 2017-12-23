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
        private void cmbMlineFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetMlineComponetDisable();

            if (this.cmbMlineFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbMlineSecond, "8", this.cmbMlineFirst.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetMlineEnableComponent();

            //实时生成编码
            this.GenerateMlineCode();
        }


        private void cmbMlineSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetMlineComponetDisable();

            if (this.cmbMlineSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 

            //级联变化
            LevelSearchor.searchAndSetLevel3(this.cmbMlineThird,
                "8",
                this.cmbMlineFirst.SelectedValue.ToString(),
                this.cmbMlineSecond.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetMlineEnableComponent();

            //实时生成编码
            this.GenerateMlineCode();
        }

        private void cmbMlineThird_SelectedIndexChanged(object sender, EventArgs e)
        {
            //实时生成编码
            this.GenerateMlineCode();
        }

        private void GenerateMlineLevelCode()
        {
            this.txtMlineCode.Text = "8.";
            if (cmbMlineThird.Text != "")
                this.txtMlineCode.Text = this.txtMlineCode.Text + this.cmbMlineThird.SelectedValue.ToString();
            else if (cmbMlineSecond.Text != "")
                this.txtMlineCode.Text = this.txtMlineCode.Text + this.cmbMlineSecond.SelectedValue.ToString();
            else
                this.txtMlineCode.Text = this.txtMlineCode.Text + this.cmbMlineFirst.SelectedValue.ToString();
        }

        private void GenerateMlineCode()
        {
            if (txtMlineIStrength.Enabled)
                GenerateMlineIStrengthCode();
        }

        private void GenerateMlineIStrengthCode()
        {
            GenerateMlineLevelCode();
            this.txtMlineCode.Text = this.txtMlineCode.Text
                + "."
                + this.txtMlineIStrength.Text
                + "."
                + this.txtMlineSerialNum.Text;
            /*
             * this.txtMlineIStrength.Enabled = false;
             * */
        }

        private void SetMlineEnableComponent()
        {
            this.SetMlineIStrengthEnable();
        }

        private void SetMlineComponetDisable()
        {
            this.SetMlineIStrengthDisable();
        }

        private void SetMlineIStrengthDisable()
        {
            this.txtMlineIStrength.Enabled = false;
        }

        private void SetMlineIStrengthEnable()
        {
            this.txtMlineIStrength.Enabled = true;
        }

        private void txtMlineIStrength_TextChanged(object sender, EventArgs e)
        {
            GenerateMlineCode();
        }

        private void txtMlineSerialNum_TextChanged(object sender, EventArgs e)
        {
            GenerateMlineCode();
        }

        private void txtMlineSerialNum_Click(object sender, EventArgs e)
        {
            MlineFlowNoGenerator mlineFlowNoGenerator = new MlineFlowNoGenerator();
            this.txtMlineSerialNum.Text = Utility.getFlowNoCode(mlineFlowNoGenerator);
        }

        private void btnMlineCopy_Click(object sender, EventArgs e)
        {
            if (!Utility.IsCorrectMaterialCode(txtMlineCode.Text))
            {
                MessageBox.Show("编码错误，请检查输入");
                return;
            }
            Clipboard.SetDataObject(txtMlineCode.Text);
            MessageBox.Show("编码复制成功");
        }
        private void btnMlineClear_Click(object sender, EventArgs e)
        {
            initMlinePage();
        }
        private void initMlinePage() 
        {
            this.cmbMlineFirst.Text = "";
            this.cmbMlineSecond.Text = "";
            this.cmbMlineThird.Text = "";
            this.txtMlineCode.Text = "";
            this.txtMlineSerialNum.Text = "";
            this.txtMlineIStrength.Text = "";
        }
    }
}
