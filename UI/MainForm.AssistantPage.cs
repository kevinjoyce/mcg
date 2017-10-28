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
        private void cmbAssitantFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetAssistantComponetDisable();

            if (this.cmbAssistantFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbAssistantSecond, "6", this.cmbAssistantFirst.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            this.SetAssistantEnableComponent();

            //实时生成编码
            this.GenerateAssistantCode();
        }

        private void cmbAssisantSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //全部锁定后，按选择激活
            this.SetAssistantComponetDisable();

            if (this.cmbAssistantSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 

            //根据选择，决定激活哪些控件
            this.SetAssistantEnableComponent();

            //实时生成编码
            this.GenerateAssistantCode();
        }

        private void GenerateAssistantCode()
        {
            if (txtAssistantNull.Enabled)
                GenerateAssistantNullCode();
        }

        //级联代码
        private void GenerateAssistantLevelCode()
        {
            this.txtAssistantCode.Text = "6";
            if (cmbAssistantSecond.Text != "")
                this.txtAssistantCode.Text = this.txtAssistantCode.Text + "." + this.cmbAssistantSecond.SelectedValue.ToString();
            else
                this.txtAssistantCode.Text = this.txtAssistantCode.Text + "." + this.cmbAssistantFirst.SelectedValue.ToString();
        }



        private void GenerateAssistantNullCode()
        {
            GenerateAssistantLevelCode();
            this.txtAssistantCode.Text = this.txtAssistantCode.Text
                + "."
                + this.txtAssistantNull.Text
                + "."
                + this.txtAssistantSerialNum.Text;
            /*
             * this.txtMetalContract.Enabled = false;
             * */
        }

        private void SetAssistantComponetDisable()
        {
            SetAssistantNullDisable();
        }

        private void SetAssistantEnableComponent()
        {
            SetAssistantNullEnable();
        }

        private void SetAssistantNullDisable()
        {
            this.txtAssistantNull.Enabled = false;
        }

        private void SetAssistantNullEnable()
        {
            this.txtAssistantNull.Enabled = true;
        }

        private void txtAssistantSerialNum_Click(object sender, EventArgs e)
        {
            AssistantFlowNoGenerator assistantFlowNoGenerator = new AssistantFlowNoGenerator();
            this.txtAssistantSerialNum.Text = Utility.getFlowNoCode(assistantFlowNoGenerator);
        }

        private void txtAssistantNull_TextChanged(object sender, EventArgs e)
        {
            GenerateAssistantCode();
        }

        private void txtAssistantSerialNum_TextChanged(object sender, EventArgs e)
        {
            GenerateAssistantCode();
        }

        private void btnAssistantCopy_Click(object sender, EventArgs e)
        {
            if (!Utility.IsCorrectMaterialCode(txtAssistantCode.Text))
            {
                MessageBox.Show("编码错误，请检查输入");
                return;
            }
            Clipboard.SetDataObject(txtAssistantCode.Text);
            MessageBox.Show("编码复制成功");
        }

        private void initAssistantPage() 
        {
            this.txtAssistantCode.Text = "";
            this.txtAssistantSerialNum.Text = "";
            this.txtAssistantNull.Text = "";
        }
    }
}
