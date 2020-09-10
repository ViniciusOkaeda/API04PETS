using APIPETS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPETS.Interfaces
{
    interface ITipoDePet
    {
        //Nome da Classe, Atributo Cadastrar (Classe, argumento para armazenar o cadastro).
        TipoDePet Cadastrar(TipoDePet tp);

        //lista que vai ler tudo na classe TipoDePet.
        List<TipoDePet> LerTodos();

        // Buscar Algo na classe TipoDePet por id do tipo int.
        TipoDePet BuscarPorId(int id);

        //Alterar algo na classe TipoDePet (passando um id expecífico, na classe TipoDePet e no argumento de armazenamento do TipoDePet.
        TipoDePet Alterar(int id, TipoDePet tp);

        //Exclui algo buscando pelo id, sem retorno.
        void Excluir(int id);
    }
}
