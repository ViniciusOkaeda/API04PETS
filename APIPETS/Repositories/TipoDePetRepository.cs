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
    public class TipoDePetRepository : ITipoDePet
    {
        // Chamamos nossa classe de conexao ( classe dentro do Context, no caso deste projeto é PetShop).
        PetShopContext conexao = new PetShopContext();

        // 2 - Chamamos nosso objeto que dará os comandos SQL
        SqlCommand cmd = new SqlCommand();

        public TipoDePet Alterar(int id, TipoDePet tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "UPDATE TipoDePet SET" +
                "Descricao = @descricao WHERE IdTipoDePet = @id ";

            cmd.Parameters.AddWithValue("@descricao", tp.Descricao);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return tp;
        }

        public TipoDePet BuscarPorId(int id)
        {
            //  Conexão com o banco
            cmd.Connection = conexao.Conectar();

            //  Preparo minha Query 
            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            //  Executar o comando para ler
            SqlDataReader dados = cmd.ExecuteReader();

            //  Crio uma lista para exibir meus cadastros
            TipoDePet tipopet = new TipoDePet();

            while (dados.Read())
            {
                //  Jogamos os dados lidos no banco no objeto TipoDePet
                tipopet.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                tipopet.Descricao = dados.GetValue(1).ToString();
            }

            // Desconectar
            conexao.Desconectar();

            return tipopet;
        }

        public TipoDePet Cadastrar(TipoDePet tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO TipoDePet (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", tp.Descricao);


            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return tp;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<TipoDePet> LerTodos()
        {
            // Conecto com o banco
            cmd.Connection = conexao.Conectar();

            //  Preparo minha Query 
            cmd.CommandText = "SELECT * FROM TipoDePet";

            //  Executo o comando para ler
            SqlDataReader dados = cmd.ExecuteReader();

            // Crio uma lista para mostrar meus cadastros
            List<TipoDePet> tipopet = new List<TipoDePet>();

            //  Jogar os dados lidos no banco na lista
            while (dados.Read())
            {
                tipopet.Add(
                    new TipoDePet()
                    {
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            // 8 - Desconectar
            conexao.Desconectar();

            return tipopet;
        }
    }
}
