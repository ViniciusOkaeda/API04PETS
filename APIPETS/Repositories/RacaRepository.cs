using APIPETS.Context;
using APIPETS.Domains;
using APIPETS.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPETS.Repositories
{
    public class RacaRepository : IRaca
    {

        // Chamamos nossa classe de conexao ( classe dentro do Context, no caso deste projeto é PetShop).
        PetShopContext conexao = new PetShopContext();

        // 2 - Chamamos nosso objeto que dará os comandos SQL
        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca rc)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "UPDATE Raca SET" +
                "Descricao = @descricao WHERE IdRaca = @id ";

            cmd.Parameters.AddWithValue("@descricao", rc.Descricao);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return rc;
        }

        public Raca BuscarPorId(int id)
        {
            //  Conexão com o banco
            cmd.Connection = conexao.Conectar();

            //  Preparo minha Query 
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            //  Executar o comando para ler
            SqlDataReader dados = cmd.ExecuteReader();

            //  Crio uma lista para exibir meus cadastros
            Raca raca = new Raca();

            while (dados.Read())
            {
                //  Jogamos os dados lidos no banco no objeto TipoDePet
                raca.IdRaca = Convert.ToInt32(dados.GetValue(0));
                raca.Descricao = dados.GetValue(1).ToString();
            }

            // Desconectar
            conexao.Desconectar();

            return raca;
        }

        public Raca Cadastrar(Raca rc)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", rc.Descricao);


            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return rc;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            // Conexão com o banco
            cmd.Connection = conexao.Conectar();

            //  Preparar minha Query 
            cmd.CommandText = "SELECT * FROM Raca";

            //  Executo o comando para ler
            SqlDataReader dados = cmd.ExecuteReader();
            {

                // Crio uma lista para mostrar meus cadastros
                List<Raca> raca = new List<Raca>();

                //  Jogar os dados lidos no banco na lista
                while (dados.Read())
                {
                    raca.Add(
                        new Raca()
                        {
                            IdRaca = Convert.ToInt32(dados.GetValue(0)),
                            Descricao = dados.GetValue(1).ToString(),
                        }
                    );
                }

                // 8 - Desconectar
                conexao.Desconectar();

                return raca;
            }
        }
    }
}
