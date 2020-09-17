--USE master
--DROP DATABASE dbONG_VCompleta2


create database dbONG_VCompleta2
go
use  dbONG_VCompleta2
go

---------------------------------------------------------------------------------------------------

create table tblTipoProducto(
idTipoProducto int identity(1,1) Primary Key Not null  ,
NombreTipoP nvarchar(100) Not null,
)

create table tblTipoServicio (
idTiposervicio  int identity(1,1) primary key not null,
nombreTiposervicio varchar(50)

)
create table tblServicio(
idServicio int identity(1,1) primary key not null,
nombreServicio varchar(50),
valorServicio float,
idTiposervicio int,
constraint FK_Servicio foreign key (idTiposervicio) references tblTipoServicio(idTiposervicio),

)

create table tblProvincia(
idProvincia int identity(1,1) primary key not null,
NombreProvincia nvarchar(100) Not null,

)

create table tblProveedores(
idProveedor int identity(1,1) not null primary key,
NombreProveedor nvarchar(100) Not null,
rucProveedor nvarchar(50) not null,
idProvincia int not null,
ciudad nvarchar(100)not null,
direccionProveedor nvarchar(100) not null,
telefono nvarchar(100) not null,
constraint FK_Provincia foreign key (idProvincia) references tblProvincia(idProvincia)
on delete cascade
on update cascade,
)

create table tblProductos(
idProducto int identity(1,1) Primary Key NOT NULL ,
NombreProducto nvarchar (100) Not null,
idTipoProducto int,
idProveedor int,
Marca nvarchar (100) not null,
Precio float not null,
Stock int not null,
constraint FK_TipoProducto foreign key (idTipoProducto) references tblTipoProducto(idTipoProducto)
ON DELETE CASCADE
ON UPDATE CASCADE,
constraint FK_idProveedor foreign key (idProveedor) references tblProveedores(idProveedor)
ON DELETE CASCADE
ON UPDATE CASCADE
)

create table tblTipoCliente (
 intTipocliente int identity(1,1) primary key not null,
 nombreTipocliente varchar(50),
)

create table tblCliente(
idCliente int identity(1,1) primary key not null,
intTipocliente int,
nombreCliente varchar(50),
apellidoCliente varchar(50),
cedulaCliente varchar(13),
telefonoCliente varchar(10),
direcionCliente varchar(50),
correoCliente varchar(50),

constraint FK_tipoCliente foreign key (intTipocliente) references tblTipoCliente(intTipocliente),

)

create table tblUsuario(
idUsuario int identity(1,1) primary key not null,
nombreUsuario varchar(50),
contraseniaUsuario varchar(50)
)

create table tblFactura(
idFactura int identity(1,1) primary key not null,
fechaFactura datetime default getdate(),
idCliente int ,
idUsuario int,
subtotal money,
iva money,
total money,

constraint FK_Usuario foreign key (idUsuario) references tblUsuario(idUsuario),
constraint FK_Cliente foreign key (idCliente) references tblCliente(idCliente)
)

create table tblDetalle(
idDetalle int identity(1,1) primary key not null,
idProducto int,
idServicio int,
idFactura int,
cantidadD int,
importe money,


 constraint FK_Dproducto foreign key (idProducto) references tblProductos(idProducto),
  constraint FK_Dservicio foreign key (idServicio) references tblServicio(idServicio),
    constraint FK_DFactura foreign key (idFactura) references tblFactura(idFactura)
)

create table tblEmpleado(
idEmpleado int identity(1,1) primary key not null,
nombreEmpleado varchar(20),
)

--------------------------------------------------------------------------------------------------

insert into tblTipoCliente values ('Estándar'),('Negocios/Empresas')
insert into tblTipoProducto values ('Limpieza'),('Mantenimiento'),('Repuestos'),('Varios')
insert into tblTipoServicio values ('Alineación'),('Balanceo'),('Cambio de Aceite'),('Enllantaje'),('Lavado'),('Varios')

