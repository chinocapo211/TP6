using System.Data.SqlClient;
using Dapper;

public static class BD
{   
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
    static public void AgregarCandidato(Candidatos can){
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
    static public Partidos verInfoPartido(int idPartido){
        string sql = "SELECT * FROM PARTIDO WHERE idPartido = @idPartido";
        Partidos partido;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            partido = db.QueryFirstOrDefault<Partidos>(sql, new{idPartido = idPartido});
        } 
        return partido;
    }
    static public Candidatos verInfoCandidato(int idCandidato){
        string sql = "SELECT * FROM PARTIDO WHERE idCandidato = @idCandidato";
        Candidatos candidato;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            candidato = db.QueryFirstOrDefault<Candidatos>(sql, new{idCandidato = idCandidato});
        }
        return candidato;
    }
    static public List<Partidos> listarPartidos(){
        string sql = "SELECT * FROM Partidos";
        List<Partidos> listaP = new List<Partidos>{}; 
        using(SqlConnection db = new SqlConnection(_connectionString)){
           listaP = db.Query<Partidos>(sql).ToList();
        }
        return listaP;
    }
    static public List<Candidatos> listarCandidatos(int idPartido){
        string sql = "SELECT * FROM Candidatos WHERE idPartido = @idPartido";
        List<Candidatos> listaC = new List<Candidatos>{}; 
        using(SqlConnection db = new SqlConnection(_connectionString)){
           listaC = db.Query<Candidatos>(sql, new{idPartido = idPartido}).ToList();
        }
        return listaC;
    }
}