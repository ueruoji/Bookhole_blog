using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Bookhole_blog.DAL
{
    /// <summary>
    /// 数据访问类:tell
    /// </summary>
    public partial class tell
    {
        public tell()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("Tell_id", "tell");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tell_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tell");
            strSql.Append(" where Tell_id=@Tell_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Tell_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = Tell_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Bookhole_blog.Model.tell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tell(");
            strSql.Append("Tell_blogid,Tell_userid,Tell_text,Tell_time,Tell_id)");
            strSql.Append(" values (");
            strSql.Append("@Tell_blogid,@Tell_userid,@Tell_text,@Tell_time,@Tell_id)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Tell_blogid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Tell_userid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Tell_text", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Tell_time", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Tell_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Tell_blogid;
            parameters[1].Value = model.Tell_userid;
            parameters[2].Value = model.Tell_text;
            parameters[3].Value = model.Tell_time;
            parameters[4].Value = model.Tell_id;

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
        public bool Update(Bookhole_blog.Model.tell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tell set ");
            strSql.Append("Tell_blogid=@Tell_blogid,");
            strSql.Append("Tell_userid=@Tell_userid,");
            strSql.Append("Tell_text=@Tell_text,");
            strSql.Append("Tell_time=@Tell_time");
            strSql.Append(" where Tell_id=@Tell_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Tell_blogid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Tell_userid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Tell_text", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Tell_time", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Tell_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Tell_blogid;
            parameters[1].Value = model.Tell_userid;
            parameters[2].Value = model.Tell_text;
            parameters[3].Value = model.Tell_time;
            parameters[4].Value = model.Tell_id;

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
        public bool Delete(int Tell_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tell ");
            strSql.Append(" where Tell_id=@Tell_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Tell_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = Tell_id;

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
        public bool DeleteList(string Tell_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tell ");
            strSql.Append(" where Tell_id in (" + Tell_idlist + ")  ");
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
        public Bookhole_blog.Model.tell GetModel(int Tell_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Tell_blogid,Tell_userid,Tell_text,Tell_time,Tell_id from tell ");
            strSql.Append(" where Tell_id=@Tell_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Tell_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = Tell_id;

            Bookhole_blog.Model.tell model = new Bookhole_blog.Model.tell();
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
        public Bookhole_blog.Model.tell DataRowToModel(DataRow row)
        {
            Bookhole_blog.Model.tell model = new Bookhole_blog.Model.tell();
            if (row != null)
            {
                if (row["Tell_blogid"] != null && row["Tell_blogid"].ToString() != "")
                {
                    model.Tell_blogid = int.Parse(row["Tell_blogid"].ToString());
                }
                if (row["Tell_userid"] != null && row["Tell_userid"].ToString() != "")
                {
                    model.Tell_userid = int.Parse(row["Tell_userid"].ToString());
                }
                if (row["Tell_text"] != null)
                {
                    model.Tell_text = row["Tell_text"].ToString();
                }
                if (row["Tell_time"] != null)
                {
                    model.Tell_time = row["Tell_time"].ToString();
                }
                if (row["Tell_id"] != null && row["Tell_id"].ToString() != "")
                {
                    model.Tell_id = int.Parse(row["Tell_id"].ToString());
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
            strSql.Append("select Tell_blogid,Tell_userid,Tell_text,Tell_time,Tell_id ");
            strSql.Append(" FROM tell ");
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
            strSql.Append("select count(1) FROM tell ");
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
                strSql.Append("order by T.Tell_id desc");
            }
            strSql.Append(")AS Row, T.*  from tell T ");
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
			parameters[0].Value = "tell";
			parameters[1].Value = "Tell_id";
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

