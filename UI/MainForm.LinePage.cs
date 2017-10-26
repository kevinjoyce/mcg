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
        private void cmbLineFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetLineComponetDisable();

            if (this.cmbLineFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbLineSecond, "4", this.cmbLineFirst.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetLineEnableComponent();

            //实时生成编码
            this.GenerateLineCode();
        }

        private void cmbLineSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetLineComponetDisable();

            if (this.cmbLineSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 

            //根据选择，决定激活哪些控件
            this.SetLineEnableComponent();

            //实时生成编码
            this.GenerateLineCode();
        }

        //根据选择的选项，设置激活的组件
        private void SetLineEnableComponent()
        {
            SetLineComponetDisable();

            //一次线，二次线
            if (this.cmbLineFirst.SelectedValue.ToString() == "1"
                || this.cmbLineFirst.SelectedValue.ToString() == "2")
            {
                this.SetColorUEnable();
            }

            //通讯线
            if (this.cmbLineFirst.SelectedValue.ToString() == "3")
            {
                this.SetInConnEnable();
            }
        }



        private void GenerateLineCode()
        {
            this.GenerateLineLevelCode();

            if (this.txtLineColor.Enabled
                && this.txtLineU.Enabled
                && this.txtLineSquare.Enabled)
                this.GenerateColorUCode();

            if (this.txtLineIn.Enabled
                && this.txtLineCon.Enabled
                && this.txtLineLength.Enabled)
                this.GenerateInConnCode();
        }

        //产生代码，进口，接口，长度
        private void GenerateInConnCode()
        {
            GenerateLineLevelCode();
            this.txtLineCode.Text = this.txtLineCode.Text
                + "."
                + this.txtLineIn.Text
                + this.txtLineCon.Text
                + this.txtLineLength.Text
                + "."
                + this.txtLineSerialNum.Text;
        }
        //产生代码，颜色，电压，平方数
        private void GenerateColorUCode()
        {
            GenerateLineLevelCode();
            this.txtLineCode.Text = this.txtLineCode.Text
                + "."
                + this.txtLineColor.Text
                + this.txtLineU.Text
                + this.txtLineSquare.Text
                + "."
                + this.txtLineSerialNum.Text;
        }

        //级联代码
        private void GenerateLineLevelCode()
        {
            if (cmbLineSecond.Text != "")
                this.txtLineCode.Text = this.cmbLineSecond.SelectedValue.ToString();
            else
                this.txtLineCode.Text = this.cmbLineFirst.SelectedValue.ToString();
        }

        //全部锁定
        private void SetLineComponetDisable()
        {
            SetColorUDisable();
            SetInConnDisable();
        }

        /********Disable************/
        private void SetInConnDisable()
        {
            //进口、接口、长度
            this.txtLineIn.Enabled = false;
            this.txtLineCon.Enabled = false;
            this.txtLineLength.Enabled = false;
        }

        private void SetColorUDisable()
        {
            //电压、颜色、平方数
            this.txtLineColor.Enabled = false;
            this.txtLineU.Enabled = false;
            this.txtLineSquare.Enabled = false;
        }
        /********Enable************/
        private void SetInConnEnable()
        {
            //进口、接口、长度
            this.txtLineIn.Enabled = true;
            this.txtLineCon.Enabled = true;
            this.txtLineLength.Enabled = true;
        }

        private void SetColorUEnable()
        {
            //电压、颜色、平方数
            this.txtLineColor.Enabled = true;
            this.txtLineU.Enabled = true;
            this.txtLineSquare.Enabled = true;
        }

        private void txtLineColor_TextChanged(object sender, EventArgs e)
        {
            GenerateLineCode();
        }

        private void txtLineU_TextChanged(object sender, EventArgs e)
        {
            GenerateLineCode();
        }

        private void txtLineSquare_TextChanged(object sender, EventArgs e)
        {
            GenerateLineCode();
        }

        private void txtLineIn_TextChanged(object sender, EventArgs e)
        {
            GenerateLineCode();
        }

        private void txtLineCon_TextChanged(object sender, EventArgs e)
        {
            GenerateLineCode();
        }

        private void txtLineLength_TextChanged(object sender, EventArgs e)
        {
            GenerateLineCode();
        }

        private void txtLineSerialNum_Click(object sender, EventArgs e)
        {
            LineFlowNoGenerator lineFlowNoGenerator = new LineFlowNoGenerator();
            this.txtLineSerialNum.Text = Utility.getFlowNoCode(lineFlowNoGenerator);
        }

        private void txtLineSerialNum_TextChanged(object sender, EventArgs e)
        {
            GenerateLineCode();
        }

        private void btnCopyLine_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtLineCode.Text);
            MessageBox.Show("编码复制成功");
        }

        
    }
}
