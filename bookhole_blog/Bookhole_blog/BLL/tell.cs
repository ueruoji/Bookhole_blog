using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Bookhole_blog.Model;
namespace Bookhole_blog.BLL
{
	/// <summary>
	/// tell
	/// </summary>
	public partial class tell
	{
		private readonly Bookhole_blog.DAL.tell dal=new Bookhole_blog.DAL.tell();
		public tell()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Tell_blogid)
		{
			return dal.Exists(Tell_blogid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Bookhole_blog.Model.tell model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Bookhole_blog.Model.tell model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Tell_blogid)
		{
			
			return dal.Delete(Tell_blogid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Tell_blogidlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Tell_blogidlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Bookhole_blog.Model.tell GetModel(int Tell_blogid)
		{
			
			return dal.GetModel(Tell_blogid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Bookhole_blog.Model.tell GetModelByCache(int Tell_blogid)
		{
			
			string CacheKey = "tellModel-" + Tell_blogid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Tell_blogid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Bookhole_blog.Model.tell)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Bookhole_blog.Model.tell> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Bookhole_blog.Model.tell> DataTableToList(DataTable dt)
		{
			List<Bookhole_blog.Model.tell> modelList = new List<Bookhole_blog.Model.tell>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Bookhole_blog.Model.tell model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

