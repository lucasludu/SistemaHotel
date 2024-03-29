create database SistemaHotel;
use SistemaHotel;

CREATE TABLE Cliente(
IdCliente int primary key identity,
TipoDocumento  varchar(15),
Documento varchar(15),
NombreCompleto varchar(50),
Correo varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

create table RolUsuario
(
IdRolUsuario int primary key identity,
Descripcion varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE Usuario(
IdUsuario int primary key identity,
NombreCompleto varchar(50),
Correo varchar(50),
IdRolUsuario int references RolUsuario(IdRolUsuario),
Clave varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE  Categoria(
IdCategoria int primary key identity,
Descripcion varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

GO

CREATE TABLE  Piso(
IdPiso int primary key identity,
Descripcion varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE  EstadoHabitacion(
IdEstadoHabitacion int primary key,
Descripcion varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE Habitacion(
IdHabitacion int primary key identity,
Numero varchar(50),
Detalle varchar(100),
Precio decimal(10,2),
IdEstadoHabitacion int references EstadoHabitacion(IdEstadoHabitacion),
IdPiso int references PISO(IdPiso),
IdCategoria int references CATEGORIA(IdCategoria),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE Recepcion(
IdRecepcion int primary key identity,
IdCliente int references Cliente(IdCliente),
IdHabitacion int references HABITACION(IdHabitacion),
FechaEntrada datetime default getdate(),
FechaSalida datetime,
FechaSalidaConfirmacion datetime,
PrecioInicial decimal(10,2),
Adelanto decimal(10,2),
PrecioRestante decimal(10,2),
TotalPagado decimal(10,2) default 0,
CostoPenalidad decimal(10,2) default 0,
Observacion varchar(500),
Estado bit
)