insert into tblProvincia
values
('Azuay'), 
('Bolívar'),
('Cañar'), 
('Carchi'), 
('Chimborazo'), 
('Cotopaxi'), 
('El Oro'), 
('Esmeraldas'), 
('Galápagos'),
('Guayas'), 
('Imbabura'),
('Loja'), 
('Los Ríos'), 
('Manabí'), 
('Morona Santiago'), 
('Napo'), 
('Orellana'), 
('Pastaza'), 
('Pichincha'), 
('Santa Elena'), 
('Santo Domingo de los Tsáchilas'),
('Sucumbíos'), 
('Tungurahua'), 
('Zamora Chinchipe')

insert into tblProveedores
values
('Lubricantes Ecuador S.A','1790000990001',19,'Quito','Av.Ecuatoriana y calle Alonso','02 2955156'),
('Distribuidora Alonso S.A','1760000660001',23,'Ambato','Av.Panamericana Sur y Ulloa','0978456732'),
('Compañia de repuestos La Ecuatoriana S.A','17987654300001',1,'Cuenca','Av. España 1437.','07 2865209'),
('CONAUTO C.A','0990018685001',10,'Guayaquil','Av. Juan Tanca Marengo y Av. José Santiago Castillo Km. 1.8.','04 2599 900'),
('MEGUIARS C.A','0922399035001',10,'Guayaquil','Av Luis Plaza Dañin y 8va Albatros','04 6032277'),
('XADO EC S.A','0922399035001',19,'Quito','Av La Prensa N42-95 y Mariano Echeveria - Sector La Y','02 2272223'),
('Servicios Industriales Vallejo Araujo S.A.','1792198569001',19,'Quito','Av. Mariscal Antonio Sucre N52-120 Av. La Florida','02 3945580'),
('LUBRICANTES INTERNACIONALES S.A.','0991231366001',10,'Daule','Cuenca # 602 y Guillermo Davis','04 3803880'),
('FILTROCORP S.A.','0991466177001',19,'Quito','AV. DE LOS ARUPOS E3-184 Y AVDA. GENERAL ELOY ALFARO','02 2472500'),
('IVERNEG S.A.','0990658498001',23,'Ambato','Av Rumiñahui y Av Los Shyris calle Duchicela N90877','03 2480480')



insert into tblProductos 
values
('Auto Shampoo En Gel De Lavado Suave',1,5,'MEGUIARS',13.99,20),
('Aceite 6 Dexron Aceite Atf',2,2,'VALVOLINE',10.99,20),
('Bujias',3,2,'BOSH',11.99,20)



insert into tblServicio
values
('Enllantaje',20.00,2),
('Filtrado',10.00,1),
('Lavado',10.00,5),
('N/A',null,6)

insert into tblCliente
values
(1,'Juan','Acurio','1726543478','29551345','La Bota y calle A','juanito@gmail.com'),
(2,'Alvaro','Estrada','1873664376','2846742','La Floresta','alv_69@hotmail.com'),
(1,'Pablo','Jimenez','0753675275','2834562','Santa Clara','pablojime@live.com'),
(1,'Hernan','Narvaez','1800328532','24174983','El Tejar','hernanarvaez@hotmail.com')

insert into tblUsuario values
('Carlos Torres','ongsystem')
GO

------------------------------------------------------------------------------------------------------
----------------------------------------VISTAS--------------------------------------------------------
------------------------------------------------------------------------------------------------------

CREATE VIEW vClientes AS
	SELECT 	idCliente,nombreCliente +' '+ apellidoCliente AS 'Cliente',
			cedulaCliente AS 'Cedula',
			telefonoCliente AS 'Telefono',
			direcionCliente AS 'Direccion',
			correoCliente AS 'Correo',
			nombreTipocliente AS 'Tipo' 
	FROM tblCliente JOIN tblTipoCliente 
		ON (tblCliente.intTipocliente=tblTipoCliente.intTipocliente)
GO

