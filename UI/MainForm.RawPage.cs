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
        private void cmbRawFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化，全部处于未激活
            this.SetComponentDisabled();

            if (this.cmbRawFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错            
     

			//设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbRawSecond, "1", this.cmbRawFirst.SelectedValue.ToString());
            SetTxtCodeNull();
        }

        private void cmbRawSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化，全部处于未激活
            this.SetComponentDisabled();

            if (this.cmbRawSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            

            if (this.cmbRawSecond.SelectedValue.ToString() == "2" && this.cmbRawFirst.SelectedValue.ToString() == "1")
            {
                //非金属，材料牌号，厚度和长宽激活输入
                this.SetTxtRawEnabled();
                this.SetTxtThickAndTxtSizeEnabled();
            }

            //级联变化
            LevelSearchor.searchAndSetLevel3(this.cmbRawThird, 
                "1", 
                this.cmbRawFirst.SelectedValue.ToString(),
                this.cmbRawSecond.SelectedValue.ToString());

            SetTxtCodeNull();
        }

        private void cmbRawThird_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化，全部处于未激活
            this.SetComponentDisabled();

            //第三级开始显示编码
            if (this.cmbRawThird.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 

            if (this.cmbRawFirst.SelectedValue.ToString() == "2")
            {
                //非板材：材料牌号、端面和长度激活输入
                this.SetTxtRawEnabled();
                this.SetTxtDMAndTxtLengthEnabled();
            }
            
            if (this.cmbRawFirst.SelectedValue.ToString() == "1" && this.cmbRawSecond.SelectedValue.ToString() == "2")
            {
                //板材，非金属：材料牌号，厚度和长宽激活输入
                this.SetTxtRawEnabled();
                this.SetTxtThickAndTxtSizeEnabled();
            }

            if (this.cmbRawFirst.SelectedValue.ToString() == "1" && this.cmbRawSecond.SelectedValue.ToString() == "1")
            {
                //板材，金属：材料牌号，厚度和长宽激活输入
                if ("118" == this.cmbRawThird.SelectedValue.ToString())
                {
                    //铜牌
                    this.SetRoundAngleEnabled();
                }
                else
                {
					//其他金属板材
                    this.SetTxtRawEnabled();
                    this.SetTxtThickAndTxtSizeEnabled();
                }
            }

            GenerateLevelCode();
        }


        private void FillNumToTxtCode()
        {
            this.txtCode.Text = "";
            this.txtCode.Text = this.cmbRawThird.SelectedValue + "."
                + this.txtRaw.Text + "."
                + this.txtThick.Text + "."
                + this.txtSize.Text;
        }

        private void GenerateLevelCode() 
        {
			//级联代码生成
            this.txtCode.Text = "";
            if (this.cmbRawThird.Text != "")
            {
                this.txtCode.Text = this.cmbRawThird.SelectedValue.ToString() + ".";
            }
        }

        private void txtRaw_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRaw();
        }

        private void txtThick_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRaw();
        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRaw();
        }

        private void txtDM_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRaw();
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRaw();
        }

        private void GenerateCodeRaw()
        {

            if (NotAllLevelSeleted())
            {
                MessageBox.Show("请先选择级联菜单！");
                return;
            }

            if (this.cmbRawFirst.SelectedValue.ToString() == "1")
            {
                //牌号、厚度、长宽代码生成
                this.txtCode.Text = this.cmbRawThird.SelectedValue.ToString() + "."
                    + this.txtRaw.Text + "."
                    + this.txtThick.Text + "."
                    + this.txtSize.Text;
            }
            else
            {
                //牌号、端面、长度代码生成
                this.txtCode.Text = this.cmbRawThird.SelectedValue.ToString() + "."
                    + this.txtRaw.Text + "."
                    + this.txtDM.Text + "."
                    + this.txtLength.Text;
            }
        }

        private void rdoRoundAngle_CheckedChanged(object sender, EventArgs e)
        {
            GenerateCodeRound();
        }

        private void rdoRightAngle_CheckedChanged(object sender, EventArgs e)
        {
            GenerateCodeRound();
        }

        private void rdoTinning_CheckedChanged(object sender, EventArgs e)
        {
            GenerateCodeRound();
        }

        private void rdoNoTinning_CheckedChanged(object sender, EventArgs e)
        {
            GenerateCodeRound();
        }

        private void txtNull_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRound();
        }

        private void txtRoundThick_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRound();
        }

        private void txtRoundWidth_TextChanged(object sender, EventArgs e)
        {
            GenerateCodeRound();
        }
        private void GenerateCodeRound() 
        {
            string roundOrRight = "";
            string tinningOrNot = "";
            if (NotAllLevelSeleted())
            {
                MessageBox.Show("请先选择级联菜单！");
                return;
            }

            if (rdoRoundAngle.Checked)
            {
                roundOrRight = "1";//圆角
            }

            if (rdoRightAngle.Checked)
            {
                roundOrRight = "0";//直角
            }

            if (rdoTinning.Checked)
            {
                tinningOrNot = "1";//镀锡
            }
            
			if(rdoNoTinning.Checked)
            {
                tinningOrNot = "0";//不镀锡
            }

            this.txtCode.Text = this.cmbRawThird.SelectedValue.ToString() + "."
                    + roundOrRight + "."
                    + tinningOrNot + "."
                    + this.txtNull.Text + "."
                    + this.txtRoundThick.Text + "."
                    + this.txtRoundWidth.Text;

        }

        private bool NotAllLevelSeleted() 
        {
            return this.cmbRawFirst.Text == "" || this.cmbRawSecond.Text == "" || this.cmbRawThird.Text == "";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtCode.Text);
            MessageBox.Show("编码复制成功");
        }

        private void SetTxtCodeNull()
        {
            this.txtCode.Text = "";
        }

		//设置全部字段3可用
        private void SetComponentEnabled() 
        {
            SetTxtRawEnabled();
            SetTxtThickAndTxtSizeEnabled();
            SetTxtDMAndTxtLengthEnabled();
            SetRoundAngleEnabled();
        }

        //设置全部字段3不可用
        private void SetComponentDisabled()
        {
            SetTxtRawDisabled();
            SetTxtThickAndTxtSizeDisabled();
            SetTxtDMAndTxtLengthDisabled();
            SetRoundAngleDisabled();
        }

		//设置（铜排）字段3可用
        private void SetRoundAngleEnabled()
        {
            this.rdoRoundAngle.Enabled = true;
            this.rdoRightAngle.Enabled = true;
            this.txtRoundThick.Enabled = true;
            this.txtRoundWidth.Enabled = true;
            this.rdoTinning.Enabled = true;
            this.rdoNoTinning.Enabled = true;
            this.txtNull.Enabled = true;
        }
        //设置（铜排）字段3不可用
        private void SetRoundAngleDisabled()
        {
            this.rdoRoundAngle.Enabled = false;
            this.rdoRightAngle.Enabled = false;
            this.txtRoundThick.Enabled = false;
            this.txtRoundWidth.Enabled = false;
            this.rdoTinning.Enabled = false;
            this.rdoNoTinning.Enabled = false;
            this.txtNull.Enabled = false;

            this.txtNull.Text = "";
            this.txtRoundWidth.Text = "";
            this.txtRoundThick.Text = "";
        }
		//设置厚度和长宽（字段3）可用
        private void SetTxtThickAndTxtSizeEnabled()
        {
            this.txtThick.Enabled = true;
            this.txtSize.Enabled = true;
        }

        //设置厚度和长宽（字段3）不可用
        private void SetTxtThickAndTxtSizeDisabled()
        {
            this.txtThick.Text = "";
            this.txtSize.Text = "";
            this.txtThick.Enabled = false;
            this.txtSize.Enabled = false;
        }

		//设置端面和宽度（字段3）可用
        private void SetTxtDMAndTxtLengthEnabled()
        {
            this.txtDM.Enabled = true;
            this.txtLength.Enabled = true;
        }

        //设置端面和宽度（字段3）不可用
        private void SetTxtDMAndTxtLengthDisabled()
        {
            this.txtDM.Text = "";
            this.txtLength.Text = "";
            this.txtDM.Enabled = false;
            this.txtLength.Enabled = false;
        }


		//设置牌号可用
        private void SetTxtRawEnabled()
        {
            this.txtRaw.Enabled = true;
        }

        //设置牌号不可用
        private void SetTxtRawDisabled()
        {
            this.txtRaw.Text = "";
            this.txtRaw.Enabled = false;
        }

		//设置空置字段为不可用
        private void SetTxtNullDisable() 
        {
            this.txtNull.Text = "";
            this.txtNull.Enabled = false;
        }

        //设置空置字段为可用
        private void SetTxtNullEnable()
        {
            this.txtNull.Enabled = true;
        }

		//镀锡可用
        private void SetRdoTinningEnable()
        {
            this.rdoTinning.Enabled = true;
        }

        //镀锡不可用        
        private void SetRdoTinningDisable()
        {
            this.rdoTinning.Enabled = false;
        }

        //不镀锡可用
        private void SetRdoNoTinningEnable()
        {
            this.rdoNoTinning.Enabled = true;
        }

        //不镀锡不可用        
        private void SetRdoNoTinningDisable()
        {
            this.rdoNoTinning.Enabled = false;
        }

        private void cmbRawFirst_Click(object sender, EventArgs e)
        {
            //LoadDataToCmbRawFirst();
        }
    }
}
