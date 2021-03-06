﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Trejeitos.Models
{
    public class ClienteModel : Model
    {
        public void Incluir(Cliente cli)
        {
            SqlCommand sql = new SqlCommand();
            sql.Connection = conn;
            sql.CommandText = "insert into Clientes values (@nome,@email,@senha,@rg,@cpf,@data_nascimento,@endereco,@cidade,@estado,@telefone)";
            sql.Parameters.AddWithValue("@nome", cli.nome);
            sql.Parameters.AddWithValue("@email", cli.email);
            sql.Parameters.AddWithValue("@senha", cli.senha);
            sql.Parameters.AddWithValue("@rg", cli.rg);
            sql.Parameters.AddWithValue("@cpf", cli.cpf);
            sql.Parameters.AddWithValue("@Data_nascimento", cli.data_nascimento);
            sql.Parameters.AddWithValue("@endereco", cli.endereco);
            sql.Parameters.AddWithValue("@cidade", cli.cidade);
            sql.Parameters.AddWithValue("@estado", cli.estado);
            sql.Parameters.AddWithValue("@telefone", cli.telefone);
            sql.ExecuteNonQuery();
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Clientes";
            cmd.Connection = conn;

            SqlDataReader clientes = cmd.ExecuteReader();
            while (clientes.Read())
            {
                Cliente cli = new Cliente();

                cli.clienteid = (int)clientes["clienteid"];
                cli.nome = (string)clientes["nome"];
                cli.email = (string)clientes["email"];
                cli.rg = (string)clientes["rg"];
                cli.cpf = (string)clientes["cpf"];
                cli.data_nascimento = (string)clientes["data_nascimento"];
                cli.endereco = (string)clientes["endereco"];
                cli.cidade = (string)clientes["cidade"];
                cli.estado = (string)clientes["estado"];
                cli.telefone = (string)clientes["telefone"];
                lista.Add(cli);
            }
            return lista;
        }
    }
}