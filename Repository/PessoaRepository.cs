using cadastroPessoa.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace cadastroPessoa.Repository
{
    public class PessoaRepository : AbstractRepository<Pessoa, int>
    {
        ///<summary>Exclui uma pessoa pela entidade
        ///<param name="entity">Referência de Pessoa que será excluída.</param>
        ///</summary>
       

        public override void DeleteById(int id)
        {
            var connString = "server=localhost;User Id=root;password=;persistsecurityinfo=True;database=cadastro";
            var conn = new MySqlConnection(connString);
            var command = conn.CreateCommand();
            {
                string sql = string.Format("DELETE FROM Pessoa Where Id= {0}", id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override List<Pessoa> GetAll()
        {
            string sql = "Select Id, Nome, Cpf, Endereco, Telefone FROM Pessoa ORDER BY Nome";
            var connString = "server=localhost;User Id=root;password=;persistsecurityinfo=True;database=cadastro";
            var conn = new MySqlConnection(connString);
            var command = conn.CreateCommand();
            {
                var cmd = new MySqlCommand(sql, conn);
                List<Pessoa> list = new List<Pessoa>();
                Pessoa p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Pessoa();
                            p.Id = (int)reader["Id"];
                            p.Nome = reader["Nome"].ToString();
                            p.Cpf = reader["Cpf"].ToString();
                            p.Endereco = reader["Endereco"].ToString();
                            p.Telefone = reader["Telefone"].ToString();
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        public override Pessoa GetById(int id)
        {
            var connString = "server=localhost;User Id=root;password=;persistsecurityinfo=True;database=cadastro";
            var conn = new MySqlConnection(connString);
            var command = conn.CreateCommand();
            {
                string sql = "Select Id, Nome, Cpf, Endereco, Telefone FROM Pessoa WHERE Id=@Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Pessoa p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Pessoa();
                                p.Id = (int)reader["Id"];
                                p.Nome = reader["Nome"].ToString();
                                p.Cpf = reader["Cpf"].ToString();
                                p.Endereco = reader["Endereco"].ToString();
                                p.Telefone = reader["Telefone"].ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        public override void Save(Pessoa entity)
        {
            var connString = "server=localhost;User Id=root;password=;persistsecurityinfo=True;database=cadastro";
            var conn = new MySqlConnection(connString);
            var command = conn.CreateCommand();
            {
                string sql = "INSERT INTO Pessoa (Nome, Cpf, Endereco, Telefone) VALUES (@Nome, @Cpf, @Endereco, @Telefone)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Cpf", entity.Cpf);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void Update(Pessoa entity)
        {
            var connString = "server=localhost;User Id=root;password=;persistsecurityinfo=True;database=cadastro";
            var conn = new MySqlConnection(connString);
            var command = conn.CreateCommand();
            {
                string sql = "UPDATE Pessoa SET Nome=@Nome, Cpf=@Cpf, Endereco=@Endereco, Telefone=@Telefone WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Cpf", entity.Cpf);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}