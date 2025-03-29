USE [SoundVaultDB]
GO

/****** Object:  Table [dbo].[Albums]    Script Date: 30/3/2025 00:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Albums](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NOT NULL,
	[gender_id] [int] NULL,
	[song_count] [int] NULL,
	[total_duration] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Genres] FOREIGN KEY([gender_id])
REFERENCES [dbo].[Genders] ([id])
GO

ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Genres]
GO

