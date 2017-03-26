using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Bookhole_blog.DAL
{
	/// <summary>
	/// 数据访问类:blog_type
	/// </summary>
	public partial class blog_type
	{
		public blog_type()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("Type_id", "blog_type"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Type_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from blog_type");
			strSql.Append(" where Type_id=@Type_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Type_id", MySqlDbType.Int32,11)			};
			parameters[0].Value = Type_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Bookhole_blog.Model.blog_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into blog_type(");
			strSql.Append("Type_id,Type_name,Type_percentage)");
			strSql.Append(" values (");
			strSql.Append("@Type_id,@Type_name,@Type_percentage)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Type_id", MySqlDbType.Int32,11),
					new MySqlParameter("@Type_name", MySqlDbType.VarChar,5),
					new MySqlParameter("@Type_percentage", MySqlDbType.Int32,3)};
			parameters[0].Value = model.Type_id;
			parameters[1].Value = model.Type_name;
			parameters[2].Value = model.Type_percentage;

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
		public bool Update(Bookhole_blog.Model.blog_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update blog_type set ");
			strSql.Append("Type_name=@Type_name,");
			strSql.Append("Type_percentage=@Type_percentage");
			strSql.Append(" where Type_id=@Type_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Type_name", MySqlDbType.VarChar,5),
					new MySqlParameter("@Type_percentage", MySqlDbType.Int32,3),
					new MySqlParameter("@Type_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.Type_name;
			parameters[1].Value = model.Type_percentage;
			parameters[2].Value = model.Type_id;

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
		public bool Delete(int Type_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from blog_type ");
			strSql.Append(" where Type_id=@Type_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Type_id", MySqlDbType.Int32,11)			};
			parameters[0].Value = Type_id;

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
		public bool DeleteList(string Type_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from blog_type ");
			strSql.Append(" where Type_id in ("+Type_idlist + ")  ");
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
		public Bookhole_blog.Model.blog_type GetModel(int Type_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Type_id,Type_name,Type_percentage from blog_type ");
			strSql.Append(" where Type_id=@Type_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Type_id", MySqlDbType.Int32,11)			};
			parameters[0].Value = Type_id;

			Bookhole_blog.Model.blog_type model=new Bookhole_blog.Model.blog_type();
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
		public Bookhole_blog.Model.blog_type DataRowToModel(DataRow row)
		{
			Bookhole_blog.Model.blog_type model=new Bookhole_blog.Model.blog_type();
			if (row != null)
			{
				if(row["Type_id"]!=null && row["Type_id"].ToString()!="")
				{
					model.Type_id=int.Parse(row["Type_id"].ToString());
				}
				if(row["Type_name"]!=null)
				{
					model.Type_name=row["Type_name"].ToString();
				}
				if(row["Type_percentage"]!=null && row["Type_percentage"].ToString()!="")
				{
					model.Type_percentage=int.Parse(row["Type_percentage"].ToString());
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
			strSql.Append("select Type_id,Type_name,Type_percentage ");
			strSql.Append(" FROM blog_type ");
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
			strSql.Append("select count(1) FROM blog_type ");
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
				strSql.Append("order by T.Type_id desc");
			}
			strSql.Append(")AS Row, T.*  from blog_type T ");
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
			parameters[0].Value = "blog_type";
			parameters[1].Value = "Type_id";
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