CREATE VIEW vProductos AS
	SELECT 	tblProductos.idProducto, 
			tblProductos.NombreProducto,
			tblTipoProducto.NombreTipoP,
			tblProveedores.NombreProveedor,
			tblProductos.Marca,tblProductos.Precio,
			tblProductos.Stock
	FROM tblProductos INNER JOIN tblTipoProducto 
		ON tblProductos.idTipoProducto = tblTipoProducto.idTipoProducto
		INNER JOIN tblProveedores 
			ON tblProductos.idProveedor =tblProveedores.idProveedor 
GO

CREATE VIEW vServicios AS
	SELECT	idServicio,
			nombreServicio,
			valorServicio,
			nombreTiposervicio 
	FROM tblServicio JOIN tblTipoServicio 
		ON (tblServicio.idServicio=tblTipoServicio.idTiposervicio) 
GO

CREATE VIEW vEncabezado AS
	SELECT	tblFactura.idFactura AS 'ID',
			fechaFactura AS 'Fecha',
			nombreCliente +' '+ apellidoCliente AS 'Nombre Cliente',
			cedulaCliente AS 'Cedula',
			direcionCliente AS 'Direccion',
			telefonoCliente AS 'Telefono',
			nombreUsuario AS 'Vendedor',
			subtotal AS 'Subtotal',
			iva AS 'IVA (12%)',
			total AS 'Total' 
	FROM tblFactura JOIN tblCliente 
		ON (tblFactura.idCliente=tblCliente.idCliente) 
		JOIN tblUsuario 
			ON (tblFactura.idUsuario=tblUsuario.idUsuario) 
GO

CREATE VIEW vDetalle AS
SELECT 
    tblDetalle.idFactura AS 'iD', 
    tblDetalle.idDetalle '#Detalle',
    'Detalle' = CASE 
        WHEN tblDetalle.idServicio IS NULL THEN tblProductos.NombreProducto 
        WHEN tblDetalle.idProducto IS NULL THEN tblServicio.nombreServicio 
    END, 
	'Valor Unitario' = CASE 
        WHEN tblDetalle.idServicio IS NULL THEN tblProductos.Precio 
        WHEN tblDetalle.idProducto IS NULL THEN tblServicio.valorServicio 
    END,
	tblDetalle.cantidadD AS 'Cantidad', tblDetalle.importe AS 'Importe' 
	FROM tblDetalle LEFT JOIN tblProductos ON tblDetalle.idProducto=tblProductos.idProducto 
	LEFT JOIN tblServicio ON tblDetalle.idServicio=tblServicio.idServicio
GO
---servicios

create view VMostrar
as
	SELECT	idServicio AS 'ID',
			nombreServicio AS 'Nombre',
			nombreTiposervicio AS 'Tipo',
			valorServicio AS 'Valor' 
	from tblServicio join tblTipoServicio
		on tblServicio.idTiposervicio=tblTipoServicio.idTiposervicio;
GO

CREATE VIEW VProveedores
AS
SELECT 	tblProveedores.idProveedor AS 'ID', 
		tblProveedores.NombreProveedor AS 'Nombre',
		tblProveedores.rucProveedor AS 'RUC',
		tblProvincia.NombreProvincia AS 'Provincia',
		tblProveedores.ciudad AS 'Ciudad',
		tblProveedores.direccionProveedor AS 'Dirección',
		tblProveedores.telefono AS 'Teléfono'
FROM tblProveedores INNER JOIN tblProvincia
	ON tblProvincia.idProvincia = tblProveedores.idProvincia
GO

------------------------------------------------------------------------------------------------------
----------------------------------------TRIGGERS------------------------------------------------------
------------------------------------------------------------------------------------------------------

