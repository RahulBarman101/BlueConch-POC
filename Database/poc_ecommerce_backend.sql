USE [master]
GO
/****** Object:  Database [POC BlueConch]    Script Date: 05-03-2021 13:12:31 ******/
CREATE DATABASE [POC BlueConch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POC BlueConch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\POC BlueConch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'POC BlueConch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\POC BlueConch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [POC BlueConch] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POC BlueConch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [POC BlueConch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [POC BlueConch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [POC BlueConch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [POC BlueConch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [POC BlueConch] SET ARITHABORT OFF 
GO
ALTER DATABASE [POC BlueConch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [POC BlueConch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [POC BlueConch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [POC BlueConch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [POC BlueConch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [POC BlueConch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [POC BlueConch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [POC BlueConch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [POC BlueConch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [POC BlueConch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [POC BlueConch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [POC BlueConch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [POC BlueConch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [POC BlueConch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [POC BlueConch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [POC BlueConch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [POC BlueConch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [POC BlueConch] SET RECOVERY FULL 
GO
ALTER DATABASE [POC BlueConch] SET  MULTI_USER 
GO
ALTER DATABASE [POC BlueConch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [POC BlueConch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [POC BlueConch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [POC BlueConch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [POC BlueConch] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [POC BlueConch] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'POC BlueConch', N'ON'
GO
ALTER DATABASE [POC BlueConch] SET QUERY_STORE = OFF
GO
USE [POC BlueConch]
GO
/****** Object:  Table [dbo].[tblAddress]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAddress](
	[addressid] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[phno] [bigint] NULL,
	[city] [varchar](20) NOT NULL,
	[state] [varchar](20) NOT NULL,
	[country] [varchar](20) NOT NULL,
	[pincode] [int] NOT NULL,
	[description] [varchar](50) NULL,
	[landmark] [varchar](20) NULL,
	[created_on] [date] NULL,
	[updated_on] [date] NULL,
 CONSTRAINT [PK_tblAddress] PRIMARY KEY CLUSTERED 
(
	[addressid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblItem]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblItem](
	[itemid] [int] NOT NULL,
	[itemName] [varchar](20) NULL,
	[description] [varchar](50) NULL,
	[itemFrom] [varchar](20) NULL,
	[itemPrice] [money] NULL,
	[itemRating] [smallint] NULL,
	[itemRatingCount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[itemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrder](
	[order_id] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[orderItem] [varchar](20) NOT NULL,
	[quantity] [smallint] NULL,
	[price] [money] NULL,
	[itemId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[userid] [int] NOT NULL,
	[firstname] [varchar](20) NOT NULL,
	[lastname] [varchar](20) NOT NULL,
	[middlename] [varchar](20) NULL,
	[username] [varchar](30) NOT NULL,
	[passwd] [varchar](20) NOT NULL,
	[created_on] [date] NULL,
	[updated_on] [date] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblAddress]  WITH CHECK ADD  CONSTRAINT [FK_tblAddress] FOREIGN KEY([userid])
REFERENCES [dbo].[tblUser] ([userid])
GO
ALTER TABLE [dbo].[tblAddress] CHECK CONSTRAINT [FK_tblAddress]
GO
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD FOREIGN KEY([itemId])
REFERENCES [dbo].[tblItem] ([itemid])
GO
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[tblUser] ([userid])
GO
/****** Object:  StoredProcedure [dbo].[add_address]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[add_address]
	@addid int,
	@userid int,
	@phoneNumber bigint,
	@city varchar(20),
	@state varchar(20),
	@country varchar(20),
	@pincode int,
	@description varchar(50),
	@landmark varchar(20)
as
	begin
	declare @created date, @updated date
	set @created = GETDATE()
	set @updated = GETDATE()
		insert into tblAddress
		([addressid],[userid],[phno],[city],[state],[country],
		[pincode],[description],[landmark],[created_on],[updated_on])
		values 
		(@addid,@userid,@phoneNumber,@city,@state,@country,
		@pincode,@description,@landmark,@created,@updated)
	end
GO
/****** Object:  StoredProcedure [dbo].[add_order]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_order]
	@userid int,
	@orderid int,
	@orderItem varchar(20),
	@quantity smallint,
	@price money,
	@itemid int
	as
		begin
			insert into tblOrder
			([order_id],[userid],[orderItem],[quantity],[price],[itemId])
			values
			(@orderid,@userid,@orderItem,@quantity,@price,@itemid)
		end
GO
/****** Object:  StoredProcedure [dbo].[add_user]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[add_user] 
    @userid int,
    @firstName varchar(20),
		@lastName varchar(20),
		@middleName varchar(20) = '',
		@userName varchar(20),
		@password varchar(20)
AS
    begin
		declare @updated date, @created date
		set @updated = GETDATE()
		set @created = GETDATE()
			insert into tblUser([userid],[firstname],[lastname],[middlename],[username],
			[passwd],[created_on],[updated_on]) values 
			(@userid,@firstName,@lastName,@middleName,@userName,@password,@created,@updated)
		end
GO
/****** Object:  StoredProcedure [dbo].[get_orders]    Script Date: 05-03-2021 13:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[get_orders]
	@uid int
	as
	begin
		select U.firstname, U.lastname, A.city, A.state, A.country, O.orderItem, O.quantity, O.price from tblUser as U
		join tblAddress as A on U.userid = A.userid 
		join tblOrder as O on U.userid = O.userid 
		where U.userid = @uid 
	end
GO
USE [master]
GO
ALTER DATABASE [POC BlueConch] SET  READ_WRITE 
GO
