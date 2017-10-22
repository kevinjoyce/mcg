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
        public static void searchAndSetLevel1(ComboBox cbox, int mainClassID)
        {
            //查询1级类别, mainClassID指明顶级类1-9
            string strWhere = "iMainClassID = " + mainClassID;            
            MaterialCodeGenerator.BLL.MaterialCode table = new MaterialCodeGenerator.BLL.MaterialCode();
            List<MaterialCodeGenerator.Model.MaterialCode> list = listLevelDistinct(table.GetModelList(strWhere), 1);
                        
            cbox.DataSource = list;
            cbox.DisplayMember = "cLevel1Name";
            cbox.ValueMember = "iLevel1ID";
            cbox.Text = "";
        }
        
        public static void searchAndSetLevel2(ComboBox cbox, int mainClassID, int level1ID)
        {
            //查询2级类别, mainClassID指明顶级类1-9
            string strWhere = "iMainClassID = " + mainClassID + " and iLevel1ID = " + level1ID;
            MaterialCodeGenerator.BLL.MaterialCode table = new MaterialCodeGenerator.BLL.MaterialCode();
            List<MaterialCodeGenerator.Model.MaterialCode> list = listLevelDistinct(table.GetModelList(strWhere), 2);

            cbox.DataSource = list;
            cbox.DisplayMember = "cLevel2Name";
            cbox.ValueMember = "iLevel2ID";
            cbox.Text = "";
        }

        public static void searchAndSetLevel3(ComboBox cbox, int mainClassID, int level1ID, int level2ID)
        {
            //查询2级类别, mainClassID指明顶级类1-9
            string strWhere = "iMainClassID = " + mainClassID + " and iLevel1ID = " + level1ID + " and iLevel2ID = " + level2ID;
            MaterialCodeGenerator.BLL.MaterialCode table = new MaterialCodeGenerator.BLL.MaterialCode();
            List<MaterialCodeGenerator.Model.MaterialCode> list = listLevelDistinct(table.GetModelList(strWhere), 3);

            cbox.DataSource = list;
            cbox.DisplayMember = "cLevel3Name";
            cbox.ValueMember = "iLevel3ID";
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
                            doesEqual = list.ElementAt(i).iLevel1ID.ToString() == list.ElementAt(s).iLevel1ID.ToString().ToString();
                            break;
                        case 2:
                            doesEqual = list.ElementAt(i).iLevel2ID.ToString() == list.ElementAt(s).iLevel2ID.ToString().ToString();
                            break;
                        case 3:
                            doesEqual = list.ElementAt(i).iLevel3ID.ToString() == list.ElementAt(s).iLevel3ID.ToString().ToString();
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
