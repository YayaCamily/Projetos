CREATE DATABASE MinhaBaseDeDados;
USE MinhaBaseDeDados;

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100),
    Email NVARCHAR(100)
);
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

class Program
{
    static string connectionString = "Data Source=seu_servidor;Initial Catalog=MinhaBaseDeDados;Integrated Security=True";

    static void Main()
    {
        Console.WriteLine("Bem-vindo(a) ao programa de gestão de clientes!");

        // Exemplo de uso: inserir um novo cliente
        InserirCliente(new Cliente { Nome = "João", Email = "joao@email.com" });

        // Exemplo de uso: listar todos os clientes
        List<Cliente> clientes = ListarClientes();
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Id: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}");
        }

        // Aguarda o usuário pressionar qualquer tecla para encerrar o programa
        Console.ReadKey();
    }

    static void InserirCliente(Cliente cliente)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Clientes (Nome, Email) VALUES (@Nome, @Email)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Email", cliente.Email);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    static List<Cliente> ListarClientes()
    {
        List<Cliente> clientes = new List<Cliente>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Nome, Email FROM Clientes";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Cliente cliente = new Cliente
                {
                    Id = (int)reader["Id"],
                    Nome = reader["Nome"].ToString(),
                    Email = reader["Email"].ToString()
                };
                clientes.Add(cliente);
            }
            reader.Close();
        }
        return clientes;
    }
}
