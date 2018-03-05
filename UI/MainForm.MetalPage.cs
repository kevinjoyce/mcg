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
        private void cmbMetalFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetMetalComponetDisable();

            if (this.cmbMetalFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbMetalSecond, "5", this.cmbMetalFirst.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetMetalEnableComponent();

            //实时生成编码
            this.GenerateMetalCode();
        }



        private void cmbMetalSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetMetalComponetDisable();

            if (this.cmbMetalSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 

            //级联变化
            LevelSearchor.searchAndSetLevel3(this.cmbMetalThird,
                "5",
                this.cmbMetalFirst.SelectedValue.ToString(),
                this.cmbMetalSecond.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetMetalEnableComponent();

            //实时生成编码
            this.GenerateMetalCode();
        }

        private void cmbMetalThird_SelectedIndexChanged(object sender, EventArgs e)
        {
            //实时生成编码
            this.GenerateMetalCode();
        }

        private void GenerateMetalCode()
        {
            GenerateMetalLevelCode();

            //螺纹尺寸，长度
            if (this.txtMetalSize.Enabled
                && txtMetalLength.Enabled
                && txtMetalStrength.Enabled
                && cmbMetalSurface.Enabled)
                //&& txtMetalNull.Enabled)
                GenerateMetalSizeLengthCode();

            //空置
            if (txtMetalNull.Enabled && this.cmbMetalFirst.SelectedValue.ToString() == "8")
                GenerateMetalNullCode();

            //电流，供应商
            if (txtMetalI.Enabled
                && txtMetalProvider.Enabled)
                GenerateMetalIProviderCode();

            //节数，供应商
            if (txtMetalSection.Enabled
                && txtMetalProvider.Enabled)
                GenerateMetalSectionProviderCode();

            //合同号
            if (txtMetalContract.Enabled)
                GenerateMetalContractCode();

            //空置，供应商
            if (txtMetalNull.Enabled
                && txtMetalProvider.Enabled)
                GenerateMetalNullProviderCode();

        }

        private void GenerateMetalNullProviderCode()
        {
            GenerateMetalLevelCode();
            this.txtMetalCode.Text = this.txtMetalCode.Text
                + "."
                + this.txtMetalNull.Text
                + this.txtMetalProvider.Text
                + "."
                + this.txtMetalSerialNum.Text;
            /*
            this.txtMetalNull.Enabled = true;
            this.txtMetalProvider.Enabled = true;
             * */
        }

        private void GenerateMetalContractCode()
        {
            GenerateMetalLevelCode();
            this.txtMetalCode.Text = this.txtMetalCode.Text
                + "."
                + this.txtMetalContract.Text
                + "."
                + this.txtMetalSerialNum.Text;
            /*
             * this.txtMetalContract.Enabled = false;
             * */
        }


        private void GenerateMetalSectionProviderCode()
        {
            GenerateMetalLevelCode();
            this.txtMetalCode.Text = this.txtMetalCode.Text
                + "."
                + this.txtMetalSection.Text
                + this.txtMetalProvider.Text
                + "."
                + this.txtMetalSerialNum.Text;
            /*
            this.txtMetalSection.Enabled = true;
            this.txtMetalProvider.Enabled = true;
             * */
        }

        private void GenerateMetalIProviderCode()
        {
            GenerateMetalLevelCode();
            this.txtMetalCode.Text = this.txtMetalCode.Text
                + "."
                + this.txtMetalI.Text
                + this.txtMetalProvider.Text
                + "."
                + this.txtMetalSerialNum.Text;
            /*
             * this.txtMetalI.Enabled = true;
                this.txtMetalProvider.Enabled = true;
             * */
        }

        private void GenerateMetalNullCode()
        {
            GenerateMetalLevelCode();
            this.txtMetalCode.Text = this.txtMetalCode.Text
                + "."
                + this.txtMetalNull.Text
                + "."
                + this.txtMetalSerialNum.Text;

        }

        private void GenerateMetalSizeLengthCode()
        {

            GenerateMetalLevelCode();
            this.txtMetalCode.Text = this.txtMetalCode.Text
                + "."
                + this.txtMetalSize.Text
                + this.txtMetalLength.Text
                + "."
                + this.txtMetalStrength.Text
                + this.GenerateCmbSurface();
                //+ this.txtMetalNull.Text;

            //    + this.txtMetalSurface.Text;
            /*
            this.txtMetalSize.Enabled = false;
            this.txtMetalLength.Enabled = false;
            this.txtMetalStrength.Enabled = false;
            this.txtMetalSurface.Enabled = false;
             * */
        }

        private void GenerateMetalLevelCode()
        {
            this.txtMetalCode.Text = "5.";
            if (cmbMetalThird.Text != "")
                this.txtMetalCode.Text = this.txtMetalCode.Text + this.cmbMetalThird.SelectedValue.ToString();
            else if (cmbMetalSecond.Text != "")
                this.txtMetalCode.Text = this.txtMetalCode.Text + this.cmbMetalSecond.SelectedValue.ToString();
            else
                this.txtMetalCode.Text = this.txtMetalCode.Text + this.cmbMetalFirst.SelectedValue.ToString();
        }

        private void SetMetalEnableComponent()
        {
            //螺纹尺寸，长度
            if (this.cmbMetalFirst.SelectedValue.ToString() == "1"
                || this.cmbMetalFirst.SelectedValue.ToString() == "2"
                || this.cmbMetalFirst.SelectedValue.ToString() == "3"
                || this.cmbMetalFirst.SelectedValue.ToString() == "4"
                || this.cmbMetalFirst.SelectedValue.ToString() == "5"
                || this.cmbMetalFirst.SelectedValue.ToString() == "6"
                || this.cmbMetalFirst.SelectedValue.ToString() == "7")
                this.SetMetalSizeLengthEnable();

            //空置
            if (this.cmbMetalFirst.SelectedValue.ToString() == "8"
                || this.cmbMetalFirst.SelectedValue.ToString() == "B"
                || this.cmbMetalSecond.SelectedValue.ToString() == "AB"
                || this.cmbMetalSecond.SelectedValue.ToString() == "AA")
                this.SetMetalNullEnable();

            //电流，供应商
            if (this.cmbMetalSecond.SelectedValue.ToString() == "A1"
                || this.cmbMetalSecond.SelectedValue.ToString() == "A2"
                || this.cmbMetalSecond.SelectedValue.ToString() == "A3")
                this.SetMetalIProviderEnable();

            //节数，供应商
            if (this.cmbMetalSecond.SelectedValue.ToString() == "A4")
                this.SetMetalSectionCountProviderEnable();

            //合同号
            if (this.cmbMetalSecond.SelectedValue.ToString() == "A5")
                this.SetMetalContractNoEnable();

            //空置，供应商
            if (this.cmbMetalSecond.SelectedValue.ToString() == "A6"
                || this.cmbMetalSecond.SelectedValue.ToString() == "A7"
                || this.cmbMetalSecond.SelectedValue.ToString() == "A8")
                this.SetMetalNullProviderEnable();
        }



        /*------------Enable------------*/
        private void SetMetalComponetDisable()
        {
            //螺纹尺寸，长度
            this.SetMetalSizeLengthDisable();

            //空置
            this.SetMetalNullDisable();

            //电流，供应商
            this.SetMetalIProviderDisable();

            //节数，供应商
            this.SetMetalSectionCountProviderDisable();

            //合同号
            this.SetMetalContractNoDisable();

            //空置，供应商
            this.SetMetalNullProviderDisable();
        }

        private void SetMetalSizeLengthDisable()
        {
            this.txtMetalSize.Enabled = false;
            this.txtMetalLength.Enabled = false;
            this.txtMetalStrength.Enabled = false;
            this.txtMetalSurface.Enabled = false;
            this.cmbMetalSurface.Enabled = false;
        }

        private void SetMetalNullProviderDisable()
        {
            //this.txtMetalNull.Enabled = false;
            this.txtMetalProvider.Enabled = false;
        }

        private void SetMetalContractNoDisable()
        {
            this.txtMetalContract.Enabled = false;
        }

        private void SetMetalSectionCountProviderDisable()
        {
            this.txtMetalSection.Enabled = false;
            this.txtMetalProvider.Enabled = false;
        }

        private void SetMetalIProviderDisable()
        {
            this.txtMetalI.Enabled = false;
            this.txtMetalProvider.Enabled = false;
        }

        private void SetMetalNullDisable()
        {
            this.txtMetalNull.Enabled = false;
        }


        /*------------Disable------------*/
        private void SetMetalComponetEnable()
        {
            //螺纹尺寸，长度
            this.SetMetalSizeLengthEnable();

            //空置
            this.SetMetalNullEnable();

            //电流，供应商
            this.SetMetalIProviderEnable();

            //节数，供应商
            this.SetMetalSectionCountProviderEnable();

            //合同号
            this.SetMetalContractNoEnable();

            //空置，供应商
            this.SetMetalNullProviderEnable();
        }

        private void SetMetalSizeLengthEnable()
        {
            this.txtMetalSize.Enabled = true;
            this.txtMetalLength.Enabled = true;
            this.txtMetalStrength.Enabled = true;
            this.txtMetalSurface.Enabled = true;
            this.cmbMetalSurface.Enabled = true;
            this.txtMetalSerialNum.Enabled = false;
        }

        private void SetMetalNullProviderEnable()
        {
            this.txtMetalNull.Enabled = true;
            this.txtMetalProvider.Enabled = true;
            this.txtMetalSerialNum.Enabled = true;
        }

        private void SetMetalContractNoEnable()
        {
            this.txtMetalContract.Enabled = true;
            this.txtMetalSerialNum.Enabled = true;
        }

        private void SetMetalSectionCountProviderEnable()
        {
            this.txtMetalSection.Enabled = true;
            this.txtMetalProvider.Enabled = true;
            this.txtMetalSerialNum.Enabled = true;
        }

        private void SetMetalIProviderEnable()
        {
            this.txtMetalI.Enabled = true;
            this.txtMetalProvider.Enabled = true;
            this.txtMetalSerialNum.Enabled = true;
        }

        private void SetMetalNullEnable()
        {
            this.txtMetalNull.Enabled = true;
            this.txtMetalSerialNum.Enabled = true;
        }

        private void txtMetalSerialNum_TextChanged(object sender, EventArgs e)
        {

            GenerateMetalCode();
        }

        private void txtMetalI_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalProvider_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalSection_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalContract_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalSize_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalLength_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalStrength_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalSurface_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalNull_TextChanged(object sender, EventArgs e)
        {
            GenerateMetalCode();
        }

        private void txtMetalSerialNum_Click(object sender, EventArgs e)
        {
            MetalFlowNoGenerator metalFlowNoGenerator = new MetalFlowNoGenerator();
            this.txtMetalSerialNum.Text = Utility.getFlowNoCode(metalFlowNoGenerator);
        }

        private void btnMetalCopy_Click(object sender, EventArgs e)
        {
            if (!Utility.IsCorrectMaterialCode(txtMetalCode.Text))
            {
                MessageBox.Show("编码错误，请检查输入");
                return;
            }
            Clipboard.SetDataObject(txtMetalCode.Text);
            MessageBox.Show("编码复制成功");
        }

        private void btnMetalClear_Click(object sender, EventArgs e)
        {
            initMetalPage();
        }

        private void initMetalPage() 
        {
            this.cmbMetalFirst.Text = "";
            this.cmbMetalSecond.Text = "";
            this.cmbMetalThird.Text = "";
            this.txtMetalI.Text = "";
            this.txtMetalProvider.Text = "";
            this.txtMetalContract.Text = "";
            this.txtMetalSection.Text = "";
            this.txtMetalSize.Text = "";
            this.txtMetalLength.Text = "";
            this.txtMetalStrength.Text = "";
            this.txtMetalSurface.Text = "";
            this.txtMetalNull.Text = "0";
            this.txtMetalSerialNum.Text = "";
            this.txtMetalCode.Text = "";
            this.cmbMetalSurface.Text = "";
        }

        private String GenerateCmbSurface()
        {
            String code = "";
            switch (this.cmbMetalSurface.SelectedIndex)
            {
                case 0: code = "1"; break;
                case 1: code = "2"; break;
                case 2: code = "3"; break;
                case 3: code = "4"; break;
                case 4: code = "5"; break;
                case 5: code = "6"; break;
                case 6: code = "7"; break;
                case 7: code = "8"; break;
                case 8: code = "A"; break;
                case 9: code = "9"; break;
            }
            return code;
        }
    }
}
