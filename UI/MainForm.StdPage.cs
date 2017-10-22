using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    partial class MainForm
    {
        private void cmbStdFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            setStdComponentDisable();
            if (this.cmbStdFirst.SelectedValue.ToString().Length > 5) return; //处理冲突，启动时会激活该事件报错 
            //设置下级下拉框的级联变化
            LevelSearchor.searchAndSetLevel2(this.cmbStdSecond, 2, int.Parse(this.cmbStdFirst.SelectedValue.ToString()));
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

        private void GenerateStdLevelCode() 
        {
            this.txtStdCode.Text = this.cmbStdSecond.SelectedValue.ToString() + ".";
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
        
    }
}
