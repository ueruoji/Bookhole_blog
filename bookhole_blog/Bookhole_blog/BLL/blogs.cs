﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Bookhole_blog.Model;
namespace Bookhole_blog.BLL
{
    /// <summary>
    /// blogs
    /// </summary>
    public partial class blogs
    {
        private readonly Bookhole_blog.DAL.blogs dal = new Bookhole_blog.DAL.blogs();
        public blogs()
        { }
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
        public bool Exists(int Blog_id)
        {
            return dal.Exists(Blog_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Bookhole_blog.Model.blogs model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Bookhole_blog.Model.blogs model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Blog_id)
        {

            return dal.Delete(Blog_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Blog_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Blog_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Bookhole_blog.Model.blogs GetModel(int Blog_id)
        {

            return dal.GetModel(Blog_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Bookhole_blog.Model.blogs GetModelByCache(int Blog_id)
        {

            string CacheKey = "blogsModel-" + Blog_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Blog_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Bookhole_blog.Model.blogs)objModel;
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
        public List<Bookhole_blog.Model.blogs> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Bookhole_blog.Model.blogs> DataTableToList(DataTable dt)
        {
            List<Bookhole_blog.Model.blogs> modelList = new List<Bookhole_blog.Model.blogs>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Bookhole_blog.Model.blogs model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

