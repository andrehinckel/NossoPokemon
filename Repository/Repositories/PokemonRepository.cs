using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public class PokemonRepository : IPokemonRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Pokemon pokemon)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"INSERT INTO pokemons (id_categoria, nome) OUTPUT INSERTED.ID VALUES (@ID_CATEGORIA, @NOME)";
            command.Parameters.AddWithValue("@ID_CATEGORIA", pokemon.IdCategoria);
            command.Parameters.AddWithValue("@NOME", pokemon.Nome);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public Pokemon ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> ObterTodos(string pesquisa)
        {
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"SELECT categorias.id AS 'CategoriaId', categorias.nome AS 'CategoriaNome', pokemons.id AS 'Id', pokemons.nome AS 'Nome' FROM pokemons INNER JOIN categorias ON(pokemons.id_categoria = categorias.id);";

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (DataRow row in table.Rows)
            {
                Pokemon pokemon = new Pokemon();
                pokemon.Id = Convert.ToInt32(row["Id"]);
                pokemon.Nome = row["Nome"].ToString();
                pokemon.IdCategoria = Convert.ToInt32(row["CategoriaId"]);
                pokemon.Categoria = new Categoria();
                pokemon.Categoria.Id = Convert.ToInt32(row["CategoriaId"]);
                pokemon.Categoria.Nome = row["CategoriaNome"].ToString();
                pokemons.Add(pokemon);
            }
            return pokemons;
        }

        public bool Update(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
