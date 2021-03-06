
/****** Object:  Table [dbo].[Products]    Script Date: 06/08/2012 15:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AvailableDate] [datetime] NOT NULL,
	[Category] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__Products__Availa__014935CB]    Script Date: 06/08/2012 15:00:39 ******/
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [AvailableDate]
GO
