create database PruebaBrive
go
use PruebaBrive
go
create table Producto(
IdProducto int primary key identity(1,1) not null,
Nombre varchar(50),
CodigoBarra varchar(20),
Descripcion varchar(50),
Marca varchar(50),
Cantidad int,
Precio decimal(10,2)
);

--INSERTAR DATOS 
insert into Producto ( Nombre,CodigoBarra, Descripcion, Marca,Cantidad,Precio) values
('Cafe legal','50910010', 'Frasco de Cafe', 'Legal', 30 , 50),
('Chocolate de la Abuelita','50910012', 'Tabletas de chocolate', 'Nestle',50,  25),
('Bonafina','50910013', 'Bebida bonafina sabor naranjada', 'Nestle',45,  1749)

select * from Producto;

---PROCEDIMIENTOS ALMACENADOS
-- insertar productos
 create procedure InsertarProductos
@Nombre varchar(50),
@CodigoBarra varchar(50),
@Descripcion varchar(50),
@Marca varchar(50),
@Cantidad int,
@Precio decimal(10,2)
as 
begin
insert into Producto values(@Nombre,@CodigoBarra,@Descripcion,@Marca,@Cantidad,@Precio)
end
go

--Eliminar Producto
create procedure EliminarProductos
@IdProducto int
as begin
delete from Producto where IdProducto=@IdProducto
end
go
--ActualizarProducto
create procedure ActulizarProductos
@IdProducto int,
@Nombre varchar(50),
@CodigoBarra varchar(50),
@Descripcion varchar(50),
@Marca varchar(50),
@Cantidad int,
@Precio decimal(10,2)
as begin
update Producto set 
Nombre=@Nombre,
CodigoBarra=@CodigoBarra,
Descripcion=@Descripcion,
Marca=@Marca,
Cantidad=@Cantidad,
Precio=@Precio
where IdProducto=@IdProducto
end
go
--obtener producto por id
create procedure ObtenerProductoId
@IdProducto int
as begin
select * from Producto where IdProducto=@IdProducto
end
go
 --obtener por medio de una lista
 create procedure ObtenerProductos
 as begin
 select * from Producto
 end

create procedure CompraProductos 
@IdProducto int, @Cantidad int
 as begin
 update Producto set 
 Cantidad -= @Cantidad
 where IdProducto= @IdProducto
 end