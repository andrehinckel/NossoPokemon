DROP TABLE IF EXISTS pokemons;
DROP TABLE IF EXISTS categorias;

CREATE TABLE categorias(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100)
);

CREATE TABLE pokemons(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_categoria INT NOT NULL,
	FOREIGN KEY(id_categoria) REFERENCES categorias(id),
	nome VARCHAR(100) NOT NULL
);

SELECT categorias.id AS 'CategoriaId', categorias.nome AS 'CategoriaNome', pokemons.id AS 'Id', pokemons.nome AS 'Nome' FROM pokemons INNER JOIN categorias ON(pokemons.id_categoria = categorias.id);