--Trigger Importe
CREATE TRIGGER tr_importe ON tblDetalle AFTER INSERT
AS
BEGIN
	DECLARE @cantidad INT SELECT @cantidad = cantidadD FROM INSERTED
	DECLARE @productoID INT SELECT @productoID = idProducto FROM inserted
	DECLARE @servicioID INT SELECT @servicioID = idServicio FROM inserted
	DECLARE @facturaID INT SELECT @facturaID = idFactura FROM inserted
	IF(@servicioID IS NULL)
		BEGIN
			UPDATE tblDetalle 
			SET importe = @cantidad * (SELECT Precio FROM tblProductos WHERE tblProductos.idProducto=@productoID) 
			WHERE idProducto = @productoID
		END
	ELSE
		BEGIN
			UPDATE tblDetalle 
			SET importe = @cantidad * (SELECT valorServicio FROM tblServicio WHERE tblServicio.idServicio=@servicioID) 
			WHERE idServicio=@servicioID 
		END
	UPDATE tblFactura 
	SET subtotal = (SELECT SUM(importe) FROM tblDetalle WHERE tblDetalle.idFactura=@facturaID) 
	WHERE idFactura = @facturaID
	UPDATE tblFactura 
	SET iva = subtotal * 0.12, 
		total= subtotal*1.12 
	WHERE idFactura = @facturaID
END
GO

CREATE TRIGGER tg_eliminar_cliente
ON tblCliente
INSTEAD OF DELETE 
AS
BEGIN
	IF EXISTS (SELECT * FROM tblFactura WHERE idCliente = (SELECT idCliente FROM deleted))
	BEGIN 
		RAISERROR ('El cliente tiene facturas', 11, 1)
	END
	ELSE 
		DELETE FROM tblCliente WHERE idCliente = (SELECT idCliente FROM deleted)
	END
	
------------------------------------------------------------------------------------------------------
----------------------------------------STORED PROCEDURES---------------------------------------------
------------------------------------------------------------------------------------------------------
GO
--SP Ingreso Nueva Factura
CREATE PROCEDURE sp_NuevaFactura
	@clienteID int,
	@usuarioID int,
	@id int OUTPUT
AS
	insert into tblFactura (idCliente,idUsuario) values (@clienteID,@usuarioID)
	select @id = Scope_Identity() 
GO

--SP Ingreso Detalle
CREATE PROCEDURE sp_IngresoProducto
	@productoID int,
	@facturaID int,
	@cantidad int
AS
	IF(@cantidad <= (SELECT Stock from tblProductos where idProducto = @productoID))
		BEGIN
			insert into tblDetalle (idProducto, idFactura, cantidadD) 
			values (@productoID,@facturaID,@cantidad)
			UPDATE tblProductos 
			SET Stock = (SELECT Stock from tblProductos where idProducto = @productoID) - @cantidad
			WHERE idProducto = @productoID
		END
	ELSE
		BEGIN
			RAISERROR ('No hay suficientes productos en stock', 11, 1)
		END
GO

CREATE PROCEDURE sp_IngresoServicio
	@servicioID int,
	@facturaID int,
	@cantidad int
AS
	insert into tblDetalle (idServicio, idFactura, cantidadD) 
	values (@servicioID,@facturaID,@cantidad)
GO


--SP Ingreso Cliente
CREATE PROCEDURE sp_IngresoCliente
	@TipoClienteID int,
	@nombre varchar(50),
	@apellido varchar(50),
	@cedula varchar(50),
	@telefono varchar(10),
	@direccion varchar(50),
	@correo varchar(50),
	@id int OUTPUT
AS
	insert into tblCliente (intTipocliente, nombreCliente, apellidoCliente, cedulaCliente, telefonoCliente, direcionCliente, correoCliente)
	values (@TipoClienteID, @nombre, @apellido, @cedula, @telefono, @direccion, @correo)
	select @id = Scope_Identity() 
GO

--SP ACTUALIZAR CLIENTE
CREATE PROCEDURE sp_ActualizarCliente
	@clienteID int,
	@TipoClienteID int,
	@nombre varchar(50),
	@apellido varchar(50),
	@cedula varchar(50),
	@telefono varchar(10),
	@direccion varchar(50),
	@correo varchar(50)
