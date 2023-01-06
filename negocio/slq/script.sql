DROP DATABASE atividade_mysql;
CREATE DATABASE atividade_mysql;
USE atividade_mysql;

CREATE TABLE clientes (
	id int NOT NULL AUTO_INCREMENT,
	nome varchar(60) NOT NULL,
	email varchar(100) NOT NULL,
	PRIMARY KEY (id));

-- backup
-- mysqldump -u root -p atividade_mysql > C:\Users\Jaziel\source\repos\aplicacao_console_mysql\aplicacao_console_mysql\slq\backup.sql

-- restaurar database

-- mysql -u root -p atividade_mysql < C:\Users\Jaziel\source\repos\aplicacao_console_mysql\aplicacao_console_mysql\slq\backup.sql
-- mysql -u root -p < C:\Users\Jaziel\source\repos\aplicacao_console_mysql\aplicacao_console_mysql\slq\backup.sql

--alter user
-- ALTER USER 'userName'@'localhost' IDENTIFIED BY 'New-Password-Here';
-- ALTER USER 'root'@'localhost' IDENTIFIED BY '1234';
