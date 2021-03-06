USE [master]
GO
/****** Object:  Database [ShoppingCart]    Script Date: 12/28/2017 3:21:40 PM ******/
CREATE DATABASE [ShoppingCart]
 GO
USE [ShoppingCart]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 12/28/2017 3:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[RecordId] [bigint] IDENTITY(1,1) NOT NULL,
	[CartId] [nvarchar](500) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[DateCreated] [datetime] NULL,
	[Amount] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[RecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/28/2017 3:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderReference] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NULL,
	[Othername] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[AddressLine1] [nvarchar](50) NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[PaymentReference] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/28/2017 3:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderReference] [nvarchar](20) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/28/2017 3:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[PrpductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ProductImage] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PrpductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (4, N'HP Pavilion 15 Intel Core I5 2.3 GHz ', N'PAVILION 15 INTEL CORE I5 2.3 GHZ (12GB RAM, 1TB HDD) 15.6-INCH WINDOWS 10 TOUCHSCREEN LAPTOP+ 32GB FLASH', CAST(205000.00 AS Decimal(18, 2)), N'lap.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (5, N'
Franck Olivier Oud Touch EDP Perfume For Men - 100ml', N'Bunnie Hub 100ml Brown', CAST(13000.00 AS Decimal(18, 2)), N'oud.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (6, N'Tang Women Sexy African Print V-neck Dashiki Bodycon Stretch Club Dress', N'S:Length:78cm/ Shoulder:32cm/ Bust:85cm/ Waist:67cm/ Hip:92cm M:Length:80cm/ Shoulder:34cm/ Bust:90cm/ Waist:72cm/ Hip:97cm L:Length:82cm/ Shoulder:36cm/ Bust:95cm/ Waist:77cm/ Hip:102cm XL:Length:84cm/ Shoulder:38cm/ Bust:100cm/ ', CAST(4810.00 AS Decimal(18, 2)), N'wmc.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (7, N'Amani 3.1 Home Theatre System with Bluetooth - S7', N'Occupy your space with life and volume whether for indoor family entertainment or outdoor occasions with the Amani S3 Home Theatre System. Designed for optimum performance and long-term durability. This is how you get your groove on!', CAST(17500.00 AS Decimal(18, 2)), N'amani.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (8, N'Djack Bluetooth Home Theatre System - DJ-303', N'FM/USB/SD Iput/USB/SD/MMC/DVD/PC/MP3/Mobile Phone', CAST(17299.00 AS Decimal(18, 2)), N'djack.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (9, N'Quorion Point of Sale Electronic Cash Register-QMP2264', N'Do you have a grocery shop, pizzaria, bakery, cafe, restaurant or pastries shop. Then this is what you need to enter daily sales transactions, manage sales record, inventory processing', CAST(160000.00 AS Decimal(18, 2)), N'pos.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (12, N'Xprinter POS Barcode Label Printer', N'This POS barcode label printer is suitable for your barcode and labeling needs.

intergrate with your POS software or use as Stand alone to genertae and print barcodes and labels.', CAST(35000.00 AS Decimal(18, 2)), N'xprint.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (13, N'Skone Multifunctional Chronograph Watch', N'Skone is one of the leading Watch Manufacturers with large varieties of wristwatch to fit all occasions, designed and styled to fit all class of people. Skone is known for its focus on exclusive designs, originality, high quality, timeless style and most importantly, value for your money.
These Skone wristwatches will be perfect fashion wear for couples who value style and quality.', CAST(12000.00 AS Decimal(18, 2)), N'wat.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (14, N'Dry Iron - CEL-7210G', N'Steam Glide Sole Plate(Phillips''s Premium) -Easy gliding on all fabrics;easily removes creases', CAST(2600.00 AS Decimal(18, 2)), N'iron.jpg')
INSERT [dbo].[Product] ([PrpductId], [ProductName], [Description], [Price], [ProductImage]) VALUES (15, N'Apple Macbook Air - 8GB Ram - 128GB SSD - Core I5 - MQD32LL/A 2017 USA Model - 13.3 Inch', N'Apple Latest Mid 2017 MacBook Air model MQD32LL/A 13.3” laptop - the NEWEST MacBook Air Model from July 2017', CAST(383000.00 AS Decimal(18, 2)), N'mac.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
USE [master]
GO
ALTER DATABASE [ShoppingCart] SET  READ_WRITE 
GO
