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
	DestinatarioID int primary key identity(1,1),
	Fecha date,
	Nombre varchar(30),
	CantidadCartas int
);

SET IDENTITY_INSERT Cartas ON

insert into Cartas (CartaID, Fecha, DestinatarioID, Cuerpo, Cantidad ) values ('1','2019/7/2','1', 'Hola', '1');

 select * from Cartas;

 SET IDENTITY_INSERT Cartas OFF

 SET IDENTITY_INSERT Destinatario ON

 insert into Destinatario (DestinatarioID, Fecha,  nombre, CantidadCartas) values ('1','2019/7/2', 'Luiso', '1');

 select * from Destinatario;

 SET IDENTITY_INSERT Destinatario OFF