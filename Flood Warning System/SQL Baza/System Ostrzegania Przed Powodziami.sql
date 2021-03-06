USE [master]
GO
/****** Object:  Database [MBazaPop]    Script Date: 19.06.2021 23:58:21 ******/
CREATE DATABASE [MBazaPop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MBaza', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MBaza.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MBaza_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MBaza_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MBazaPop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MBazaPop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MBazaPop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MBazaPop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MBazaPop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MBazaPop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MBazaPop] SET ARITHABORT OFF 
GO
ALTER DATABASE [MBazaPop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MBazaPop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MBazaPop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MBazaPop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MBazaPop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MBazaPop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MBazaPop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MBazaPop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MBazaPop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MBazaPop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MBazaPop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MBazaPop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MBazaPop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MBazaPop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MBazaPop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MBazaPop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MBazaPop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MBazaPop] SET RECOVERY FULL 
GO
ALTER DATABASE [MBazaPop] SET  MULTI_USER 
GO
ALTER DATABASE [MBazaPop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MBazaPop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MBazaPop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MBazaPop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MBazaPop] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MBazaPop', N'ON'
GO
ALTER DATABASE [MBazaPop] SET QUERY_STORE = OFF
GO
USE [MBazaPop]
GO
/****** Object:  User [tomek]    Script Date: 19.06.2021 23:58:21 ******/
CREATE USER [tomek] FOR LOGIN [tomek] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [SzefMagazynu]    Script Date: 19.06.2021 23:58:21 ******/
CREATE USER [SzefMagazynu] FOR LOGIN [SzefMagazynu] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [dane]    Script Date: 19.06.2021 23:58:21 ******/
CREATE SCHEMA [dane]
GO
/****** Object:  Schema [danee]    Script Date: 19.06.2021 23:58:21 ******/
CREATE SCHEMA [danee]
GO
/****** Object:  Schema [Sprzedaz]    Script Date: 19.06.2021 23:58:21 ******/
CREATE SCHEMA [Sprzedaz]
GO
/****** Object:  Schema [SprzedazGO]    Script Date: 19.06.2021 23:58:21 ******/
CREATE SCHEMA [SprzedazGO]
GO
/****** Object:  Table [dane].[PomiarRzeki]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PomiarRzeki](
	[PoziomWody] [float] NOT NULL,
	[StandardowyPoziom] [float] NOT NULL,
	[NazwaRzeki] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NazwaRzeki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[ObszarZagrozony]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[ObszarZagrozony](
	[Miasto] [varchar](20) NOT NULL,
	[NazwaRzeki] [varchar](20) NOT NULL,
	[Miejscowosc] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Miejscowosc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PomiarRzekiDlaMiejscowosci]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PomiarRzekiDlaMiejscowosci] AS
(
SELECT oz.Miasto,oz.Miejscowosc,oz.NazwaRzeki,pr.PoziomWody,pr.StandardowyPoziom
FROM dane.ObszarZagrozony AS oz INNER JOIN dane.PomiarRzeki AS pr ON oz.NazwaRzeki = pr.NazwaRzeki
)
GO
/****** Object:  View [dbo].[PomiarMiejscowosc]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PomiarMiejscowosc] AS
SELECT oz.Miejscowosc,oz.Miasto,oz.NazwaRzeki,oz.SluzbaRatunkowa,pr.DataPomiaru,pr.PoziomWody,pr.StandardowyPoziom
FROM dane.ObszarZagrozony AS oz INNER JOIN dane.PomiarRzeki AS pr ON oz.NazwaRzeki = pr.NazwaRzeki;
GO
/****** Object:  Table [dane].[ObszaryZalewowe]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[ObszaryZalewowe](
	[NazwaRzeki] [varchar](20) NOT NULL,
	[Miasto] [varchar](20) NOT NULL,
	[Miejscowosc] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NazwaRzeki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dane].[SprawdzCzyZalewowy]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dane].[SprawdzCzyZalewowy] AS
(
SELECT oz.Miasto,oz.Miejscowosc,oz.NazwaRzeki
FROM dane.ObszarZagrozony AS oz INTERSECT ( SELECT oza.Miasto,oza.Miejscowosc,oza.NazwaRzeki
										FROM dane.ObszaryZalewowe AS oza)
										)

GO
/****** Object:  Table [dane].[DataPowodziHis]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[DataPowodziHis](
	[DataPowodzi] [date] NOT NULL,
	[Miejscowość] [varchar](20) NOT NULL,
	[Dzień] [varchar](2) NOT NULL,
	[Miesiąc] [varchar](2) NOT NULL,
	[Rok] [varchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DataPowodzi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SprawdzCzyByłaPowódz]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[SprawdzCzyByłaPowódz] AS
(
SELECT oz.NazwaRzeki,oz.Miejscowosc,oz.Miasto,dp.DataPowodzi
FROM dane.ObszarZagrozony AS oz INNER JOIN dane.DataPowodziHis AS dp ON oz.Miejscowosc = dp.Miejscowość
)
--INSERT INTO dane.PowodzieHistoryczne(Miejscowosc,Miasto)
--VALUES('Jelesnia','Żywiec')

--INSERT INTO dane.DataPowodziHis(DataPowodzi,Miejscowość,Dzień,Miesiąc,Rok)
--VALUES('01-11-1999','Jelesnia','01','11','1999')

GO
/****** Object:  Table [dane].[PrognozaPogody]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PrognozaPogody](
	[Miasto] [varchar](20) NOT NULL,
	[Deszcz] [bit] NOT NULL,
	[IloscOpadow] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Miasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SprawdzPrognozeDlaMiasta]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[SprawdzPrognozeDlaMiasta] AS
(
SELECT oz.Miasto,oz.Miejscowosc,pp.Deszcz,pp.IloscOpadow
FROM dane.ObszarZagrozony AS oz INNER JOIN dane.PrognozaPogody AS pp ON oz.Miasto = pp.Miasto 
)
--INSERT INTO dane.PowodzieHistoryczne(Miejscowosc,Miasto)
--VALUES('Jelesnia','Żywiec')

--INSERT INTO dane.DataPowodziHis(DataPowodzi,Miejscowość,Dzień,Miesiąc,Rok)
--VALUES('01-11-1999','Jelesnia','01','11','1999')

GO
/****** Object:  Table [dane].[DataPomiaru]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[DataPomiaru](
	[Data] [date] NOT NULL,
	[NazwaRzeki] [varchar](20) NOT NULL,
	[Dzień] [varchar](2) NOT NULL,
	[Miesiąc] [varchar](2) NOT NULL,
	[Rok] [varchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[DataPomiaruZStacji]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[DataPomiaruZStacji](
	[Data] [date] NOT NULL,
	[id_stacji] [int] NOT NULL,
	[Dzień] [varchar](2) NOT NULL,
	[Miesiąc] [varchar](2) NOT NULL,
	[Rok] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[DataPrognozy]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[DataPrognozy](
	[Data] [date] NOT NULL,
	[Miasto] [varchar](20) NOT NULL,
	[Dzień] [varchar](2) NOT NULL,
	[Miesiąc] [varchar](2) NOT NULL,
	[Rok] [varchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[IMGWDaneSynoptyczne]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[IMGWDaneSynoptyczne](
	[stacja] [varchar](20) NOT NULL,
	[suma_opadu] [float] NOT NULL,
	[id_stacji] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_stacji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[OstrzeganieInstytucji]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[OstrzeganieInstytucji](
	[StanZagrozenia] [varchar](10) NOT NULL,
	[MiastoOrganizacji] [varchar](20) NOT NULL,
	[MiejscowoscOrganizacji] [varchar](20) NOT NULL,
	[MiejscowoscZagrozona] [varchar](20) NOT NULL,
	[NazwaSluzby] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[PowiadomienieSMS]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PowiadomienieSMS](
	[NumerTelefonu] [varchar](15) NOT NULL,
	[StanZagrozenia] [varchar](10) NOT NULL,
	[Miasto] [varchar](20) NOT NULL,
	[Miejscowosc] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumerTelefonu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[PowodzieHistoryczne]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PowodzieHistoryczne](
	[Miasto] [varchar](20) NOT NULL,
	[Miejscowosc] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Miejscowosc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[RodzajSłużbyRatunkowej]    Script Date: 19.06.2021 23:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[RodzajSłużbyRatunkowej](
	[Miejscowość] [varchar](20) NOT NULL,
	[Pog_ratunkowe] [bit] NOT NULL,
	[Straż_pożarna] [bit] NOT NULL,
	[Policja] [bit] NOT NULL
) ON [PRIMARY]
GO
INSERT [dane].[DataPomiaru] ([Data], [NazwaRzeki], [Dzień], [Miesiąc], [Rok]) VALUES (CAST(N'2010-05-05' AS Date), N'Jelesianka', N'05', N'05', N'2010')
INSERT [dane].[DataPomiaru] ([Data], [NazwaRzeki], [Dzień], [Miesiąc], [Rok]) VALUES (CAST(N'2010-05-31' AS Date), N'Jelesianka', N'31', N'05', N'2010')
GO
INSERT [dane].[DataPowodziHis] ([DataPowodzi], [Miejscowość], [Dzień], [Miesiąc], [Rok]) VALUES (CAST(N'1999-01-11' AS Date), N'Jelesnia', N'01', N'11', N'1999')
INSERT [dane].[DataPowodziHis] ([DataPowodzi], [Miejscowość], [Dzień], [Miesiąc], [Rok]) VALUES (CAST(N'2000-02-06' AS Date), N'Żywiec', N'02', N'06', N'2021')
GO
INSERT [dane].[DataPrognozy] ([Data], [Miasto], [Dzień], [Miesiąc], [Rok]) VALUES (CAST(N'2021-02-06' AS Date), N'Żywiec', N'02', N'06', N'2021')
GO
INSERT [dane].[IMGWDaneSynoptyczne] ([stacja], [suma_opadu], [id_stacji]) VALUES (N'Bielsko Biała', 0, 12600)
GO
INSERT [dane].[ObszaryZalewowe] ([NazwaRzeki], [Miasto], [Miejscowosc]) VALUES (N'Kocierzanka', N'Żywiec', N'Łękawica')
GO
INSERT [dane].[ObszarZagrozony] ([Miasto], [NazwaRzeki], [Miejscowosc]) VALUES (N'Zywiec', N'Koszarawa', N'Jelesnia')
INSERT [dane].[ObszarZagrozony] ([Miasto], [NazwaRzeki], [Miejscowosc]) VALUES (N'Żywiec', N'Kocierzanka', N'Łękawica')
INSERT [dane].[ObszarZagrozony] ([Miasto], [NazwaRzeki], [Miejscowosc]) VALUES (N'Zywiec', N'Koszarawa', N'Przyborow')
INSERT [dane].[ObszarZagrozony] ([Miasto], [NazwaRzeki], [Miejscowosc]) VALUES (N'Żywiec', N'Sopotnia Wielka', N'Sopotnia Wielka')
INSERT [dane].[ObszarZagrozony] ([Miasto], [NazwaRzeki], [Miejscowosc]) VALUES (N'Warszawa', N'Wisla', N'Warszawa')
GO
INSERT [dane].[OstrzeganieInstytucji] ([StanZagrozenia], [MiastoOrganizacji], [MiejscowoscOrganizacji], [MiejscowoscZagrozona], [NazwaSluzby]) VALUES (N'Powodziowe', N'Żywiec', N'Żywiec', N'Łękawica', N'Policja')
INSERT [dane].[OstrzeganieInstytucji] ([StanZagrozenia], [MiastoOrganizacji], [MiejscowoscOrganizacji], [MiejscowoscZagrozona], [NazwaSluzby]) VALUES (N'Powodziowe', N'Żywiec', N'Żywiec', N'Łękawica', N'Szpital')
INSERT [dane].[OstrzeganieInstytucji] ([StanZagrozenia], [MiastoOrganizacji], [MiejscowoscOrganizacji], [MiejscowoscZagrozona], [NazwaSluzby]) VALUES (N'Powodziowe', N'Żywiec', N'Żywiec', N'Łękawica', N'StrażPożarna')
GO
INSERT [dane].[PomiarRzeki] ([PoziomWody], [StandardowyPoziom], [NazwaRzeki]) VALUES (3, 2, N'Jelesianka')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [StandardowyPoziom], [NazwaRzeki]) VALUES (4, 3.4, N'Kocierzanka')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [StandardowyPoziom], [NazwaRzeki]) VALUES (3.4, 3.4, N'''Kocierzanka''')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [StandardowyPoziom], [NazwaRzeki]) VALUES (2, 2, N'Koszarawa')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [StandardowyPoziom], [NazwaRzeki]) VALUES (2.5, 2, N'Sopotnia Wielka')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [StandardowyPoziom], [NazwaRzeki]) VALUES (5.5, 3, N'Wisla')
GO
INSERT [dane].[PowiadomienieSMS] ([NumerTelefonu], [StanZagrozenia], [Miasto], [Miejscowosc]) VALUES (N'512516223', N'Powodziowe', N'Zywiec', N'Jelesnia')
INSERT [dane].[PowiadomienieSMS] ([NumerTelefonu], [StanZagrozenia], [Miasto], [Miejscowosc]) VALUES (N'735-225-333', N'Powodziowe', N'Żywiec', N'Łękawica')
INSERT [dane].[PowiadomienieSMS] ([NumerTelefonu], [StanZagrozenia], [Miasto], [Miejscowosc]) VALUES (N'737586223', N'Powodziowe', N'Zywiec', N'Jelesnia')
GO
INSERT [dane].[PowodzieHistoryczne] ([Miasto], [Miejscowosc]) VALUES (N'Żywiec', N'Jelesnia')
INSERT [dane].[PowodzieHistoryczne] ([Miasto], [Miejscowosc]) VALUES (N'Żywiec', N'Żywiec')
GO
INSERT [dane].[PrognozaPogody] ([Miasto], [Deszcz], [IloscOpadow]) VALUES (N'Żywiec', 1, 150)
GO
INSERT [dane].[RodzajSłużbyRatunkowej] ([Miejscowość], [Pog_ratunkowe], [Straż_pożarna], [Policja]) VALUES (N'Łękawica', 1, 1, 1)
GO
ALTER TABLE [dane].[DataPomiaru]  WITH CHECK ADD  CONSTRAINT [NazwaRzekiPomiaru] FOREIGN KEY([NazwaRzeki])
REFERENCES [dane].[PomiarRzeki] ([NazwaRzeki])
GO
ALTER TABLE [dane].[DataPomiaru] CHECK CONSTRAINT [NazwaRzekiPomiaru]
GO
ALTER TABLE [dane].[DataPomiaruZStacji]  WITH CHECK ADD  CONSTRAINT [id_stacji] FOREIGN KEY([id_stacji])
REFERENCES [dane].[IMGWDaneSynoptyczne] ([id_stacji])
GO
ALTER TABLE [dane].[DataPomiaruZStacji] CHECK CONSTRAINT [id_stacji]
GO
ALTER TABLE [dane].[DataPowodziHis]  WITH CHECK ADD  CONSTRAINT [Miejscowość] FOREIGN KEY([Miejscowość])
REFERENCES [dane].[PowodzieHistoryczne] ([Miejscowosc])
GO
ALTER TABLE [dane].[DataPowodziHis] CHECK CONSTRAINT [Miejscowość]
GO
ALTER TABLE [dane].[DataPrognozy]  WITH CHECK ADD  CONSTRAINT [Miasto] FOREIGN KEY([Miasto])
REFERENCES [dane].[PrognozaPogody] ([Miasto])
GO
ALTER TABLE [dane].[DataPrognozy] CHECK CONSTRAINT [Miasto]
GO
ALTER TABLE [dane].[ObszarZagrozony]  WITH CHECK ADD  CONSTRAINT [NazwaRzeki] FOREIGN KEY([NazwaRzeki])
REFERENCES [dane].[PomiarRzeki] ([NazwaRzeki])
GO
ALTER TABLE [dane].[ObszarZagrozony] CHECK CONSTRAINT [NazwaRzeki]
GO
ALTER TABLE [dane].[OstrzeganieInstytucji]  WITH CHECK ADD  CONSTRAINT [Miejscowosc] FOREIGN KEY([MiejscowoscZagrozona])
REFERENCES [dane].[ObszarZagrozony] ([Miejscowosc])
GO
ALTER TABLE [dane].[OstrzeganieInstytucji] CHECK CONSTRAINT [Miejscowosc]
GO
ALTER TABLE [dane].[PowiadomienieSMS]  WITH CHECK ADD  CONSTRAINT [Miejscowosc2] FOREIGN KEY([Miejscowosc])
REFERENCES [dane].[ObszarZagrozony] ([Miejscowosc])
GO
ALTER TABLE [dane].[PowiadomienieSMS] CHECK CONSTRAINT [Miejscowosc2]
GO
ALTER TABLE [dane].[RodzajSłużbyRatunkowej]  WITH CHECK ADD  CONSTRAINT [Miejscowosce] FOREIGN KEY([Miejscowość])
REFERENCES [dane].[ObszarZagrozony] ([Miejscowosc])
GO
ALTER TABLE [dane].[RodzajSłużbyRatunkowej] CHECK CONSTRAINT [Miejscowosce]
GO
ALTER TABLE [dane].[DataPomiaru]  WITH CHECK ADD CHECK  ((NOT [Data] like '0000-00-0'))
GO
ALTER TABLE [dane].[DataPomiaruZStacji]  WITH CHECK ADD CHECK  (([id_stacji]>(0)))
GO
ALTER TABLE [dane].[DataPowodziHis]  WITH CHECK ADD CHECK  ((NOT [DataPowodzi] like '0000-00-0'))
GO
ALTER TABLE [dane].[DataPrognozy]  WITH CHECK ADD CHECK  ((NOT [Data] like '0000-00-0'))
GO
ALTER TABLE [dane].[IMGWDaneSynoptyczne]  WITH CHECK ADD CHECK  (([id_stacji]>(0)))
GO
ALTER TABLE [dane].[PrognozaPogody]  WITH CHECK ADD CHECK  (([IloscOpadow]>=(0)))
GO
USE [master]
GO
ALTER DATABASE [MBazaPop] SET  READ_WRITE 
GO
