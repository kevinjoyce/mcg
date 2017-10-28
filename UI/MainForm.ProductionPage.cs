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
        private void cmbProductionFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetProductionComponetDisable();

            if (this.cmbProductionFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbProductionSecond, "9", this.cmbProductionFirst.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetProductionEnableComponent();

            //实时生成编码
            this.GenerateProductionCode();
        }

        private void cmbProductionSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetProductionComponetDisable();

            if (this.cmbProductionSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 

            //级联变化
            LevelSearchor.searchAndSetLevel3(this.cmbProductionThird,
                "8",
                this.cmbProductionFirst.SelectedValue.ToString(),
                this.cmbProductionSecond.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetProductionEnableComponent();

            //实时生成编码
            this.GenerateProductionCode();
        }

        private void cmbProductionThird_SelectedIndexChanged(object sender, EventArgs e)
        {
            //实时生成编码
            this.GenerateProductionCode();
        }

        private void GenerateProductionCode()
        {
            if (this.txtProductionContract.Enabled)
                GenerateProductionContractCode();
        }

        private void GenerateProductionLevelCode()
        {
            this.txtProductionCode.Text = "9.";
            if (cmbProductionThird.Text != "")
                this.txtProductionCode.Text = this.txtProductionCode.Text + this.cmbProductionThird.SelectedValue.ToString();
            else if (cmbProductionSecond.Text != "")
                this.txtProductionCode.Text = this.txtProductionCode.Text + this.cmbProductionSecond.SelectedValue.ToString();
            else
                this.txtProductionCode.Text = this.txtProductionCode.Text + this.cmbProductionFirst.SelectedValue.ToString();
        }

        private void GenerateProductionContractCode()
        {
            GenerateProductionLevelCode();
            this.txtProductionCode.Text = this.txtProductionCode.Text
                + "."
                + this.txtProductionContract.Text
                + "."
                + this.txtProductionSerialNum.Text;
            /*
             * this.txtProductionIStrength.Enabled = false;
             * */
        }

        private void SetProductionEnableComponent()
        {
            this.SetProductionContractEnable();
        }

        private void SetProductionComponetDisable()
        {
            this.SetProductionContractDisable();
        }

        private void SetProductionContractDisable()
        {
            this.txtProductionContract.Enabled = false;
        }

        private void SetProductionContractEnable()
        {
            this.txtProductionContract.Enabled = true;
        }

        private void txtProductionContract_TextChanged(object sender, EventArgs e)
        {
            //实时生成编码
            this.GenerateProductionCode();
        }

        private void txtProductionSerialNum_TextChanged(object sender, EventArgs e)
        {
            //实时生成编码
            this.GenerateProductionCode();
        }

        private void txtProductionSerialNum_Click(object sender, EventArgs e)
        {
            ProductionFlowNoGenerator productionFlowNoGenerator = new ProductionFlowNoGenerator();
            this.txtProductionSerialNum.Text = Utility.getFlowNoCode(productionFlowNoGenerator);
        }

        private void btnCopyProduction_Click(object sender, EventArgs e)
        {
            if (!Utility.IsCorrectMaterialCode(txtProductionCode.Text))
            {
                MessageBox.Show("编码错误，请检查输入");
                return;
            }
            Clipboard.SetDataObject(txtProductionCode.Text);
            MessageBox.Show("编码复制成功");
        }

        private void initProductionPage()
        {
            this.cmbProductionFirst.Text = "";
            this.cmbProductionSecond.Text = "";
            this.cmbProductionThird.Text = "";
            this.txtProductionCode.Text = "";
            this.txtProductionSerialNum.Text = "";
            this.txtProductionContract.Text = "";
        }
    }
}
