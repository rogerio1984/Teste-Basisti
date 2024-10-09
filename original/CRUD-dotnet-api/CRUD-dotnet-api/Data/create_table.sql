USE [master]
GO
/****** Object:  Database [Basisti]    Script Date: 09/10/2024 19:55:55 ******/
CREATE DATABASE [Basisti]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Basisti', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Basisti.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Basisti_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Basisti_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Basisti] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Basisti].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Basisti] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Basisti] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Basisti] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Basisti] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Basisti] SET ARITHABORT OFF 
GO
ALTER DATABASE [Basisti] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Basisti] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Basisti] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Basisti] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Basisti] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Basisti] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Basisti] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Basisti] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Basisti] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Basisti] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Basisti] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Basisti] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Basisti] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Basisti] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Basisti] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Basisti] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Basisti] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Basisti] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Basisti] SET  MULTI_USER 
GO
ALTER DATABASE [Basisti] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Basisti] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Basisti] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Basisti] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Basisti] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Basisti] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Basisti] SET QUERY_STORE = OFF
GO
USE [Basisti]
GO
/****** Object:  Table [dbo].[Assunto]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assunto](
	[CodAs] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Assunto] PRIMARY KEY CLUSTERED 
(
	[CodAs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[CodAu] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[CodAu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livro]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livro](
	[CodL] [int] NOT NULL,
	[Titulo] [varchar](40) NOT NULL,
	[Editora] [varchar](40) NOT NULL,
	[Edicao] [int] NOT NULL,
	[AnoPublicacao] [varchar](4) NOT NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[CodL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livro_Assunto]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livro_Assunto](
	[CodL] [int] NOT NULL,
	[CodAs] [int] NOT NULL,
 CONSTRAINT [PK_Livro_Assunto] PRIMARY KEY CLUSTERED 
(
	[CodL] ASC,
	[CodAs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livro_Autor]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livro_Autor](
	[CodL] [int] NOT NULL,
	[CodAu] [int] NOT NULL,
 CONSTRAINT [PK_Livro_Autor] PRIMARY KEY CLUSTERED 
(
	[CodL] ASC,
	[CodAu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormaCompra]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormaCompra](
	[CodForm] [int] NOT NULL,
	[Descricao] [varchar](20) NOT NULL,
 CONSTRAINT [PK_FormaCompra] PRIMARY KEY CLUSTERED 
(
	[CodForm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livro_FormaCompra]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livro_FormaCompra](
	[CodForm] [int] NOT NULL,
	[CodL] [int] NOT NULL,
	[Valor] [float] NOT NULL,
 CONSTRAINT [PK_Livro_FormaCompra] PRIMARY KEY CLUSTERED 
(
	[CodForm] ASC,
	[CodL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_autores]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_autores]
AS

  select a.nome autor, l.Titulo, l.editora,l.edicao,l.AnoPublicacao,ISNULL(l.Assuntos,'') Assuntos, ISNULL(l.Valores,'') Valores from autor a
  join Livro_Autor la on la.CodAu = a.CodAu
  join (
  select l.*,	
			STUFF((
			select ','+ a.descricao
		   from livro_assunto la 
			join assunto a on a.CodAs = la.Codas
			where la.codl = l.Codl
			for xml path('')),1,1,'') Assuntos,
			STUFF((
			select ','+ fc.Descricao +': ( R$'+ convert(varchar(20),lfc.Valor)+' )'
		   from Livro_FormaCompra lfc 
			join FormaCompra fc on lfc.CodForm = fc.CodForm
			where lfc.codl = l.Codl
			for xml path('')),1,1,'') Valores
		from livro l
  ) l on la.CodL = l.codl

GO
/****** Object:  View [dbo].[vw_livros]    Script Date: 09/10/2024 19:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_livros]
AS
select l.*,
STUFF((
    select ','+ a.nome
	from livro_autor la 
    join autor a on a.CodAu = la.CodAu
    where la.codl = l.Codl
    for xml path('')),1,1,'') Autores,
	STUFF((
    select ','+ a.descricao
   from livro_assunto la 
    join assunto a on a.CodAs = la.Codas
    where la.codl = l.Codl
    for xml path('')),1,1,'') Assuntos
from livro l
GO
ALTER TABLE [dbo].[Livro_Assunto]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Assunto_Assunto] FOREIGN KEY([CodAs])
REFERENCES [dbo].[Assunto] ([CodAs])
GO
ALTER TABLE [dbo].[Livro_Assunto] CHECK CONSTRAINT [FK_Livro_Assunto_Assunto]
GO
ALTER TABLE [dbo].[Livro_Assunto]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Assunto_Livro] FOREIGN KEY([CodL])
REFERENCES [dbo].[Livro] ([CodL])
GO
ALTER TABLE [dbo].[Livro_Assunto] CHECK CONSTRAINT [FK_Livro_Assunto_Livro]
GO
ALTER TABLE [dbo].[Livro_Autor]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Autor_Autor] FOREIGN KEY([CodAu])
REFERENCES [dbo].[Autor] ([CodAu])
GO
ALTER TABLE [dbo].[Livro_Autor] CHECK CONSTRAINT [FK_Livro_Autor_Autor]
GO
ALTER TABLE [dbo].[Livro_Autor]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Autor_Livro] FOREIGN KEY([CodL])
REFERENCES [dbo].[Livro] ([CodL])
GO
ALTER TABLE [dbo].[Livro_Autor] CHECK CONSTRAINT [FK_Livro_Autor_Livro]
GO
ALTER TABLE [dbo].[Livro_FormaCompra]  WITH CHECK ADD  CONSTRAINT [FK_Livro_FormaCompra_FormaCompra] FOREIGN KEY([CodForm])
REFERENCES [dbo].[FormaCompra] ([CodForm])
GO
ALTER TABLE [dbo].[Livro_FormaCompra] CHECK CONSTRAINT [FK_Livro_FormaCompra_FormaCompra]
GO
ALTER TABLE [dbo].[Livro_FormaCompra]  WITH CHECK ADD  CONSTRAINT [FK_Livro_FormaCompra_Livro] FOREIGN KEY([CodL])
REFERENCES [dbo].[Livro] ([CodL])
GO
ALTER TABLE [dbo].[Livro_FormaCompra] CHECK CONSTRAINT [FK_Livro_FormaCompra_Livro]
GO
USE [master]
GO
ALTER DATABASE [Basisti] SET  READ_WRITE 
GO
