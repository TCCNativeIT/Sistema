CREATE DATABASE BdBarbearia;
USE BdBarbearia;

CREATE TABLE tbl_Login(
usuario VARCHAR(50) primary key,
senha VARCHAR(10),
tipo INT 
);

CREATE TABLE tbl_Cliente(
cod_Cli INT PRIMARY KEY AUTO_INCREMENT,
nome_Cli VARCHAR(50),
tel_Cli VARCHAR(13),
email_Cli VARCHAR(50)
);

CREATE TABLE tbl_Agendamento(
servico VARCHAR(20) NOT NULL,
preco VARCHAR(20) NOT NULL,
horario DATETIME NOT NULL
);

INSERT INTO tbl_Login(usuario,senha,tipo)
VALUES('Admin','123','2');

SELECT * FROM tbl_Login;
