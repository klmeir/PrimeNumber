USE [PrimeNumber]
GO
/****** Object:  Table [dbo].[PrimeNumberRequestLog]    Script Date: 7/2/2024 2:00:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrimeNumberRequestLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Request] [varchar](max) NOT NULL,
	[DateRequest] [datetime] NOT NULL,
	[Response] [varchar](max) NOT NULL,
	[DateResponse] [datetime] NOT NULL,
	[User] [varchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PrimeNumberRequestLog] ON 
GO
INSERT [dbo].[PrimeNumberRequestLog] ([Id], [Request], [DateRequest], [Response], [DateResponse], [User]) VALUES (1, N'{"InitialNumber":5,"PrimeNumbers":10,"User":"Carlos"}', CAST(N'2024-07-02T06:59:09.457' AS DateTime), N'{"PrimeNumbers":[5,7,11,13,17,19,23,29,31,37]}', CAST(N'2024-07-02T06:59:09.460' AS DateTime), N'Carlos')
GO
SET IDENTITY_INSERT [dbo].[PrimeNumberRequestLog] OFF
GO
