using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Bookhole_blog.DAL
{
    /// <summary>
    /// 数据访问类:blogs
    /// </summary>
    public partial class blogs
    {
        public blogs()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("Blog_id", "blogs");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Blog_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from blogs");
            strSql.Append(" where Blog_id=@Blog_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Blog_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = Blog_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Bookhole_blog.Model.blogs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into blogs(");
            strSql.Append("Blog_id,Blog_title,Blog_text,Blog_read,Blog_img,Blog_is,Blog_time,Blog_delete,Blog_typeid,Blog_abstract)");
            strSql.Append(" values (");
            strSql.Append("@Blog_id,@Blog_title,@Blog_text,@Blog_read,@Blog_img,@Blog_is,@Blog_time,@Blog_delete,@Blog_typeid,@Blog_abstract)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Blog_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_title", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Blog_text", MySqlDbType.Text),
                    new MySqlParameter("@Blog_read", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_img", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Blog_is", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_time", MySqlDbType.VarChar,10),
                    new MySqlParameter("@Blog_delete", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_typeid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_abstract", MySqlDbType.Text)};
            parameters[0].Value = model.Blog_id;
            parameters[1].Value = model.Blog_title;
            parameters[2].Value = model.Blog_text;
            parameters[3].Value = model.Blog_read;
            parameters[4].Value = model.Blog_img;
            parameters[5].Value = model.Blog_is;
            parameters[6].Value = model.Blog_time;
            parameters[7].Value = model.Blog_delete;
            parameters[8].Value = model.Blog_typeid;
            parameters[9].Value = model.Blog_abstract;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Bookhole_blog.Model.blogs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update blogs set ");
            strSql.Append("Blog_title=@Blog_title,");
            strSql.Append("Blog_text=@Blog_text,");
            strSql.Append("Blog_read=@Blog_read,");
            strSql.Append("Blog_img=@Blog_img,");
            strSql.Append("Blog_is=@Blog_is,");
            strSql.Append("Blog_time=@Blog_time,");
            strSql.Append("Blog_delete=@Blog_delete,");
            strSql.Append("Blog_typeid=@Blog_typeid,");
            strSql.Append("Blog_abstract=@Blog_abstract");
            strSql.Append(" where Blog_id=@Blog_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Blog_title", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Blog_text", MySqlDbType.Text),
                    new MySqlParameter("@Blog_read", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_img", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Blog_is", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_time", MySqlDbType.VarChar,10),
                    new MySqlParameter("@Blog_delete", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_typeid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Blog_abstract", MySqlDbType.Text),
                    new MySqlParameter("@Blog_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Blog_title;
            parameters[1].Value = model.Blog_text;
            parameters[2].Value = model.Blog_read;
            parameters[3].Value = model.Blog_img;
            parameters[4].Value = model.Blog_is;
            parameters[5].Value = model.Blog_time;
            parameters[6].Value = model.Blog_delete;
            parameters[7].Value = model.Blog_typeid;
            parameters[8].Value = model.Blog_abstract;
            parameters[9].Value = model.Blog_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int Blog_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from blogs ");
            strSql.Append(" where Blog_id=@Blog_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Blog_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = Blog_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Blog_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from blogs ");
            strSql.Append(" where Blog_id in (" + Blog_idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public Bookhole_blog.Model.blogs GetModel(int Blog_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Blog_id,Blog_title,Blog_text,Blog_read,Blog_img,Blog_is,Blog_time,Blog_delete,Blog_typeid,Blog_abstract from blogs ");
            strSql.Append(" where Blog_id=@Blog_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Blog_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = Blog_id;

            Bookhole_blog.Model.blogs model = new Bookhole_blog.Model.blogs();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Bookhole_blog.Model.blogs DataRowToModel(DataRow row)
        {
            Bookhole_blog.Model.blogs model = new Bookhole_blog.Model.blogs();
            if (row != null)
            {
                if (row["Blog_id"] != null && row["Blog_id"].ToString() != "")
                {
                    model.Blog_id = int.Parse(row["Blog_id"].ToString());
                }
                if (row["Blog_title"] != null)
                {
                    model.Blog_title = row["Blog_title"].ToString();
                }
                if (row["Blog_text"] != null)
                {
                    model.Blog_text = row["Blog_text"].ToString();
                }
                if (row["Blog_read"] != null && row["Blog_read"].ToString() != "")
                {
                    model.Blog_read = int.Parse(row["Blog_read"].ToString());
                }
                if (row["Blog_img"] != null)
                {
                    model.Blog_img = row["Blog_img"].ToString();
                }
                if (row["Blog_is"] != null && row["Blog_is"].ToString() != "")
                {
                    model.Blog_is = int.Parse(row["Blog_is"].ToString());
                }
                if (row["Blog_time"] != null)
                {
                    model.Blog_time = row["Blog_time"].ToString();
                }
                if (row["Blog_delete"] != null && row["Blog_delete"].ToString() != "")
                {
                    model.Blog_delete = int.Parse(row["Blog_delete"].ToString());
                }
                if (row["Blog_typeid"] != null && row["Blog_typeid"].ToString() != "")
                {
                    model.Blog_typeid = int.Parse(row["Blog_typeid"].ToString());
                }
                if (row["Blog_abstract"] != null)
                {
                    model.Blog_abstract = row["Blog_abstract"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Blog_id,Blog_title,Blog_text,Blog_read,Blog_img,Blog_is,Blog_time,Blog_delete,Blog_typeid,Blog_abstract ");
            strSql.Append(" FROM blogs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM blogs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Blog_id desc");
            }
            strSql.Append(")AS Row, T.*  from blogs T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "blogs";
			parameters[1].Value = "Blog_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

