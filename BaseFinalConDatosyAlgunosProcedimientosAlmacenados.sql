USE [tienda_kat3]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulo](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [money] NOT NULL,
	[categoria] [int] NULL,
	[id_proveedor] [int] NULL,
	[existencias] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Categoria] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

alter table [dbo].[categoria]
add [descripcion] [varchar](200) null


/****** Object:  Table [dbo].[detalle_venta]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[id_venta] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[subtotal] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[ubicacion] [varchar](150) NULL,
	[telefono] [varchar](9) NULL,
	[correo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[tipo_usuario] [varchar](50) NULL,
	[usuario] [varchar](50) NULL,
	[contraseña] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vendedor]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendedor](
	[id_vendedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[telefono] [varchar](9) NULL,
	[direccion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_vendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[id_vendedor] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[total] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[articulo] ON 

INSERT [dbo].[articulo] ([id_articulo], [nombre], [precio], [categoria], [id_proveedor], [existencias]) VALUES (25, N'Fanta', 1.5000, 1, 1, 100)
INSERT [dbo].[articulo] ([id_articulo], [nombre], [precio], [categoria], [id_proveedor], [existencias]) VALUES (26, N'Fresca', 1.5000, 1, 1, 200)
INSERT [dbo].[articulo] ([id_articulo], [nombre], [precio], [categoria], [id_proveedor], [existencias]) VALUES (27, N'Pepino', 0.5000, 2, 2, 50)
INSERT [dbo].[articulo] ([id_articulo], [nombre], [precio], [categoria], [id_proveedor], [existencias]) VALUES (28, N'SevenUP', 0.7500, 1, 1, 300)
INSERT [dbo].[articulo] ([id_articulo], [nombre], [precio], [categoria], [id_proveedor], [existencias]) VALUES (29, N'Tropical', 1.7500, 1, 1, 300)
SET IDENTITY_INSERT [dbo].[articulo] OFF
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([id_categoria], [Nombre_Categoria]) VALUES (1, N'Bebidas')
INSERT [dbo].[categoria] ([id_categoria], [Nombre_Categoria]) VALUES (2, N'Verduras')
INSERT [dbo].[categoria] ([id_categoria], [Nombre_Categoria]) VALUES (3, N'Frutas')
INSERT [dbo].[categoria] ([id_categoria], [Nombre_Categoria]) VALUES (4, N'Lacteos')
SET IDENTITY_INSERT [dbo].[categoria] OFF
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([id_proveedor], [nombre], [ubicacion], [telefono], [correo]) VALUES (1, N'Coca Cola', N'Nejapa', N'2505-0504', N'coca@hotmail.com')
INSERT [dbo].[proveedor] ([id_proveedor], [nombre], [ubicacion], [telefono], [correo]) VALUES (2, N'Verduras y Frutas', N'San Salvador', N'2266-4455', N'frutas@yahoo.com')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [tipo_usuario], [usuario], [contraseña]) VALUES (1, N'Administrador', N'Admin123', N'Admin123')
INSERT [dbo].[usuarios] ([id_usuario], [tipo_usuario], [usuario], [contraseña]) VALUES (2, N'Auxiliar de Linea', N'Aux123', N'Aux123')
SET IDENTITY_INSERT [dbo].[usuarios] OFF
SET IDENTITY_INSERT [dbo].[vendedor] ON 

INSERT [dbo].[vendedor] ([id_vendedor], [nombre], [apellido], [telefono], [direccion]) VALUES (1, N'Juan', N'Valdez', N'2205-0808', N'Los mangos')
INSERT [dbo].[vendedor] ([id_vendedor], [nombre], [apellido], [telefono], [direccion]) VALUES (2, N'Alberto', N'Rodriguez', N'2278-0505', N'Los jocotes')
SET IDENTITY_INSERT [dbo].[vendedor] OFF
SET IDENTITY_INSERT [dbo].[venta] ON 

INSERT [dbo].[venta] ([id_venta], [id_vendedor], [fecha], [total]) VALUES (1, 1, CAST(N'1905-06-25T00:00:00.000' AS DateTime), 10.0000)
INSERT [dbo].[venta] ([id_venta], [id_vendedor], [fecha], [total]) VALUES (2, 2, CAST(N'1905-06-25T00:00:00.000' AS DateTime), 20.0000)
INSERT [dbo].[venta] ([id_venta], [id_vendedor], [fecha], [total]) VALUES (3, 2, CAST(N'1905-06-25T00:00:00.000' AS DateTime), 15.5000)
SET IDENTITY_INSERT [dbo].[venta] OFF
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD FOREIGN KEY([categoria])
REFERENCES [dbo].[categoria] ([id_categoria])
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([id_proveedor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD FOREIGN KEY([id_articulo])
REFERENCES [dbo].[articulo] ([id_articulo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD FOREIGN KEY([id_venta])
REFERENCES [dbo].[venta] ([id_venta])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([id_vendedor])
REFERENCES [dbo].[vendedor] ([id_vendedor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[InsertarArticulos]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertarArticulos]
(
	@nombre varchar(50),
	@precio money,
	@categoria int,
	@id_proveedor int,
	@existencias int
)
as
insert into articulo values(@nombre,@precio,@categoria,@id_proveedor,@existencias)
GO

create procedure [dbo].[InsertarCategorias]
(
@Nombre_categoria varchar(50),
@descripcion varchar(200)
)
as insert into categoria values(@Nombre_categoria,@descripcion)
go

/****** Object:  StoredProcedure [dbo].[Mostrar_Inventario]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Mostrar_Inventario] as
select articulo.nombre, articulo.precio,articulo.existencias, categoria.Nombre_Categoria, proveedor.nombre as distribuidora 
from articulo inner join categoria on articulo.categoria=categoria.id_categoria inner join  proveedor
on articulo.id_proveedor=proveedor.id_proveedor
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Ventas]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Mostrar_Ventas] @id_vendedor int as
select detalle_venta.id_venta, vendedor.nombre, vendedor.apellido, venta.fecha,
articulo.nombre, articulo.precio,detalle_venta.cantidad ,detalle_venta.subtotal
from 
vendedor inner join venta
on vendedor.id_vendedor=venta.id_vendedor
inner join detalle_venta
on venta.id_venta=detalle_venta.id_venta
inner join articulo
on detalle_venta.id_articulo = articulo.id_articulo
where vendedor.id_vendedor=@id_vendedor
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Ventas_Totales]    Script Date: 28/3/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Mostrar_Ventas_Totales] @id_vendedor int
as
select detalle_venta.id_venta,vendedor.nombre, vendedor.apellido, venta.fecha,sum(detalle_venta.subtotal) as Total_Venta
from 
vendedor inner join venta
on vendedor.id_vendedor=venta.id_vendedor
inner join detalle_venta
on venta.id_venta=detalle_venta.id_venta
inner join articulo
on detalle_venta.id_articulo = articulo.id_articulo
where vendedor.id_vendedor= @id_vendedor
group by detalle_venta.id_venta,vendedor.nombre, vendedor.apellido, venta.fecha
GO

select * from categoria

select * from vendedor

select * from usuarios