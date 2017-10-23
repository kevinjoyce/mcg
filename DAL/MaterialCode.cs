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
			strSql.Append("MainClassID,MainClassName,Level1ID,Level1Name,Level2ID,Level2Name,Level3ID,Level3Name)");
			strSql.Append(" values (");
			strSql.Append("@MainClassID,@MainClassName,@Level1ID,@Level1Name,@Level2ID,@Level2Name,@Level3ID,@Level3Name)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@MainClassID", DbType.String,2147483647),
					new SQLiteParameter("@MainClassName", DbType.String,2147483647),
					new SQLiteParameter("@Level1ID", DbType.String,2147483647),
					new SQLiteParameter("@Level1Name", DbType.String,2147483647),
					new SQLiteParameter("@Level2ID", DbType.String,2147483647),
					new SQLiteParameter("@Level2Name", DbType.String,2147483647),
					new SQLiteParameter("@Level3ID", DbType.String,2147483647),
					new SQLiteParameter("@Level3Name", DbType.String,2147483647)};
			parameters[0].Value = model.MainClassID;
			parameters[1].Value = model.MainClassName;
			parameters[2].Value = model.Level1ID;
			parameters[3].Value = model.Level1Name;
			parameters[4].Value = model.Level2ID;
			parameters[5].Value = model.Level2Name;
			parameters[6].Value = model.Level3ID;
			parameters[7].Value = model.Level3Name;

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
			strSql.Append("MainClassID=@MainClassID,");
			strSql.Append("MainClassName=@MainClassName,");
			strSql.Append("Level1ID=@Level1ID,");
			strSql.Append("Level1Name=@Level1Name,");
			strSql.Append("Level2ID=@Level2ID,");
			strSql.Append("Level2Name=@Level2Name,");
			strSql.Append("Level3ID=@Level3ID,");
			strSql.Append("Level3Name=@Level3Name");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@MainClassID", DbType.String,2147483647),
					new SQLiteParameter("@MainClassName", DbType.String,2147483647),
					new SQLiteParameter("@Level1ID", DbType.String,2147483647),
					new SQLiteParameter("@Level1Name", DbType.String,2147483647),
					new SQLiteParameter("@Level2ID", DbType.String,2147483647),
					new SQLiteParameter("@Level2Name", DbType.String,2147483647),
					new SQLiteParameter("@Level3ID", DbType.String,2147483647),
					new SQLiteParameter("@Level3Name", DbType.String,2147483647)};
			parameters[0].Value = model.MainClassID;
			parameters[1].Value = model.MainClassName;
			parameters[2].Value = model.Level1ID;
			parameters[3].Value = model.Level1Name;
			parameters[4].Value = model.Level2ID;
			parameters[5].Value = model.Level2Name;
			parameters[6].Value = model.Level3ID;
			parameters[7].Value = model.Level3Name;

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
			strSql.Append("select MainClassID,MainClassName,Level1ID,Level1Name,Level2ID,Level2Name,Level3ID,Level3Name from MaterialCode ");
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
				if(row["MainClassID"]!=null)
				{
					model.MainClassID=row["MainClassID"].ToString();
				}
				if(row["MainClassName"]!=null)
				{
					model.MainClassName=row["MainClassName"].ToString();
				}
				if(row["Level1ID"]!=null)
				{
					model.Level1ID=row["Level1ID"].ToString();
				}
				if(row["Level1Name"]!=null)
				{
					model.Level1Name=row["Level1Name"].ToString();
				}
				if(row["Level2ID"]!=null)
				{
					model.Level2ID=row["Level2ID"].ToString();
				}
				if(row["Level2Name"]!=null)
				{
					model.Level2Name=row["Level2Name"].ToString();
				}
				if(row["Level3ID"]!=null)
				{
					model.Level3ID=row["Level3ID"].ToString();
				}
				if(row["Level3Name"]!=null)
				{
					model.Level3Name=row["Level3Name"].ToString();
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
			strSql.Append("select MainClassID,MainClassName,Level1ID,Level1Name,Level2ID,Level2Name,Level3ID,Level3Name ");
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

