using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace MaterialCodeGenerator.DAL
{
	/// <summary>
	/// 数据访问类:MaterialCode
	/// </summary>
	public partial class MaterialCode
	{
		public MaterialCode()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MaterialCodeGenerator.Model.MaterialCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MaterialCode(");
			strSql.Append("iMainClassID,cMainClassName,iLevel1ID,cLevel1Name,iLevel2ID,cLevel2Name,iLevel3ID,cLevel3Name)");
			strSql.Append(" values (");
			strSql.Append("@iMainClassID,@cMainClassName,@iLevel1ID,@cLevel1Name,@iLevel2ID,@cLevel2Name,@iLevel3ID,@cLevel3Name)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@iMainClassID", DbType.Int32,8),
					new SQLiteParameter("@cMainClassName", DbType.String,2147483647),
					new SQLiteParameter("@iLevel1ID", DbType.Int32,8),
					new SQLiteParameter("@cLevel1Name", DbType.String,2147483647),
					new SQLiteParameter("@iLevel2ID", DbType.Int32,8),
					new SQLiteParameter("@cLevel2Name", DbType.String,2147483647),
					new SQLiteParameter("@iLevel3ID", DbType.Int32,8),
					new SQLiteParameter("@cLevel3Name", DbType.String,2147483647)};
			parameters[0].Value = model.iMainClassID;
			parameters[1].Value = model.cMainClassName;
			parameters[2].Value = model.iLevel1ID;
			parameters[3].Value = model.cLevel1Name;
			parameters[4].Value = model.iLevel2ID;
			parameters[5].Value = model.cLevel2Name;
			parameters[6].Value = model.iLevel3ID;
			parameters[7].Value = model.cLevel3Name;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MaterialCodeGenerator.Model.MaterialCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MaterialCode set ");
			strSql.Append("iMainClassID=@iMainClassID,");
			strSql.Append("cMainClassName=@cMainClassName,");
			strSql.Append("iLevel1ID=@iLevel1ID,");
			strSql.Append("cLevel1Name=@cLevel1Name,");
			strSql.Append("iLevel2ID=@iLevel2ID,");
			strSql.Append("cLevel2Name=@cLevel2Name,");
			strSql.Append("iLevel3ID=@iLevel3ID,");
			strSql.Append("cLevel3Name=@cLevel3Name");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@iMainClassID", DbType.Int32,8),
					new SQLiteParameter("@cMainClassName", DbType.String,2147483647),
					new SQLiteParameter("@iLevel1ID", DbType.Int32,8),
					new SQLiteParameter("@cLevel1Name", DbType.String,2147483647),
					new SQLiteParameter("@iLevel2ID", DbType.Int32,8),
					new SQLiteParameter("@cLevel2Name", DbType.String,2147483647),
					new SQLiteParameter("@iLevel3ID", DbType.Int32,8),
					new SQLiteParameter("@cLevel3Name", DbType.String,2147483647)};
			parameters[0].Value = model.iMainClassID;
			parameters[1].Value = model.cMainClassName;
			parameters[2].Value = model.iLevel1ID;
			parameters[3].Value = model.cLevel1Name;
			parameters[4].Value = model.iLevel2ID;
			parameters[5].Value = model.cLevel2Name;
			parameters[6].Value = model.iLevel3ID;
			parameters[7].Value = model.cLevel3Name;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MaterialCode ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MaterialCodeGenerator.Model.MaterialCode GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iMainClassID,cMainClassName,iLevel1ID,cLevel1Name,iLevel2ID,cLevel2Name,iLevel3ID,cLevel3Name from MaterialCode ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

			MaterialCodeGenerator.Model.MaterialCode model=new MaterialCodeGenerator.Model.MaterialCode();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MaterialCodeGenerator.Model.MaterialCode DataRowToModel(DataRow row)
		{
			MaterialCodeGenerator.Model.MaterialCode model=new MaterialCodeGenerator.Model.MaterialCode();
			if (row != null)
			{
				if(row["iMainClassID"]!=null && row["iMainClassID"].ToString()!="")
				{
					model.iMainClassID=int.Parse(row["iMainClassID"].ToString());
				}
				if(row["cMainClassName"]!=null)
				{
					model.cMainClassName=row["cMainClassName"].ToString();
				}
				if(row["iLevel1ID"]!=null && row["iLevel1ID"].ToString()!="")
				{
					model.iLevel1ID=int.Parse(row["iLevel1ID"].ToString());
				}
				if(row["cLevel1Name"]!=null)
				{
					model.cLevel1Name=row["cLevel1Name"].ToString();
				}
				if(row["iLevel2ID"]!=null && row["iLevel2ID"].ToString()!="")
				{
					model.iLevel2ID=int.Parse(row["iLevel2ID"].ToString());
				}
				if(row["cLevel2Name"]!=null)
				{
					model.cLevel2Name=row["cLevel2Name"].ToString();
				}
				if(row["iLevel3ID"]!=null && row["iLevel3ID"].ToString()!="")
				{
					model.iLevel3ID=int.Parse(row["iLevel3ID"].ToString());
				}
				if(row["cLevel3Name"]!=null)
				{
					model.cLevel3Name=row["cLevel3Name"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iMainClassID,cMainClassName,iLevel1ID,cLevel1Name,iLevel2ID,cLevel2Name,iLevel3ID,cLevel3Name ");
			strSql.Append(" FROM MaterialCode ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

        


		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM MaterialCode ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from MaterialCode T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "MaterialCode";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

