using System.Data.SqlClient;
using Dapper;

public static class BD
{   
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
    static public void AgregarCandidato(Candidatos can){
        string sql = "INSERT INTO Candidatos (IdPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES (@ip,@a,@n,@fn,@f,@p)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new{ip=can.IdPartido,a=can.Apellido,n=can.Nombre,fn=can.FechaNacimiento,f=can.Foto,p=can.Postulacion});
        }
    }
    static public void EliminarCantidato(int IdCandidato){
        string sql = "DELETE FROM Candidatos WHERE IdCandidato = @pidCandidato";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pidCandidato = IdCandidato});
        }
    }
    static public Partidos verInfoPartido(int IdPartido){
        string sql = "SELECT * FROM PARTIDOS WHERE idPartido = @pidPartido";
        Partidos partido;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            partido = db.QueryFirstOrDefault<Partidos>(sql, new{pidPartido = IdPartido});
        } 
        return partido;
    }
    static public Candidatos verInfoCandidato(int IdCandidato){
        string sql = "SELECT * FROM CANDIDATOS WHERE IdCandidato = @idCandidato";
        Candidatos candidato;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            candidato = db.QueryFirstOrDefault<Candidatos>(sql, new{idCandidato = IdCandidato});
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
    static public List<Candidatos> listarCandidatos(int IdPartido){
        string sql = "SELECT * FROM Candidatos WHERE idPartido = @idPartido";
        List<Candidatos> listaC = new List<Candidatos>{}; 
        using(SqlConnection db = new SqlConnection(_connectionString)){
           listaC = db.Query<Candidatos>(sql, new{idPartido = IdPartido}).ToList();
        }
        return listaC;
    }
}