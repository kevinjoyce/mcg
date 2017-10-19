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
		private int? _imainclassid;
		private string _cmainclassname;
		private int? _ilevel1id;
		private string _clevel1name;
		private int? _ilevel2id;
		private string _clevel2name;
		private int? _ilevel3id;
		private string _clevel3name;
		/// <summary>
		/// 
		/// </summary>
		public int? iMainClassID
		{
			set{ _imainclassid=value;}
			get{return _imainclassid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cMainClassName
		{
			set{ _cmainclassname=value;}
			get{return _cmainclassname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iLevel1ID
		{
			set{ _ilevel1id=value;}
			get{return _ilevel1id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cLevel1Name
		{
			set{ _clevel1name=value;}
			get{return _clevel1name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iLevel2ID
		{
			set{ _ilevel2id=value;}
			get{return _ilevel2id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cLevel2Name
		{
			set{ _clevel2name=value;}
			get{return _clevel2name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iLevel3ID
		{
			set{ _ilevel3id=value;}
			get{return _ilevel3id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cLevel3Name
		{
			set{ _clevel3name=value;}
			get{return _clevel3name;}
		}
		#endregion Model

	}
}

