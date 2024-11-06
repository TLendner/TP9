using System.Data.SqlClient;
using Dapper;
namespace Login.Models;

public class BD
{
    private static string ConnectionString = @"Server=DESKTOP-TOMI\SQLEXPRESS;DataBase=Green Gains;Trusted_Connection=True;";

    public static void AgregarUsuario(string username, string password, string mail, string pregunta)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Usuario (username, password, mail, pregunta) VALUES (@pUsername, CONVERT(varchar(32), HASHBYTES('md5', @pPassword), 2), @pMail, @pPregunta)";
            db.Execute(sql, new { pUsername = username, pPassword = password, pMail = mail, pPregunta = pregunta });
        }
    }

    public static Usuario? Mostrar(string username, string password)
    {
        Usuario? usuario;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE username = @pUsername AND password = CONVERT(varchar(32), HASHBYTES('md5', @pPassword), 2)";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pUsername = username, pPassword = password });
        }
        return usuario;
    }

    public static Usuario? MostrarOlvide(string username, string mail, string pregunta)
    {
        Usuario? usuario;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE username = @pUsername AND mail = @pMail AND pregunta = @pPregunta";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pUsername = username, pMail = mail, pPregunta = pregunta });
        }
        return usuario;
    }


    public static void CambiarPassword(string username, string password)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "UPDATE Usuario SET password = CONVERT(varchar(32), HASHBYTES('md5', @pPassword), 2) WHERE username = @pUsername";
            db.Execute(sql, new { pUsername = username, pPassword = password });
        }
    }

}