AS
	UPDATE tblCliente 
	SET	intTipocliente = @TipoClienteID, 
		nombreCliente=@nombre,
		apellidoCliente=@apellido,
		cedulaCliente=@cedula,
		telefonoCliente=@telefono,
		direcionCliente=@direccion,
		correoCliente=@correo 
	WHERE idCliente=@clienteID
GO

--SP ELIMINAR CLIENTE
CREATE PROCEDURE sp_EliminarCliente
	@clienteID int
AS
	DELETE FROM tblCliente 
	WHERE idCliente=@clienteID
go

----------TABLAS--------------
--SELECT * FROM tblTipoCliente
--SELECT * FROM tblTipoProducto
--SELECT * FROM tblTipoServicio
--SELECT * FROM tblServicio
--SELECT * FROM tblProductos
--SELECT * FROM tblCliente
--SELECT * FROM tblDetalle
--SELECT * FROM tblFactura
--GO


----Ver Cliente
--SELECT * FROM vClientes
----Ver Productos
--SELECT * FROM vProductos
----Ver Servicios
--SELECT * FROM vServicios
----Diseño de Factura
--SELECT * FROM vEncabezado
--SELECT * FROM vDetalle

----SP Ingreso Factura (idCliente,idUsuario)
--EXECUTE sp_NuevaFactura 2,1 
----SP Ingreso Producto (idProducto, idFactura, cantidad)
--EXECUTE sp_IngresoProducto 1,1,3
----SP Ingreso Servicio (idServicio, idFactura, cantidad)
--EXECUTE sp_IngresoServicio 1,1,1
--GO

--SP Ver Clientes
CREATE PROCEDURE sp_VerClientes
AS
	SELECT * FROM vClientes
GO
----- Proveedores Productos------

create proc MostrarProductos
as
	select *from tblProductos
GO

--exec MostrarProductos
go

create proc MostrarTipodeProductos
as
	select *from tblTipoProducto
go

create proc MostrarProveedores
as
select *from tblProveedores
go

create proc MostrarProvincias
as
	select* from tblProvincia
GO

--exec MostrarProvincias
GO

 --- Procedimientos de ingreso de proveedores------
create proc AgregarProveedor
	@NombreProveedor nvarchar(100) ,
	@rucProveedor nvarchar(100) ,
	@idProvincia int ,
	@ciudad nvarchar(100),
	@direccionProveedor nvarchar(100),
	@telefono nvarchar(100) 
as
	insert into tblProveedores 
	values (@NombreProveedor,@rucProveedor,@idProvincia,@ciudad,@direccionProveedor,@telefono)
go

create proc EliminarProveedor
	@idProveedor int
as
	delete from  tblProveedores 
	where idProveedor=@idProveedor
go

create proc ActualizarProveedor
	@NombreProveedor nvarchar(100) ,
	@rucProveedor nvarchar(13) ,
	@idProvincia int ,
	@ciudad nvarchar(100),
	@direccionProveedor nvarchar(100),
	@telefono nvarchar(100) ,
	@idProveedorActualizar int
as
	update tblProveedores 
	SET	NombreProveedor= @NombreProveedor, 
		rucProveedor=  @rucProveedor,
		idProvincia=@idProvincia,
		ciudad=@ciudad,
		direccionProveedor= @direccionProveedor,
		telefono=@telefono
	where idProveedor = @idProveedorActualizar
go

create Procedure Mostrar_Proveedores3
as
	SELECT	tblProveedores.idProveedor,
			tblProveedores.NombreProveedor,
			tblProveedores.rucProveedor,
			tblProvincia.NombreProvincia,
			tblProveedores.ciudad,
			tblProveedores.direccionProveedor,
			tblProveedores.telefono
	FROM tblProveedores INNER JOIN tblProvincia
		ON tblProvincia.idProvincia=tblProveedores.idProvincia
GO

--exec Mostrar_Proveedores3
-------------------------------SERVICIOS-----------------------------------------------------

