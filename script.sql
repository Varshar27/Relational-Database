USE [master]
GO
/****** Object:  Database [DGrooming ]    Script Date: 4/25/2019 8:46:02 AM ******/
CREATE DATABASE [DGrooming ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DGrooming', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DGrooming .mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DGrooming _log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DGrooming _log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DGrooming ] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DGrooming ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DGrooming ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DGrooming ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DGrooming ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DGrooming ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DGrooming ] SET ARITHABORT OFF 
GO
ALTER DATABASE [DGrooming ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DGrooming ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DGrooming ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DGrooming ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DGrooming ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DGrooming ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DGrooming ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DGrooming ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DGrooming ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DGrooming ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DGrooming ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DGrooming ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DGrooming ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DGrooming ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DGrooming ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DGrooming ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DGrooming ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DGrooming ] SET RECOVERY FULL 
GO
ALTER DATABASE [DGrooming ] SET  MULTI_USER 
GO
ALTER DATABASE [DGrooming ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DGrooming ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DGrooming ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DGrooming ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DGrooming ] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DGrooming ', N'ON'
GO
ALTER DATABASE [DGrooming ] SET QUERY_STORE = OFF
GO
USE [DGrooming ]
GO
/****** Object:  Table [dbo].[tbl_Dog]    Script Date: 4/25/2019 8:46:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Dog](
	[DogID] [varchar](50) NOT NULL,
	[OwnerID] [varchar](50) NULL,
	[Dogname] [varchar](100) NOT NULL,
	[Gender] [varchar](150) NOT NULL,
	[Breed] [varchar](250) NOT NULL,
	[DOB] [date] NOT NULL,
	[Age] [varchar](50) NOT NULL,
	[Matted_dog] [varchar](25) NOT NULL,
 CONSTRAINT [Dog_ID_pk] PRIMARY KEY CLUSTERED 
(
	[DogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Appointment]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Appointment](
	[AppointmentID] [varchar](50) NOT NULL,
	[AppointmentDate] [date] NULL,
	[AppointmentTime] [time](7) NULL,
	[DogID] [varchar](50) NULL,
	[Cancelled] [varchar](50) NULL,
	[Cancelled_Reason] [varchar](255) NULL,
 CONSTRAINT [Appointment_ID_pk] PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Appointmentdetails]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[Appointmentdetails]

as
select 

Appointmentdate,AppointmentTime,Dogname
from tbl_Dog D left join  tbl_Appointment A
on
D.DogID = A.DogID 
GO
/****** Object:  Table [dbo].[tbl_GroomingServices]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GroomingServices](
	[ServiceID] [varchar](50) NOT NULL,
	[ServiceName] [varchar](255) NOT NULL,
	[ServiceDuration] [varchar](50) NOT NULL,
	[ServicePrice] [real] NOT NULL,
 CONSTRAINT [Service_ID] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employee](
	[EmployeeID] [varchar](50) NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](45) NOT NULL,
 CONSTRAINT [Employee_ID_PK] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ServiceRendered]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ServiceRendered](
	[AppointmentID] [varchar](50) NOT NULL,
	[LineItemNumber] [int] NOT NULL,
	[ServiceID] [varchar](50) NOT NULL,
	[ServiceExtendedPrice] [real] NOT NULL,
	[EmployeeID] [varchar](50) NULL,
 CONSTRAINT [LineItemNumber_pk] PRIMARY KEY CLUSTERED 
(
	[LineItemNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Employeeservices]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Employeeservices]

as
select 

Firstname E, ServiceExtendedprice S ,ServiceName G 
from [dbo].[tbl_Employee] E left join [dbo].[tbl_ServiceRendered] S
On E.EmployeeID = S.EmployeeID  
Left join [dbo].[tbl_GroomingServices] G on G.ServiceID=S.ServiceID
GO
/****** Object:  Table [dbo].[Add_Employee]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Add_Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Data] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Owner]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Owner](
	[OwnerID] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email_Address] [varchar](50) NOT NULL,
	[Phone_Number] [int] NOT NULL,
	[Address] [varchar](100) NULL,
	[Owner_Reviews] [xml] NULL,
 CONSTRAINT [Owner_ID_pk] PRIMARY KEY CLUSTERED 
(
	[OwnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Phone_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Appointment]  WITH CHECK ADD FOREIGN KEY([DogID])
REFERENCES [dbo].[tbl_Dog] ([DogID])
GO
ALTER TABLE [dbo].[tbl_Dog]  WITH CHECK ADD FOREIGN KEY([OwnerID])
REFERENCES [dbo].[tbl_Owner] ([OwnerID])
GO
ALTER TABLE [dbo].[tbl_ServiceRendered]  WITH CHECK ADD FOREIGN KEY([AppointmentID])
REFERENCES [dbo].[tbl_Appointment] ([AppointmentID])
GO
ALTER TABLE [dbo].[tbl_ServiceRendered]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tbl_Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[tbl_ServiceRendered]  WITH CHECK ADD  CONSTRAINT [fk_ServiceID] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[tbl_GroomingServices] ([ServiceID])
GO
ALTER TABLE [dbo].[tbl_ServiceRendered] CHECK CONSTRAINT [fk_ServiceID]
GO
/****** Object:  StoredProcedure [dbo].[changeOwnerphonenumber]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[changeOwnerphonenumber]

@Phone_Number int 

AS

UPDATE  [dbo].[tbl_Owner] 
SET Phone_Number =@Phone_Number
WHERE Phone_Number=35389758 
GO
/****** Object:  StoredProcedure [dbo].[countdogsbyGender]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[countdogsbyGender] @gender varchar(150)
AS
BEGIN
SELECT Gender,COUNT(*) as [number of male/female]
from [dbo].[tbl_Dog]
WHERE Gender=@gender
GROUP BY Gender
END
GO
/****** Object:  StoredProcedure [dbo].[DogServicetable]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[DogServicetable] AS

SELECT O.Firstname+' '+O.lastname as Ownername,D.Dogname,A.AppointmentTime,A.Appointmentdate,A.Cancelled,A.Cancelled_Reason,S.serviceExtendedprice,
E.Firstname+' '+E.lastname as Employeename,G.servicename
FROM  tbl_Owner O with (nolock)
left JOIN tbl_Dog D  (NOLOCK) ON O.OwnerID = D.OwnerID
left Join tbl_Appointment A  on D.DogID = A.DogID
left   Join tbl_Servicerendered s on A.AppointmentID = S.AppointmentID
left Join tbl_Employee E on S.EmployeeID = E.employeeID
Left Join tbl_groomingServices G On G.serviceID = S.ServiceID

GO
/****** Object:  StoredProcedure [dbo].[getDOGandOWNERDetails]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[getDOGandOWNERDetails]

As

Begin

Select  O.OwnerID,O.FirstName,O.LastName,D.DogID,D.Dogname,O.Owner_Reviews from  [dbo].[tbl_Owner] O Inner Join  [dbo].[tbl_Dog] D on O.OWNERID=D.OWNERID

END
GO
/****** Object:  StoredProcedure [dbo].[Groupby]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Groupby]
AS
BEGIN
SELECT  AppointmentDate A, 
         SUM(ServiceExtendedPrice) AS TotalSpent
FROM  tbl_Appointment A , tbl_ServiceRendered S
WHERE    A.AppointmentID = S.AppointmentID
GROUP BY A.AppointmentDate
END
GO
/****** Object:  StoredProcedure [dbo].[GroupbyHaving]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GroupbyHaving]
AS
BEGIN
SELECT Appointmentdate,COUNT(AppointmentID) As Number_of_Appointments
FROM tbl_Appointment
GROUP BY AppointmentDate
HAVING COUNT(AppointmentID) >1
END
GO
/****** Object:  StoredProcedure [dbo].[Matteddogs]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Matteddogs]

 @Matted_dog varchar(25)

AS
SELECT * FROM tbl_Dog WHERE Matted_dog = @Matted_dog;
GO
/****** Object:  StoredProcedure [dbo].[TotalAmount]    Script Date: 4/25/2019 8:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TotalAmount]

AS

BEGIN 

     SET NOCOUNT ON 

    select sum(ServiceExtendedPrice)as Servicetotalamount from [dbo].[tbl_ServiceRendered]

END 

GO
USE [master]
GO
ALTER DATABASE [DGrooming ] SET  READ_WRITE 
GO
