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
    static public Partidos VerInfoPartido(int idPartido){
        string sql = "SELECT * FROM Partidos WHERE idPartido = @pidPartido";
        Partidos  partido = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            partido = db.QueryFirstOrDefault<Partidos>(sql, new{pidPartido = idPartido});
        } 
        return partido;
    }
    static public Candidatos VerInfoCandidato(int idCandidato){
        string sql = "SELECT * FROM Candidatos WHERE idCandidato = @pidCandidato";
        Candidatos candidato = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            candidato = db.QueryFirstOrDefault<Candidatos>(sql, new{pidCandidato = idCandidato});
        } 
        return candidato;
    }
    static public List<Partidos> ListarPartidos(){
        List<Partidos> part = null;
        string sql = "SELECT * FROM Partidos";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            part = db.Query<Partidos>(sql).ToList();
        } 
        return part;
    }
    static public List<Candidatos> ListarCandidatos(int idPartido){
        List<Candidatos> candidatos = null;
        string sql = "SELECT * FROM Candidatos WHERE idPartido = @pidPartido";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            candidatos = db.Query<Candidatos>(sql, new {pidPartido = idPartido}).ToList();
        } 
        return candidatos;
    }
}