using System.Data.SqlClient;
using Dapper;

public static class BD
{   
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
    static public void agregarCandidato(Candidatos can){
        string sql = "INSERT INTO Candidatos @candidato";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new{candidato = can});
        }
    }
    static public void EliminarCantidato(int idCandidato){
        string sql = "DELETE FROM Candidatos WHERE idCandidato = @pidCandidato";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pidCandidato = idCandidato});
        }
    }
    static public void verInfoPartido(int idPartido){
        string sql = "SELECT * FROM PARTIDO WHERE idPartido = @idPartido";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Partidos partido = db.QueryFirstOrDefault<Partidos>(sql, new{idPartido = idPartido});
        } 
    }
}