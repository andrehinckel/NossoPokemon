﻿using Model;
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
       
    }
}