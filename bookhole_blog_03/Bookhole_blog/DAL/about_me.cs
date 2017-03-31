using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Bookhole_blog.DAL
{
	/// <summary>
	/// 数据访问类:about_me
	/// </summary>
	public partial class about_me
	{
		public about_me()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Bookhole_blog.Model.about_me model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into about_me(");
			strSql.Append("About_title,About_text,About_img,About_phone,About_email)");
			strSql.Append(" values (");
			strSql.Append("@About_title,@About_text,@About_img,@About_phone,@About_email)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@About_title", MySqlDbType.VarChar,50),
					new MySqlParameter("@About_text", MySqlDbType.VarChar,255),
					new MySqlParameter("@About_img", MySqlDbType.VarChar,40),
					new MySqlParameter("@About_phone", MySqlDbType.Int32,11),
					new MySqlParameter("@About_email", MySqlDbType.VarChar,30)};
			parameters[0].Value = model.About_title;
			parameters[1].Value = model.About_text;
			parameters[2].Value = model.About_img;
			parameters[3].Value = model.About_phone;
			parameters[4].Value = model.About_email;

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
		public bool Update(Bookhole_blog.Model.about_me model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update about_me set ");
			strSql.Append("About_title=@About_title,");
			strSql.Append("About_text=@About_text,");
			strSql.Append("About_img=@About_img,");
			strSql.Append("About_phone=@About_phone,");
			strSql.Append("About_email=@About_email");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@About_title", MySqlDbType.VarChar,50),
					new MySqlParameter("@About_text", MySqlDbType.VarChar,255),
					new MySqlParameter("@About_img", MySqlDbType.VarChar,40),
					new MySqlParameter("@About_phone", MySqlDbType.Int32,11),
					new MySqlParameter("@About_email", MySqlDbType.VarChar,30)};
			parameters[0].Value = model.About_title;
			parameters[1].Value = model.About_text;
			parameters[2].Value = model.About_img;
			parameters[3].Value = model.About_phone;
			parameters[4].Value = model.About_email;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from about_me ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Bookhole_blog.Model.about_me GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select About_title,About_text,About_img,About_phone,About_email from about_me ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Bookhole_blog.Model.about_me model=new Bookhole_blog.Model.about_me();
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
		public Bookhole_blog.Model.about_me DataRowToModel(DataRow row)
		{
			Bookhole_blog.Model.about_me model=new Bookhole_blog.Model.about_me();
			if (row != null)
			{
				if(row["About_title"]!=null)
				{
					model.About_title=row["About_title"].ToString();
				}
				if(row["About_text"]!=null)
				{
					model.About_text=row["About_text"].ToString();
				}
				if(row["About_img"]!=null)
				{
					model.About_img=row["About_img"].ToString();
				}
				if(row["About_phone"]!=null && row["About_phone"].ToString()!="")
				{
					model.About_phone=int.Parse(row["About_phone"].ToString());
				}
				if(row["About_email"]!=null)
				{
					model.About_email=row["About_email"].ToString();
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
			strSql.Append("select About_title,About_text,About_img,About_phone,About_email ");
			strSql.Append(" FROM about_me ");
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
			strSql.Append("select count(1) FROM about_me ");
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
			strSql.Append(")AS Row, T.*  from about_me T ");
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
			parameters[0].Value = "about_me";
			parameters[1].Value = "";
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

