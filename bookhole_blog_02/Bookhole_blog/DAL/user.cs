using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Bookhole_blog.DAL
{
	/// <summary>
	/// 数据访问类:user
	/// </summary>
	public partial class user
	{
		public user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("User_id", "user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int User_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from user");
			strSql.Append(" where User_id=@User_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@User_id", MySqlDbType.Int32,11)			};
			parameters[0].Value = User_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Bookhole_blog.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into user(");
			strSql.Append("User_id,User_name,User_pwd,User_img,User_qq,User_phone)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_name,@User_pwd,@User_img,@User_qq,@User_phone)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@User_id", MySqlDbType.Int32,11),
					new MySqlParameter("@User_name", MySqlDbType.VarChar,20),
					new MySqlParameter("@User_pwd", MySqlDbType.VarChar,20),
					new MySqlParameter("@User_img", MySqlDbType.VarChar,50),
					new MySqlParameter("@User_qq", MySqlDbType.Int32,11),
					new MySqlParameter("@User_phone", MySqlDbType.Int32,11)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.User_name;
			parameters[2].Value = model.User_pwd;
			parameters[3].Value = model.User_img;
			parameters[4].Value = model.User_qq;
			parameters[5].Value = model.User_phone;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Bookhole_blog.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update user set ");
			strSql.Append("User_name=@User_name,");
			strSql.Append("User_pwd=@User_pwd,");
			strSql.Append("User_img=@User_img,");
			strSql.Append("User_qq=@User_qq,");
			strSql.Append("User_phone=@User_phone");
			strSql.Append(" where User_id=@User_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@User_name", MySqlDbType.VarChar,20),
					new MySqlParameter("@User_pwd", MySqlDbType.VarChar,20),
					new MySqlParameter("@User_img", MySqlDbType.VarChar,50),
					new MySqlParameter("@User_qq", MySqlDbType.Int32,11),
					new MySqlParameter("@User_phone", MySqlDbType.Int32,11),
					new MySqlParameter("@User_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.User_name;
			parameters[1].Value = model.User_pwd;
			parameters[2].Value = model.User_img;
			parameters[3].Value = model.User_qq;
			parameters[4].Value = model.User_phone;
			parameters[5].Value = model.User_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int User_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where User_id=@User_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@User_id", MySqlDbType.Int32,11)			};
			parameters[0].Value = User_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string User_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where User_id in ("+User_idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public Bookhole_blog.Model.user GetModel(int User_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select User_id,User_name,User_pwd,User_img,User_qq,User_phone from user ");
			strSql.Append(" where User_id=@User_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@User_id", MySqlDbType.Int32,11)			};
			parameters[0].Value = User_id;

			Bookhole_blog.Model.user model=new Bookhole_blog.Model.user();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
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
		public Bookhole_blog.Model.user DataRowToModel(DataRow row)
		{
			Bookhole_blog.Model.user model=new Bookhole_blog.Model.user();
			if (row != null)
			{
				if(row["User_id"]!=null && row["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(row["User_id"].ToString());
				}
				if(row["User_name"]!=null)
				{
					model.User_name=row["User_name"].ToString();
				}
				if(row["User_pwd"]!=null)
				{
					model.User_pwd=row["User_pwd"].ToString();
				}
				if(row["User_img"]!=null)
				{
					model.User_img=row["User_img"].ToString();
				}
				if(row["User_qq"]!=null && row["User_qq"].ToString()!="")
				{
					model.User_qq=int.Parse(row["User_qq"].ToString());
				}
				if(row["User_phone"]!=null && row["User_phone"].ToString()!="")
				{
					model.User_phone=int.Parse(row["User_phone"].ToString());
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
			strSql.Append("select User_id,User_name,User_pwd,User_img,User_qq,User_phone ");
			strSql.Append(" FROM user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM user ");
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
				strSql.Append("order by T.User_id desc");
			}
			strSql.Append(")AS Row, T.*  from user T ");
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
			parameters[0].Value = "user";
			parameters[1].Value = "User_id";
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

