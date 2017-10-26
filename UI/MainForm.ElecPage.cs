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
        
        private void cmbElecFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setElecComponentDisalbe();
            if (this.cmbElecFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbElecSecond, "3", this.cmbElecFirst.SelectedValue.ToString());

            //根据选择，决定激活哪些控件
            SetEnableAdjustToInput();
            
            //实时生成编码
            GenerateAllCode();
        }
        
        private void cmbElecSecond_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cmbElecSecond.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错                         

            //级联变化
            LevelSearchor.searchAndSetLevel3(this.cmbElecThird,
                "3",
                this.cmbElecFirst.SelectedValue.ToString(),
                this.cmbElecSecond.SelectedValue.ToString());

            //实时生成编码
            GenerateAllCode();
        }

        private void cmbElecThird_SelectedIndexChanged(object sender, EventArgs e)
        {
            //实时生成编码
            GenerateAllCode();
        }

        private void SetEnableAdjustToInput()
        {            
            //变送器，激活流水号
            if (this.cmbElecFirst.SelectedValue.ToString() == "B")
            {
                this.SetElecSeriNumEnable();
            }

            //电容器
            if (this.cmbElecFirst.SelectedValue.ToString() == "CO")
            {
                this.SetUCapEnable();
            }

            //浪涌保护器，熔断器，控制器，接触器，热继电器，断路器... 电压电流
            if (this.cmbElecFirst.SelectedValue.ToString() == "F" ||
                this.cmbElecFirst.SelectedValue.ToString() == "FU" ||
                this.cmbElecFirst.SelectedValue.ToString() == "K0" ||
                this.cmbElecFirst.SelectedValue.ToString() == "KM" ||
                this.cmbElecFirst.SelectedValue.ToString() == "KH" ||
                this.cmbElecFirst.SelectedValue.ToString() == "Q" ||
                this.cmbElecFirst.SelectedValue.ToString() == "QM" ||
                this.cmbElecFirst.SelectedValue.ToString() == "QS" ||
                this.cmbElecFirst.SelectedValue.ToString() == "QE" ||
                this.cmbElecFirst.SelectedValue.ToString() == "UI" ||
                this.cmbElecFirst.SelectedValue.ToString() == "XP" ||
                this.cmbElecFirst.SelectedValue.ToString() == "XS")
            {
                this.SetUIEnable();
                if (this.cmbElecFirst.SelectedValue.ToString() == "KM")//接触器
                    this.SetSupportNumEnable();
            }

            //蓄电池:电压、容量
            if (this.cmbElecFirst.SelectedValue.ToString() == "GB")
            {
                this.SetUElecCapEnable();
            }

            //母线框：铜排尺寸等
            if (this.cmbElecFirst.SelectedValue.ToString() == "M")
            {
                this.SetSizeDistColSerialEnable();
            }

            //中间继电器：电压转化组数等
            if (this.cmbElecFirst.SelectedValue.ToString() == "KA")
            {
                this.SetUGroupNumEnable();
            }

            //时间继电器：通电断电等
            if (this.cmbElecFirst.SelectedValue.ToString() == "KT")
            {
                this.SetUOnOffDelayNullEnable();
            }

            //仪表等：空置
            if (this.cmbElecFirst.SelectedValue.ToString() == "P" ||
                this.cmbElecFirst.SelectedValue.ToString() == "SA" ||
                this.cmbElecFirst.SelectedValue.ToString() == "T" ||
                this.cmbElecFirst.SelectedValue.ToString() == "LT" ||
                this.cmbElecFirst.SelectedValue.ToString() == "HEO" ||
                this.cmbElecFirst.SelectedValue.ToString() == "IS0" ||
                this.cmbElecFirst.SelectedValue.ToString() == "020" ||
                this.cmbElecFirst.SelectedValue.ToString() == "010" ||
                this.cmbElecFirst.SelectedValue.ToString() == "LX" ||
                this.cmbElecFirst.SelectedValue.ToString() == "LO" ||
                this.cmbElecFirst.SelectedValue.ToString() == "YL" ||
                this.cmbElecFirst.SelectedValue.ToString() == "YO" ||
                this.cmbElecFirst.SelectedValue.ToString() == "XT")
            {
                this.SetNullEnable();
            }

            //电位器：空置、阻值等
            if (this.cmbElecFirst.SelectedValue.ToString() == "RP")
            {
                this.SetNullBlockEnable();
            }

            //开关：触点，颜色等
            if (this.cmbElecFirst.SelectedValue.ToString() == "S")
            {
                this.SetTouchColorEnable();
            }
            //变频器：电压功率等
            if (this.cmbElecFirst.SelectedValue.ToString() == "VF")
            {
                this.SetUPowerEnable();
            }

            //指示信号：交直流等
            if (this.cmbElecFirst.SelectedValue.ToString() == "H")
            {
                this.SetACDCEnable();
            }
        }

        

        //锁定所有控件无法录入
        private void setElecComponentDisalbe()
        {
            SetElecSeriNumDisable();
            SetUCapDisable();
            SetUIDisable();
            SetUElecCapDisable();
            SetSizeDistColSerialDisable();
            SetUGroupNumDisable();
            SetUOnOffDelayNullDisable();
            SetNullDisable();
            SetNullBlockDisable();
            SetTouchColorDisable();
            SetUPowerDisable();
            SetSupportNumDisable();
            SetACDCDisable();
        }

                
        //激活所有空间可用录入
        private void setElecComponentEnable()
        {
            SetUCapEnable();
            SetUIEnable();
            SetUElecCapEnable();
            SetSizeDistColSerialEnable();
            SetUGroupNumEnable();
            SetUOnOffDelayNullEnable();
            SetNullEnable();
            SetNullBlockEnable();
            SetTouchColorEnable();
            SetUPowerEnable();
            SetSupportNumEnable();
            SetACDCEnable();

        }
        

        /*--------Disable----------*/
        //交直流
        private void SetACDCDisable()
        {
            this.txtElecU.Enabled = false;
            this.cmbACDC.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //流水号
        private void SetElecSeriNumDisable()
        {
            this.txtElecSerialNum.Enabled = false;
        }

        //辅助点数量
        private void SetSupportNumDisable()
        {
            this.txtElecSupportPointNum.Enabled = false;
        }

        //电压，功率
        private void SetUPowerDisable()
        {
            this.txtElecU.Enabled = false;
            this.txtElecPower.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //触点数量，颜色
        private void SetTouchColorDisable()
        {
            this.txtElecTouchPointNum.Enabled = false;
            this.txtElecColor.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //空置，阻值
        private void SetNullBlockDisable()
        {
            this.txtElecNull.Enabled = false;
            this.txtElecBlock.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //空置
        private void SetNullDisable()
        {
            this.txtElecNull.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //电压，电流，延时，空置
        private void SetUOnOffDelayNullDisable()
        {
            this.txtElecU.Enabled = false;
            this.rdoElecOn.Enabled = false;
            this.rdoElecOff.Enabled = false;
            this.txtElecDelay.Enabled = false;
            this.txtElecNull.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //电压，转化组数
        private void SetUGroupNumDisable()
        {
            this.txtElecU.Enabled = false;
            this.txtElecGroupNum.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //铜排数，相间距，排数，流水号
        private void SetSizeDistColSerialDisable()
        {
            this.txtElecSize.Enabled = false;
            this.txtElecDist.Enabled = false;
            this.txtColNum.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //电压，容量
        private void SetUElecCapDisable()
        {
            this.txtElecU.Enabled = false;
            this.txtElecCapacity.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //电压，电流（通电电流）
        private void SetUIDisable()
        {
            this.txtElecU.Enabled = false;
            this.txtElecI.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        //电压，电容
        private void SetUCapDisable()
        {
            this.txtCap.Enabled = false;
            this.txtElecU.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
        }

        /*-----------Enable------------*/

        //交直流
        private void SetACDCEnable()
        {
            this.txtElecU.Enabled = true;
            this.cmbACDC.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //流水号
        private void SetElecSeriNumEnable()
        {
            this.txtElecSerialNum.Enabled = true;
        }

        //辅助点数量
        private void SetSupportNumEnable()
        {
            this.txtElecSupportPointNum.Enabled = true;
        }

        //电压，功率
        private void SetUPowerEnable()
        {
            this.txtElecU.Enabled = true;
            this.txtElecPower.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //触点数量，颜色
        private void SetTouchColorEnable()
        {
            this.txtElecTouchPointNum.Enabled = true;
            this.txtElecColor.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //空置，阻值
        private void SetNullBlockEnable()
        {
            this.txtElecNull.Enabled = true;
            this.txtElecBlock.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //空置
        private void SetNullEnable()
        {
            this.txtElecNull.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //电压，电流，延时，空置
        private void SetUOnOffDelayNullEnable()
        {
            this.txtElecU.Enabled = true;
            this.rdoElecOn.Enabled = true;
            this.rdoElecOff.Enabled = true;
            this.txtElecDelay.Enabled = true;
            this.txtElecNull.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //电压，转化组数
        private void SetUGroupNumEnable()
        {
            this.txtElecU.Enabled = true;
            this.txtElecGroupNum.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //铜排数，相间距，排数，流水号
        private void SetSizeDistColSerialEnable()
        {
            this.txtElecSize.Enabled = true;
            this.txtElecDist.Enabled = true;
            this.txtColNum.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //电压，容量
        private void SetUElecCapEnable()
        {
            this.txtElecU.Enabled = true;
            this.txtElecCapacity.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //电压，电流（通电电流）
        private void SetUIEnable()
        {
            this.txtElecU.Enabled = true;
            this.txtElecI.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        //电压，电容
        private void SetUCapEnable()
        {
            this.txtCap.Enabled = true;
            this.txtElecU.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
        }

        /*--------------Code------------*/

        private void GenerateElecLevelCode() 
        {
            this.txtElecCode.Text = "3.";
            if(cmbElecThird.Text !="")
                this.txtElecCode.Text = this.txtElecCode.Text + this.cmbElecThird.SelectedValue.ToString();
            else if(cmbElecSecond.Text != "")
                this.txtElecCode.Text = this.txtElecCode.Text + this.cmbElecSecond.SelectedValue.ToString();
            else
                this.txtElecCode.Text = this.txtElecCode.Text + this.cmbElecFirst.SelectedValue.ToString();
        }

        /*生成编码: 电压，电容*/
        private void GenerateUCapCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text 
                + "."
                + this.txtElecU.Text 
                + this.txtCap.Text 
                +"."
                + this.txtElecSerialNum.Text;
        }

        //电压，电流（通电电流）
        private void GenerateUICode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text 
                + "." 
                + this.txtElecU.Text 
                + this.txtElecI.Text 
                + "." 
                + this.txtElecSerialNum.Text;
        }

        //电压，容量
        private void GenerateUElecCapCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text 
                +"."
                + this.txtElecU.Text 
                + this.txtElecCapacity.Text 
                + "." 
                + this.txtElecSerialNum.Text;
            
        }

        //铜排数，相间距，排数，流水号
        private void GenerateSizeDistColSerialCode()
        {

            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecSize.Text
                +"."
                + this.txtElecDist.Text
                + this.txtColNum.Text
                + this.txtElecSerialNum.Text;

            /*this.txtElecSize.Enabled = true;
            this.txtElecDist.Enabled = true;
            this.txtColNum.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
             * */
        }

        //电压，转化组数
        private void GenerateUGroupNumCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecU.Text
                + this.txtElecGroupNum.Text
                + "."
                + this.txtElecSerialNum.Text;

            /*
            this.txtElecU.Enabled = true;
            this.txtElecGroupNum.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
             * */
        }

        //电压，电流，延时，空置
        private void GenerateUOnOffDelayNullCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecU.Text
                + Utility.getRadioButtonCode(this.rdoElecOn, "1")
                + Utility.getRadioButtonCode(this.rdoElecOff, "0")
                + this.txtElecDelay.Text
                + this.txtElecNull.Text
                + "."
                + this.txtElecSerialNum.Text;

            /*
            this.txtElecU.Enabled = true;
            this.rdoElecOn.Enabled = true;
            this.rdoElecOff.Enabled = true;
            this.txtElecDelay.Enabled = true;
            this.txtElecNull.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
             * */
        }

        //空置
        private void GenerateNullCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecNull.Text
                + "."
                + this.txtElecSerialNum.Text;
            /*
            this.txtElecNull.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
             * */
        }

        //空置，阻值
        private void GenerateNullBlockCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecNull.Text
                + this.txtElecBlock.Text
                + "."
                + this.txtElecSerialNum.Text;
            /*
            this.txtElecNull.Enabled = true;
            this.txtElecBlock.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
             * */
        }

        //触点数量，颜色
        private void GenerateTouchColorCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecTouchPointNum.Text
                + this.txtElecColor.Text
                + "."
                + this.txtElecSerialNum.Text;
            /*
            this.txtElecTouchPointNum.Enabled = true;
            this.txtElecColor.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
             * */
        }

        //电压，功率
        private void GenerateUPowerCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecU.Text
                + this.txtElecPower.Text
                + "."
                + this.txtElecSerialNum.Text;
            /*
            this.txtElecU.Enabled = true;
            this.txtElecPower.Enabled = true;
            this.txtElecSerialNum.Enabled = true;
             * */
        }

        //电压、电流，辅助点数量+流水号
        private void GetUISupportNumCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecU.Text
                + this.txtElecI.Text
                + "."
                + this.txtElecSupportPointNum.Text
                + this.txtElecSerialNum.Text;

            /*
            this.txtElecSupportPointNum.Enabled = true;
             * */
        }

        //交直流
        private void GenerateACDCCode()
        {
            GenerateElecLevelCode();
            this.txtElecCode.Text = this.txtElecCode.Text
                + "."
                + this.txtElecU.Text
                + this.cmbACDC.Text
                + "."
                + this.txtElecSerialNum.Text;
            /*
            this.txtElecU.Enabled = false;
            this.cmbACDC.Enabled = false;
            this.txtElecSerialNum.Enabled = false;
             * */
        }

        /*-----------Generating Code TextChanged--------------*/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //电压、电容
            if(this.txtElecU.Enabled && this.txtCap.Enabled)
                GenerateUCapCode();

            //电压、功率
            if (this.txtElecU.Enabled && this.txtElecPower.Enabled)
                GenerateUPowerCode();
        }

        private void txtElecU_TextChanged(object sender, EventArgs e)
        {
            //电压、电容
            if (this.txtElecU.Enabled && this.txtCap.Enabled)
                GenerateUCapCode();

            //电压、容量
            if (this.txtElecU.Enabled && this.txtElecCapacity.Enabled)
                GenerateUElecCapCode();

            //电压、电流
            if (this.txtElecU.Enabled && this.txtElecI.Enabled)
                GenerateUICode();

            //电压、转化组数
            if (this.txtElecU.Enabled && this.txtElecGroupNum.Enabled)
                GenerateUGroupNumCode();

            //电压，电流，延时，空置
            if (this.txtElecU.Enabled
                && this.rdoElecOn.Enabled
                && this.rdoElecOff.Enabled
                && this.txtElecDelay.Enabled
                && this.txtElecNull.Enabled)
                GenerateUOnOffDelayNullCode();

            //电压、功率
            if (this.txtElecU.Enabled && this.txtElecPower.Enabled)
                GenerateUPowerCode();
            
            //电压、电流，辅助点数量
            if (this.txtElecU.Enabled 
                && this.txtElecI.Enabled
                && this.txtElecSupportPointNum.Enabled)
                GetUISupportNumCode();

            //交直流
            if (this.txtElecU.Enabled && this.cmbACDC.Enabled)
                GenerateACDCCode();

        }

        private void txtElecI_TextChanged(object sender, EventArgs e)
        {
            //电压、电流
            if (this.txtElecU.Enabled && this.txtElecI.Enabled)
                GenerateUICode();

            //电压、电流，辅助点数量
            if (this.txtElecU.Enabled
                && this.txtElecI.Enabled
                && this.txtElecSupportPointNum.Enabled)
                GetUISupportNumCode();
        }

        private void txtElecCapacity_TextChanged(object sender, EventArgs e)
        {
            GenerateUElecCapCode();
        }

        //相间距
        private void txtElecDist_TextChanged(object sender, EventArgs e)
        {
            GenerateSizeDistColSerialCode();
        }

        //排数
        private void txtColNum_TextChanged(object sender, EventArgs e)
        {
            GenerateSizeDistColSerialCode();
        }
        //尺寸
        private void txtElecSize_TextChanged(object sender, EventArgs e)
        {
            GenerateSizeDistColSerialCode();
        }

        private void txtElecGroupNum_TextChanged(object sender, EventArgs e)
        {
            //电压、转化组数
            if (this.txtElecU.Enabled && this.txtElecGroupNum.Enabled)
                GenerateUGroupNumCode();
        }

        private void rdoElecOn_CheckedChanged(object sender, EventArgs e)
        {
            //电压，电流，延时，空置
            if (this.txtElecU.Enabled
                && this.rdoElecOn.Enabled
                && this.rdoElecOff.Enabled
                && this.txtElecDelay.Enabled
                && this.txtElecNull.Enabled)
                GenerateUOnOffDelayNullCode();
        }

        private void rdoElecOff_CheckedChanged(object sender, EventArgs e)
        {
            //电压，电流，延时，空置
            if (this.txtElecU.Enabled
                && this.rdoElecOn.Enabled
                && this.rdoElecOff.Enabled
                && this.txtElecDelay.Enabled
                && this.txtElecNull.Enabled)
                GenerateUOnOffDelayNullCode();
        }

        private void txtElecDelay_TextChanged(object sender, EventArgs e)
        {
            //电压，电流，延时，空置
            if (this.txtElecU.Enabled
                && this.rdoElecOn.Enabled
                && this.rdoElecOff.Enabled
                && this.txtElecDelay.Enabled
                && this.txtElecNull.Enabled)
                GenerateUOnOffDelayNullCode();
        }

        private void txtElecNull_TextChanged(object sender, EventArgs e)
        {
            //电压，电流，延时，空置
            if (this.txtElecU.Enabled
                && this.rdoElecOn.Enabled
                && this.rdoElecOff.Enabled
                && this.txtElecDelay.Enabled
                && this.txtElecNull.Enabled)
                GenerateUOnOffDelayNullCode();

            //空置
            if (this.txtElecNull.Enabled)
                GenerateNullCode();

            //空置，阻值
            if (this.txtElecNull.Enabled && this.txtElecBlock.Enabled)
                GenerateNullBlockCode();
        }

        private void txtElecBlock_TextChanged(object sender, EventArgs e)
        {
            //空置，阻值
            if (this.txtElecNull.Enabled && this.txtElecBlock.Enabled)
                GenerateNullBlockCode();
        }

        private void txtElecTouchPointNum_TextChanged(object sender, EventArgs e)
        {
            //触点，颜色
            if (this.txtElecTouchPointNum.Enabled && this.txtElecColor.Enabled)
                GenerateTouchColorCode();
        }

        private void txtElecColor_TextChanged(object sender, EventArgs e)
        {
            //触点，颜色
            if (this.txtElecTouchPointNum.Enabled && this.txtElecColor.Enabled)
                GenerateTouchColorCode();
        }



        private void txtElecSupportPointNum_TextChanged(object sender, EventArgs e)
        {
            //电压、电流，辅助点数量
            if (this.txtElecU.Enabled
                && this.txtElecI.Enabled
                && this.txtElecSupportPointNum.Enabled)
                GetUISupportNumCode();
        }

        private void cmbACDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //交直流
            if (this.txtElecU.Enabled && this.cmbACDC.Enabled)
                GenerateACDCCode();
        }

        

        private void txtElecSerialNum_TextChanged(object sender, EventArgs e)
        {
            GenerateAllCode();
        }

        /*
         * 根据界面元素是否处于Enable状态，决定产生何种样式的代码
         * */

        private void GenerateAllCode()
        {
            //电压、电容
            if (this.txtElecU.Enabled && this.txtCap.Enabled)
                GenerateUCapCode();

            //电压、容量
            if (this.txtElecU.Enabled && this.txtElecCapacity.Enabled)
                GenerateUElecCapCode();

            //电压、电流
            if (this.txtElecU.Enabled && this.txtElecI.Enabled)
                GenerateUICode();

            //铜排数，相间距，排数，流水号
            if (this.txtElecSize.Enabled
                && this.txtElecDist.Enabled
                && this.txtElecDist.Enabled)
                GenerateSizeDistColSerialCode();

            //电压、转化组数
            if (this.txtElecU.Enabled && this.txtElecGroupNum.Enabled)
                GenerateUGroupNumCode();

            //电压，电流，延时，空置
            if (this.txtElecU.Enabled
                && this.rdoElecOn.Enabled
                && this.rdoElecOff.Enabled
                && this.txtElecDelay.Enabled
                && this.txtElecNull.Enabled)
                GenerateUOnOffDelayNullCode();

            //空置
            if (this.txtElecNull.Enabled)
                GenerateNullCode();

            //空置, 阻值
            if (this.txtElecNull.Enabled && this.txtElecBlock.Enabled)
                GenerateNullBlockCode();

            //触点，颜色
            if (this.txtElecTouchPointNum.Enabled && this.txtElecColor.Enabled)
                GenerateTouchColorCode();

            //电压、功率
            if (this.txtElecU.Enabled && this.txtElecPower.Enabled)
                GenerateUPowerCode();

            //电压、电流，辅助点数量
            if (this.txtElecU.Enabled
                && this.txtElecI.Enabled
                && this.txtElecSupportPointNum.Enabled)
                GetUISupportNumCode();

            //交直流
            if (this.txtElecU.Enabled && this.cmbACDC.Enabled)
                GenerateACDCCode();
        }

        //产生流水号
        private void txtElecSerialNum_Click(object sender, EventArgs e)
        {
            ElecFlowNoGenerator elecFlowNoGenerator = new ElecFlowNoGenerator();
            this.txtElecSerialNum.Text = Utility.getFlowNoCode(elecFlowNoGenerator);
        }

        private void btnElecCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtElecCode.Text);
            MessageBox.Show("编码复制成功");
        }
    }
}
