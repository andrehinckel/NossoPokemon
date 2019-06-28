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
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = "DELETE FROM pokemons WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
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
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = "SELECT * FROM pokemons WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if (table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            Pokemon pokemon = new Pokemon();
            pokemon.Id = Convert.ToInt32(row["id"]);
            pokemon.IdCategoria = Convert.ToInt32(row["id_categoria"]);
            pokemon.Nome = row["nome"].ToString();
            return pokemon;
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
            SqlCommand command = Connection.OpenConnection();
            command.CommandText = @"UPDATE pokemons SET nome = @NOME, id_categoria = @ID_CATEGORIA WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", pokemon.Id);
            command.Parameters.AddWithValue("@NOME", pokemon.Nome);
            command.Parameters.AddWithValue("@ID_CATEGORIA", pokemon.IdCategoria);
            int quantideAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantideAfetada == 1;
        }
    }
}
