using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Bookhole_blog.DAL
{
    /// <summary>
    /// 数据访问类:img
    /// </summary>
    public partial class img
    {
        public img()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("Img_id", "img");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Img_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from img");
            strSql.Append(" where Img_id=@Img_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Img_id", MySqlDbType.Int32,11)         };
            parameters[0].Value = Img_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Bookhole_blog.Model.img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into img(");
            strSql.Append("Img_id,Img_address,Img_text,Img_is)");
            strSql.Append(" values (");
            strSql.Append("@Img_id,@Img_address,@Img_text,@Img_is)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Img_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@Img_address", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Img_text", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Img_is", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Img_id;
            parameters[1].Value = model.Img_address;
            parameters[2].Value = model.Img_text;
            parameters[3].Value = model.Img_is;

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
        public bool Update(Bookhole_blog.Model.img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update img set ");
            strSql.Append("Img_address=@Img_address,");
            strSql.Append("Img_text=@Img_text,");
            strSql.Append("Img_is=@Img_is");
            strSql.Append(" where Img_id=@Img_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Img_address", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Img_text", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Img_is", MySqlDbType.Int32,11),
                    new MySqlParameter("@Img_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Img_address;
            parameters[1].Value = model.Img_text;
            parameters[2].Value = model.Img_is;
            parameters[3].Value = model.Img_id;

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
        public bool Delete(int Img_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from img ");
            strSql.Append(" where Img_id=@Img_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Img_id", MySqlDbType.Int32,11)         };
            parameters[0].Value = Img_id;

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
        public bool DeleteList(string Img_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from img ");
            strSql.Append(" where Img_id in (" + Img_idlist + ")  ");
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
        public Bookhole_blog.Model.img GetModel(int Img_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Img_id,Img_address,Img_text,Img_is from img ");
            strSql.Append(" where Img_id=@Img_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Img_id", MySqlDbType.Int32,11)         };
            parameters[0].Value = Img_id;

            Bookhole_blog.Model.img model = new Bookhole_blog.Model.img();
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
        public Bookhole_blog.Model.img DataRowToModel(DataRow row)
        {
            Bookhole_blog.Model.img model = new Bookhole_blog.Model.img();
            if (row != null)
            {
                if (row["Img_id"] != null && row["Img_id"].ToString() != "")
                {
                    model.Img_id = int.Parse(row["Img_id"].ToString());
                }
                if (row["Img_address"] != null)
                {
                    model.Img_address = row["Img_address"].ToString();
                }
                if (row["Img_text"] != null)
                {
                    model.Img_text = row["Img_text"].ToString();
                }
                if (row["Img_is"] != null && row["Img_is"].ToString() != "")
                {
                    model.Img_is = int.Parse(row["Img_is"].ToString());
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
            strSql.Append("select Img_id,Img_address,Img_text,Img_is ");
            strSql.Append(" FROM img ");
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
            strSql.Append("select count(1) FROM img ");
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
                strSql.Append("order by T.Img_id desc");
            }
            strSql.Append(")AS Row, T.*  from img T ");
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
			parameters[0].Value = "img";
			parameters[1].Value = "Img_id";
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

