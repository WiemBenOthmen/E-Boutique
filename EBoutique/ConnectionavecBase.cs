using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace EBoutique
{
    public class ConnectionavecBase
    {
        private String con="workstation id=iBoutiqureDB.mssql.somee.com;packet size=4096;user id=roukou_SQLLogin_1;pwd=6xvuictlxs;data source=iBoutiqureDB.mssql.somee.com;persist security info=False;initial catalog=iBoutiqureDB";
        public String retourType(String c)
        {
            SqlConnection sql = new SqlConnection(con);
            sql.Open();
            SqlCommand sqlc = new SqlCommand();
            sqlc.CommandText = "Select a.libelleArticle la,a.prix pr from Article a,Type p where a.idType=p.idType and libelleType='"+c+"';";
                sqlc.Connection = sql;
            SqlDataReader sqlr = sqlc.ExecuteReader();
            String retour="";
            while (sqlr.Read())
            {
                retour += "\n "+ sqlr["la"] + " \n prix: " + sqlr["pr"]+ " \n ";

            }
            return retour;
        }
    }
}