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
servico VARCHAR(20),
preco int,
data_usu VARCHAR(20),
nome_usu VARCHAR(50),
email_usu VARCHAR(50),
tel_usu VARCHAR(11),
cod_usu INT,
cod_horas INT,
FOREIGN KEY (cod_horas) REFERENCES Tbl_Horas(cod_horas)
);

CREATE TABLE Tbl_Horas(
cod_horas INT PRIMARY KEY AUTO_INCREMENT,
horarios VARCHAR(20) NOT NULL
);


drop table tbl_Agendamento;

SELECT * FROM tbl_Agendamento INNER JOIN tbl_Horas ON tbl_Agendamento.cod_Horas = tbl_Horas.cod_Horas;

INSERT INTO Tbl_Horas(horarios)
VALUES('16h00');

SELECT * FROM tbl_Login;

INSERT INTO tbl_Agendamento(cod_agendamento, servico, preco, nome_usu, email_usu, tel_usu, cod_usu)
VALUES(6, "Corte Cabelo", 35, "Guilherme Sella Fernandes", "guilherme@sella.com", "11959848463", 18 );

SELECT * FROM tbl_Agendamento;

UPDATE tbl_Login SET nome_usu = 'Enildo', tel_usu = '11946299765' WHERE cod_usu = 2; 
