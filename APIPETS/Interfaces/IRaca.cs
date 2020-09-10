using APIPETS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPETS.Interfaces
{
    interface IRaca
    {
        //Nome da Classe, Atributo Cadastrar (Classe, argumento para armazenar o cadastro).
        Raca Cadastrar(Raca rc);

        //lista que vai ler tudo na classe Raca.
        List<Raca> LerTodos();

        // Buscar Algo na classe Raca por id do tipo int.
        Raca BuscarPorId(int id);

        //Alterar algo na classe Raca (passando um id expecífico, na classe Raca e no argumento de armazenamento da raça.
        Raca Alterar(int id, Raca rc);

        //Exclui algo buscando pelo id, sem retorno.
        void Excluir(int id);
    }
}
