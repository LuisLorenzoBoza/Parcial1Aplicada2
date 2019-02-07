create database Parcial1Aplicada2Db
go

use Parcial1Aplicada2Db
go

Create Table Cartas
(
	CartaID int primary key identity(1,1),
	Fecha date, 
	DestinatarioID int,
	Cuerpo varchar(max),
	Cantidad int
);

create table Destinatario 
(
	DestinatrioID int primary key identity(1,1),
	Fecha date,
	Nombre varchar(30),
	CantidadCartas int
);