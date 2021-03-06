USE [master]
GO
/****** Object:  Database [Office]    Script Date: 28.05.2021 10:10:57 ******/
CREATE DATABASE [Office]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Office', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Office.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Office_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Office_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Office] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Office].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Office] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Office] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Office] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Office] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Office] SET ARITHABORT OFF 
GO
ALTER DATABASE [Office] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Office] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Office] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Office] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Office] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Office] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Office] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Office] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Office] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Office] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Office] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Office] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Office] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Office] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Office] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Office] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Office] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Office] SET RECOVERY FULL 
GO
ALTER DATABASE [Office] SET  MULTI_USER 
GO
ALTER DATABASE [Office] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Office] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Office] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Office] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Office] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Office] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Office', N'ON'
GO
ALTER DATABASE [Office] SET QUERY_STORE = OFF
GO
USE [Office]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 28.05.2021 10:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 28.05.2021 10:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Patronymic] [nvarchar](20) NOT NULL,
	[DateBirthday] [date] NOT NULL,
	[About] [nvarchar](300) NOT NULL,
	[IdDepartment] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Title]) VALUES (1, N'Математика')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (2, N'Информационные технологии')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (3, N'Физика')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (4, N'Кибербезопасность')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (5, N'Молекулярная биология')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (6, N'Теоретическая информатика')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (7, N'Биохимия')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (8, N'Теоретическая физика')
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (9, N'Ядерная физика')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (16, N'Денис', N'Парамонов', N'Александрович', CAST(N'1993-01-28' AS Date), N'Преподаю математику', 1)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (17, N'Владислав', N'Ващенков', N'Антонович', CAST(N'1990-12-03' AS Date), N'Занимаюсь теоретической физикой', 8)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (18, N'Алексей', N'Назаров', N'Алексеевич', CAST(N'1996-10-07' AS Date), N'Преподаю торию информационных технологий', 6)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (19, N'Алекснадр', N'Крыжинский', N'Романович', CAST(N'1984-09-21' AS Date), N'Занимаюс исследованием микроорганизмов', 5)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (20, N'Антон', N'Пермский', N'Сергеевич', CAST(N'1987-05-18' AS Date), N'Профессор наук, веду лекции в ВУЗе', 1)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (21, N'Борис', N'Франтасьев', N'Денисович', CAST(N'1983-12-31' AS Date), N'Преподаю физику', 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (22, N'Николай', N'Козлов', N'Васильевич', CAST(N'1987-02-28' AS Date), N'Изучаю теорию струн', 6)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (23, N'Валерий', N'Кирзачёв', N'Александрович', CAST(N'1986-01-12' AS Date), N'Биолог теоретик преподаватель', 7)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (24, N'Ольга', N'Сотникова', N'Александровна', CAST(N'1984-11-10' AS Date), N'Болог исследователь', 7)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (31, N'Елена', N'Хорошова', N'Сергеевна', CAST(N'1994-12-30' AS Date), N'Инженер программист, занмаюсь построение ЛВС', 2)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (32, N'Генадий', N'Вавилов', N'Евгеневич', CAST(N'1981-05-05' AS Date), N'Провожу эксперементы по теории струн', 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (33, N'Валентин', N'Антонов', N'Алексеевич', CAST(N'1993-02-14' AS Date), N'Занимаюсь сбором информации по безопастности систем', 4)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (34, N'Олег', N'Богатырёв', N'Денисович', CAST(N'1986-09-21' AS Date), N'Занимаюсь изучением холодного синтеза', 9)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (35, N'Альберт', N'Карамзин', N'Фёдорович', CAST(N'1993-10-23' AS Date), N'Провожу исследования в области ращепления атомов', 9)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Patronymic], [DateBirthday], [About], [IdDepartment]) VALUES (36, N'Василий', N'Бариславов', N'Александрович', CAST(N'1993-11-27' AS Date), N'Преподаю основы инфорамционных технологий', 6)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([IdDepartment])
REFERENCES [dbo].[Departments] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Office] SET  READ_WRITE 
GO
