using System;
namespace MaterialCodeGenerator.Model
{
	/// <summary>
	/// MaterialCode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MaterialCode
	{
		public MaterialCode()
		{}
		#region Model
		private string _mainclassid= "null";
		private string _mainclassname= "null";
		private string _level1id= "null";
		private string _level1name= "null";
		private string _level2id= "null";
		private string _level2name= "null";
		private string _level3id= "null";
		private string _level3name= "null";
		/// <summary>
		/// 
		/// </summary>
		public string MainClassID
		{
			set{ _mainclassid=value;}
			get{return _mainclassid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainClassName
		{
			set{ _mainclassname=value;}
			get{return _mainclassname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Level1ID
		{
			set{ _level1id=value;}
			get{return _level1id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Level1Name
		{
			set{ _level1name=value;}
			get{return _level1name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Level2ID
		{
			set{ _level2id=value;}
			get{return _level2id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Level2Name
		{
			set{ _level2name=value;}
			get{return _level2name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Level3ID
		{
			set{ _level3id=value;}
			get{return _level3id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Level3Name
		{
			set{ _level3name=value;}
			get{return _level3name;}
		}
		#endregion Model

	}
}