create proc Mostrarservicios
as
	select *
	from VMostrar;
go

create proc InsertarServicios
	@nombreServicio varchar(100),
	@valorServicio float,
	@tipoServicio int 
as
	insert into tblServicio 
	VALUES (@nombreServicio ,@valorServicio, @tipoServicio)
go
 
create proc EliminarServicio 
	@idServicio int
as
	delete from tblServicio 
	where idServicio=@idServicio
go

create proc EditarServicio
	@nombreServicio varchar(100),
	@valorServicio float,
	@tipoServicio int,
	@idServicio int
as
	update tblServicio 
	SET	nombreServicio = @nombreServicio,
		valorServicio = @valorServicio,
		idTiposervicio = @tipoServicio
	where idServicio=@idServicio;
GO

-- ----------------------------------Verificacion de usuarios-------------------------------------------------

create proc verificarUsuario
	@nombreUsuario varchar(50),
	@contraseniaUsuario varchar(50)
as
--declare @VU smallint 
	SELECT * 
	from tblUsuario 
	where nombreUsuario = @nombreUsuario and contraseniaUsuario = @contraseniaUsuario
go 

--select*from tblUsuario;
--exec verificarUsuario 'Carlos Torres', 'ongsystem' 
--SP Ingreso Nueva Factura
-------------------------------------------Facturacion ---------------------------------

create proc Mostrardetalle
as
	select *
	from vDetalle;
GO

create proc MostrarSIT
	@id int
as
	select Subtotal ,[IVA (12%)], Total 
	from vEncabezado  
	where @id= iD;
GO

create proc MostrarCliente
as
	SELECT * 
	FROM vClientes;
go

create proc IngresarProductos
	@NombreProducto nvarchar (100)  ,
	@idTipoProducto int ,
	@idProveedor int,
	@Marca nvarchar (100) ,
	@Precio float,
	@Stock int 
as
	insert into tblProductos 
	values (@NombreProducto, @idTipoProducto, @idProveedor, @Marca, @Precio, @Stock)
GO

--exec IngresarProductos XC,2,3,"Marco Polo",50.99,34

--select* from tblProductos

GO
create proc EliminarProducto
	@idProducto int
as
	delete from tblProductos 
	where idProducto = @idProducto
GO

--- Productos
create proc EditarProductos
	@NombreProducto nvarchar (100)  ,
	@Marca nvarchar (100) ,
	@idTipoProducto int,
	@idProveedor int,
	@Precio float,
	@Stock int, 
	@idProductoaActualizar int
as
	update tblProductos 
	SET	NombreProducto = @NombreProducto,
		idTipoProducto = @idTipoProducto,
		idProveedor = @idProveedor,
		Marca = @Marca,
		Precio = @Precio,
		Stock = @Stock
	where idProducto = @idProductoaActualizar
go

create procedure Mostrar_Productos
as
	SELECT	tblProductos.idProducto,
			tblProductos.NombreProducto,
			tblTipoProducto.NombreTipoP,
			tblProveedores.NombreProveedor,
			tblProductos.Marca,
			tblProductos.Precio,
			tblProductos.Stock
	FROM tblProductos INNER JOIN tblTipoProducto 
		ON tblProductos.idTipoProducto = tblTipoProducto.idTipoProducto
		INNER JOIN tblProveedores 
			ON tblProductos.idProveedor =tblProveedores.idProveedor 
go

create procedure Obtener_Proveedor_del_Producto
	@idProducto int
as
	SELECT idProveedor 
	FROM tblProveedores 
	WHERE idProveedor = (SELECT idProveedor FROM tblProductos WHERE idProducto = @idProducto)
GO

create procedure Obtener_Tipo_de_Servicio
	@idServicio int
as
	SELECT idTiposervicio 
	FROM tblServicio 
	WHERE idServicio = @idServicio
GO

create proc MostrarTipoProductos
as
	SELECT * 
	from tblTipoProducto
GO

