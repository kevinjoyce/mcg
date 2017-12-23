using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UI
{
    class LevelSearchor
    {
        public static void searchAndSetLevel1(ComboBox cbox, String mainClassID)
        {
            //查询1级类别, mainClassID指明顶级类1-9
            string strWhere = "MainClassID = '" + mainClassID + "'";            
            MaterialCodeGenerator.BLL.MaterialCode table = new MaterialCodeGenerator.BLL.MaterialCode();
            List<MaterialCodeGenerator.Model.MaterialCode> list = listLevelDistinct(table.GetModelList(strWhere), 1);
                        
            cbox.DataSource = list;
            cbox.DisplayMember = "Level1Name";
            cbox.ValueMember = "Level1ID";
            cbox.Text = "";

        }
        
        public static void searchAndSetLevel2(ComboBox cbox, String mainClassID, String level1ID)
        {
            //查询2级类别, mainClassID指明顶级类1-9
            string strWhere = "MainClassID = '" + mainClassID + "' and Level1ID = '" + level1ID+"'";
            MaterialCodeGenerator.BLL.MaterialCode table = new MaterialCodeGenerator.BLL.MaterialCode();
            List<MaterialCodeGenerator.Model.MaterialCode> list = listLevelDistinct(table.GetModelList(strWhere), 2);

            cbox.DataSource = list;
            cbox.DisplayMember = "Level2Name";
            cbox.ValueMember = "Level2ID";
            cbox.Text = "";

        }

        public static void searchAndSetLevel3(ComboBox cbox, String mainClassID, String level1ID, String level2ID)
        {
            //查询2级类别, mainClassID指明顶级类1-9
            string strWhere = "MainClassID = '" + mainClassID + "' and Level1ID = '" + level1ID + "' and Level2ID = '" + level2ID + "'";
            MaterialCodeGenerator.BLL.MaterialCode table = new MaterialCodeGenerator.BLL.MaterialCode();
            
            List<MaterialCodeGenerator.Model.MaterialCode> list = listLevelDistinct(table.GetModelList(strWhere), 3);

            cbox.DataSource = list;
            cbox.DisplayMember = "Level3Name";
            cbox.ValueMember = "Level3ID";
            cbox.Text = "";

            setCmbState(cbox);
        }
        //没数据就disable，否则enable
        public static void setCmbState(ComboBox cbox) 
        {
            if (cbox.Items.Count == 1)
            {
                cbox.SelectedIndex = 0;
                if(cbox.SelectedValue.ToString().Length ==0)
                    cbox.Enabled = false;
                else
                    cbox.Enabled = true;
            }
            else
            {
                cbox.Enabled = true;
            }
        }

        //查询一级大类
        public static string GetFields1(string code) {
            
            switch (code) {
                case "1":
                    return "原材料";
                case "2":
                    return "钣金标准件";
                case "3":
                    return "电器元件";
                case "4":
                    return "线缆";
                case "5":
                    return "五金";
                case "6":
                    return "辅料";
                case "7":
                    return "合同件";
                case "8":
                    return "成品母线";
                case "9":
                    return "成品机柜";
                default:
                    return "";
            }
        }
        //查询一级大类下的级别
        public static string GetFields2(string mainClassID, string subClassID)
        {

            string strWhere = "MainClassID = '" + mainClassID + "' and (Level1ID = '" + subClassID + "' or Level2ID = '" + subClassID + "' or Level3ID = '"+subClassID+"')";
            MaterialCodeGenerator.BLL.MaterialCode table = new MaterialCodeGenerator.BLL.MaterialCode();
            List<MaterialCodeGenerator.Model.MaterialCode> list = table.GetModelList(strWhere);
            if (list.Count > 0)
                return "  " + list[0].Level1Name + "  " + list[0].Level2Name + "  " + list[0].Level3Name;
            else
                return "";
        }

        //去重
        public static List<MaterialCodeGenerator.Model.MaterialCode> listLevelDistinct(List<MaterialCodeGenerator.Model.MaterialCode> list, int level)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                for (int s = i - 1; s >= 0; s--)
                {
                    bool doesEqual = false;
                    switch(level)
                    {
                        case 1:
                            doesEqual = list.ElementAt(i).Level1ID.ToString() == list.ElementAt(s).Level1ID.ToString().ToString();
                            break;
                        case 2:
                            doesEqual = list.ElementAt(i).Level2ID.ToString() == list.ElementAt(s).Level2ID.ToString().ToString();
                            break;
                        case 3:
                            doesEqual = list.ElementAt(i).Level3ID.ToString() == list.ElementAt(s).Level3ID.ToString().ToString();
                            break;
                    }
                    if (doesEqual)
                    {
                        list.RemoveAt(i);
                        break;
                    }
                }
            }
            return list;
        }
    }
}
