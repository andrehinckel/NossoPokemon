using Model;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class PokemonController : Controller
    {
        private PokemonRepository repository;

        public PokemonController()
        {
            repository = new PokemonRepository();
        }
        // GET: Pokemon
        public ActionResult Index()
        {
            List<Pokemon> pokemons = repository.ObterTodos("");
            ViewBag.Pokemons = pokemons;
            return View();
        }

        public ActionResult Cadastro()
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos();
            ViewBag.Categorias = categorias;

            return View();
        }

        public ActionResult Store(int idCategoria, string nome)
        {
            Pokemon pokemon = new Pokemon();
            pokemon.IdCategoria = idCategoria;
            pokemon.Nome = nome;
            repository.Inserir(pokemon);
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
     
        public ActionResult Editar(int id)
        {
            Pokemon pokemon = repository.ObterPeloId(id);
            ViewBag.Pokemon = pokemon;

            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos();
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Update(int id, string nome, int idCategoria)
        {
            Pokemon pokemon = new Pokemon();
            pokemon.Id = id;
            pokemon.Nome = nome;
            pokemon.IdCategoria = idCategoria;
            repository.Update(pokemon);
            return RedirectToAction("Index");
        }
    }
}