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
