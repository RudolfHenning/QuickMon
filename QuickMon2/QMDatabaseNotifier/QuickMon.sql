USE [QuickMon]
GO
/****** Object:  Table [dbo].[States]    Script Date: 08/15/2011 10:52:48 ******/
CREATE TABLE [dbo].[States](
	[StateId] [tinyint] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlertLevels]    Script Date: 08/15/2011 10:52:48 ******/
CREATE TABLE [dbo].[AlertLevels](
	[AlertLevel] [tinyint] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AlertLevels] PRIMARY KEY CLUSTERED 
(
	[AlertLevel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollectorTypes]    Script Date: 08/15/2011 10:52:48 ******/
CREATE TABLE [dbo].[CollectorTypes](
	[CollectorTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CollectorType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_CollectorTypes] PRIMARY KEY CLUSTERED 
(
	[CollectorTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 08/15/2011 10:52:48 ******/
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlertMessages]    Script Date: 08/15/2011 10:52:48 ******/
CREATE TABLE [dbo].[AlertMessages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[AlertLevel] [tinyint] NOT NULL,
	[CollectorTypeId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PreviousState] [tinyint] NOT NULL,
	[CurrentState] [tinyint] NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AlertMessages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertMessage]    Script Date: 08/15/2011 10:52:49 ******/
CREATE PROCEDURE [dbo].[InsertMessage]
(
	@AlertLevel tinyint,
	@CollectorType nvarchar(255) = 'N/A',
	@Category nvarchar(255),
	@PreviousState tinyint,
	@CurrentState tinyint,
	@Details nvarchar(MAX)
)
AS
BEGIN
  declare @CategoryId int
  declare @CollectorTypeId int
  
  if (@CollectorType is null)
	set @CollectorType = 'N/A'
  SELECT @CollectorTypeId = CollectorTypeId FROM CollectorTypes WHERE CollectorType = @CollectorType
  IF (@CollectorTypeId is null)
  begin
	Insert CollectorTypes(CollectorType) VALUES(@CollectorType)
	SELECT @CollectorTypeId = CollectorTypeId FROM CollectorTypes WHERE CollectorType = @CollectorType
  end
  
  if (@Category is null)
	set @Category = 'None'
  Select @CategoryId = CategoryId from Categories where Category = @Category
  if (@CategoryId is null)
  begin
	 Insert Categories(Category) values (@Category)
	 Select @CategoryId = CategoryId from Categories where Category = @Category
  end  
  
  INSERT AlertMessages(AlertLevel, CollectorTypeId, CategoryId, PreviousState, CurrentState , Details)
  Values (@AlertLevel, @CollectorTypeId, @CategoryId, @PreviousState, @CurrentState , @Details)
END
GO
/****** Object:  View [dbo].[vAlertMessages]    Script Date: 08/15/2011 10:52:48 ******/
CREATE VIEW [dbo].[vAlertMessages]
AS
SELECT     dbo.AlertMessages.MessageId, dbo.AlertLevels.Description AS AlertLevel, dbo.Categories.Category, dbo.States.Description AS PreviousState, 
					  States_1.Description AS CurrentState, dbo.AlertMessages.Details, dbo.AlertMessages.InsertDate, dbo.Categories.CategoryId, 
					  dbo.AlertLevels.AlertLevel AS AlertLevelId, States_1.StateId, dbo.CollectorTypes.CollectorType
FROM         dbo.AlertMessages INNER JOIN
					  dbo.Categories ON dbo.AlertMessages.CategoryId = dbo.Categories.CategoryId INNER JOIN
					  dbo.AlertLevels ON dbo.AlertMessages.AlertLevel = dbo.AlertLevels.AlertLevel INNER JOIN
					  dbo.States ON dbo.AlertMessages.PreviousState = dbo.States.StateId INNER JOIN
					  dbo.States AS States_1 ON dbo.AlertMessages.CurrentState = States_1.StateId INNER JOIN
					  dbo.CollectorTypes ON dbo.AlertMessages.CollectorTypeId = dbo.CollectorTypes.CollectorTypeId
GO
/****** Object:  StoredProcedure [dbo].[QueryMessages]    Script Date: 08/15/2011 10:52:49 ******/
CREATE proc [dbo].[QueryMessages]
(
	@top int,
	@FromDate datetime, 
	@ToDate datetime,
	@AlertLevel tinyint, 
	@CollectorType nvarchar(255) = null,
	@Category nvarchar(255),
	@CurrentState tinyint,
	@Details nvarchar(255)
)
as
  SELECT top(@top) 
	[InsertDate],
	[AlertLevel],
	[CollectorType],
	[Category],
	[PreviousState],
	[CurrentState],
	[Details]
  FROM
	[vAlertMessages]
  WHERE 
	[InsertDate] between @FromDate and @ToDate and
	(@AlertLevel is null or AlertLevelId >= @AlertLevel) and
	(@CollectorType is null or CollectorType like @CollectorType) and
	(@Category is null or Category like @Category) and
	(@CurrentState is null or StateId = @CurrentState) and
	(@Details is null or [Details] like @Details)
  ORDER BY
	[InsertDate] desc
GO
/****** Object:  Default [DF_AlertMessages_AlertLevel]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages] ADD  CONSTRAINT [DF_AlertMessages_AlertLevel]  DEFAULT ((0)) FOR [AlertLevel]
GO
/****** Object:  Default [DF_AlertMessages_PreviousState]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages] ADD  CONSTRAINT [DF_AlertMessages_PreviousState]  DEFAULT ((0)) FOR [PreviousState]
GO
/****** Object:  Default [DF_AlertMessages_CurrentState]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages] ADD  CONSTRAINT [DF_AlertMessages_CurrentState]  DEFAULT ((0)) FOR [CurrentState]
GO
/****** Object:  Default [DF_AlertMessages_InsertDate]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages] ADD  CONSTRAINT [DF_AlertMessages_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO
/****** Object:  ForeignKey [FK_AlertMessages_AlertLevels]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages]  WITH CHECK ADD  CONSTRAINT [FK_AlertMessages_AlertLevels] FOREIGN KEY([AlertLevel])
REFERENCES [dbo].[AlertLevels] ([AlertLevel])
GO
ALTER TABLE [dbo].[AlertMessages] CHECK CONSTRAINT [FK_AlertMessages_AlertLevels]
GO
/****** Object:  ForeignKey [FK_AlertMessages_Categories]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages]  WITH CHECK ADD  CONSTRAINT [FK_AlertMessages_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[AlertMessages] CHECK CONSTRAINT [FK_AlertMessages_Categories]
GO
/****** Object:  ForeignKey [FK_AlertMessages_CollectorTypes]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages]  WITH CHECK ADD  CONSTRAINT [FK_AlertMessages_CollectorTypes] FOREIGN KEY([CollectorTypeId])
REFERENCES [dbo].[CollectorTypes] ([CollectorTypeId])
GO
ALTER TABLE [dbo].[AlertMessages] CHECK CONSTRAINT [FK_AlertMessages_CollectorTypes]
GO
/****** Object:  ForeignKey [FK_AlertMessages_CurrentState]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages]  WITH CHECK ADD  CONSTRAINT [FK_AlertMessages_CurrentState] FOREIGN KEY([CurrentState])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[AlertMessages] CHECK CONSTRAINT [FK_AlertMessages_CurrentState]
GO
/****** Object:  ForeignKey [FK_AlertMessages_PreviousState]    Script Date: 08/15/2011 10:52:48 ******/
ALTER TABLE [dbo].[AlertMessages]  WITH CHECK ADD  CONSTRAINT [FK_AlertMessages_PreviousState] FOREIGN KEY([PreviousState])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[AlertMessages] CHECK CONSTRAINT [FK_AlertMessages_PreviousState]
GO
/****** Object:  Table [dbo].[States]    Script Date: 08/15/2011 11:03:00 ******/
INSERT [dbo].[States] ([StateId], [Description]) VALUES (0, N'Not Available')
INSERT [dbo].[States] ([StateId], [Description]) VALUES (1, N'Good')
INSERT [dbo].[States] ([StateId], [Description]) VALUES (2, N'Warning')
INSERT [dbo].[States] ([StateId], [Description]) VALUES (3, N'Error')
INSERT [dbo].[States] ([StateId], [Description]) VALUES (4, N'Disabled')
INSERT [dbo].[States] ([StateId], [Description]) VALUES (5, N'Configuration Error')
/****** Object:  Table [dbo].[CollectorTypes]    Script Date: 08/15/2011 11:03:00 ******/
SET IDENTITY_INSERT [dbo].[CollectorTypes] ON
INSERT [dbo].[CollectorTypes] ([CollectorTypeId], [CollectorType]) VALUES (1, N'N/A')
SET IDENTITY_INSERT [dbo].[CollectorTypes] OFF
/****** Object:  Table [dbo].[Categories]    Script Date: 08/15/2011 11:03:00 ******/
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([CategoryId], [Category]) VALUES (1, N'None')
SET IDENTITY_INSERT [dbo].[Categories] OFF
/****** Object:  Table [dbo].[AlertLevels]    Script Date: 08/15/2011 11:03:00 ******/
INSERT [dbo].[AlertLevels] ([AlertLevel], [Description]) VALUES (0, N'Debug')
INSERT [dbo].[AlertLevels] ([AlertLevel], [Description]) VALUES (1, N'Information')
INSERT [dbo].[AlertLevels] ([AlertLevel], [Description]) VALUES (2, N'Warning')
INSERT [dbo].[AlertLevels] ([AlertLevel], [Description]) VALUES (3, N'Error')
INSERT [dbo].[AlertLevels] ([AlertLevel], [Description]) VALUES (4, N'Crisis')

grant execute on dbo.QueryMessages to public
GO
grant execute on dbo.InsertMessage to public
GO