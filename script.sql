CREATE DATABASE petshop;
USE petshop;

CREATE TABLE clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    email VARCHAR(100)
);

CREATE TABLE pets (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    especie VARCHAR(50) NOT NULL,
    raca VARCHAR(50),
    cliente_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES clientes (id)
);

CREATE TABLE servicos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    descricao VARCHAR(100) NOT NULL,
    preco DECIMAL(10,2) NOT NULL
);

CREATE TABLE atendimentos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pet_id INT NOT NULL,
    servico_id INT NOT NULL,
    data_atendimento VARCHAR(20) NOT NULL,
    valor_total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (pet_id) REFERENCES pets (id),
    FOREIGN KEY (servico_id) REFERENCES servicos (id)
);
