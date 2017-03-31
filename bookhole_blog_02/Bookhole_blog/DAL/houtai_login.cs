using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Bookhole_blog.DAL
{
    /// <summary>
    /// 数据访问类:houtai_login
    /// </summary>
    public partial class houtai_login
    {
        public houtai_login()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("houtai_id", "houtai_login");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int houtai_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from houtai_login");
            strSql.Append(" where houtai_id=@houtai_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@houtai_id", MySqlDbType.Int32,11)          };
            parameters[0].Value = houtai_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Bookhole_blog.Model.houtai_login model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into houtai_login(");
            strSql.Append("houtai_id,houtai_pwd,houtai_level)");
            strSql.Append(" values (");
            strSql.Append("@houtai_id,@houtai_pwd,@houtai_level)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@houtai_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@houtai_pwd", MySqlDbType.VarChar,255),
                    new MySqlParameter("@houtai_level", MySqlDbType.Int32,11)};
            parameters[0].Value = model.houtai_id;
            parameters[1].Value = model.houtai_pwd;
            parameters[2].Value = model.houtai_level;

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
        public bool Update(Bookhole_blog.Model.houtai_login model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update houtai_login set ");
            strSql.Append("houtai_pwd=@houtai_pwd,");
            strSql.Append("houtai_level=@houtai_level");
            strSql.Append(" where houtai_id=@houtai_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@houtai_pwd", MySqlDbType.VarChar,255),
                    new MySqlParameter("@houtai_level", MySqlDbType.Int32,11),
                    new MySqlParameter("@houtai_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.houtai_pwd;
            parameters[1].Value = model.houtai_level;
            parameters[2].Value = model.houtai_id;

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
        public bool Delete(int houtai_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from houtai_login ");
            strSql.Append(" where houtai_id=@houtai_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@houtai_id", MySqlDbType.Int32,11)          };
            parameters[0].Value = houtai_id;

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
        public bool DeleteList(string houtai_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from houtai_login ");
            strSql.Append(" where houtai_id in (" + houtai_idlist + ")  ");
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
        public Bookhole_blog.Model.houtai_login GetModel(int houtai_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select houtai_id,houtai_pwd,houtai_level from houtai_login ");
            strSql.Append(" where houtai_id=@houtai_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@houtai_id", MySqlDbType.Int32,11)          };
            parameters[0].Value = houtai_id;

            Bookhole_blog.Model.houtai_login model = new Bookhole_blog.Model.houtai_login();
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
        public Bookhole_blog.Model.houtai_login DataRowToModel(DataRow row)
        {
            Bookhole_blog.Model.houtai_login model = new Bookhole_blog.Model.houtai_login();
            if (row != null)
            {
                if (row["houtai_id"] != null && row["houtai_id"].ToString() != "")
                {
                    model.houtai_id = int.Parse(row["houtai_id"].ToString());
                }
                if (row["houtai_pwd"] != null)
                {
                    model.houtai_pwd = row["houtai_pwd"].ToString();
                }
                if (row["houtai_level"] != null && row["houtai_level"].ToString() != "")
                {
                    model.houtai_level = int.Parse(row["houtai_level"].ToString());
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
            strSql.Append("select houtai_id,houtai_pwd,houtai_level ");
            strSql.Append(" FROM houtai_login ");
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
            strSql.Append("select count(1) FROM houtai_login ");
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
                strSql.Append("order by T.houtai_id desc");
            }
            strSql.Append(")AS Row, T.*  from houtai_login T ");
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
			parameters[0].Value = "houtai_login";
			parameters[1].Value = "houtai_id";
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

