CREATE DATABASE BdBarbearia;
USE BdBarbearia;
DROP DATABASE BdBarbearia;

CREATE TABLE tbl_Login(
cod_usu INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
senha VARCHAR(10) NOT NULL,
nome_usu VARCHAR(50) NOT NULL,
tel_usu VARCHAR(11) NOT NULL,
email_usu VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE tbl_Agendamento(
cod_agendamento INT PRIMARY KEY AUTO_INCREMENT,
servico VARCHAR(20) NOT NULL,
preco int NOT NULL,
data DATETIME NOT NULL,
horas VARCHAR(20) NOT NULL,
nome_usu VARCHAR(50) NOT NULL,
email_usu VARCHAR(50) NOT NULL,
cod_usu INT
);


drop table tbl_Agendamento;

INSERT INTO tbl_Login(senha,nome_usu,tel_usu,email_usu)
VALUES('12345','Admin','11946299768','admin@gmail.com');

SELECT * FROM tbl_Login;

INSERT INTO tbl_Agendamento(cod_agendamento, servico, preco, nome_usu, email_usu, tel_usu, cod_usu)
VALUES(6, "Corte Cabelo", 35, "Guilherme Sella Fernandes", "guilherme@sella.com", "11959848463", 18 );

SELECT * FROM tbl_Agendamento;





