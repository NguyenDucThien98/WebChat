USE [WebChat2]
GO
/****** Object:  Table [dbo].[app_user]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[app_user](
	[app_user_id] [uniqueidentifier] NOT NULL,
	[username] [varchar](150) NOT NULL,
	[encrypted_password] [varchar](150) NOT NULL,
 CONSTRAINT [PK__app_user__06D526147F60ED59] PRIMARY KEY CLUSTERED 
(
	[app_user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ__app_user__F3DBC572023D5A04] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'683e0ef7-1560-434a-b512-0c0b548637c2', N'thiennd4', N'$2a$10$9dciT42Nvt6NiIl9HSgIzuycMaMbgVP8YRgu5GYl4suOu3lotZmVu')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'c93ac409-5d7d-4ed9-8aeb-0deecb58512f', N'thiennd5', N'$2a$10$FEjsfSXqcWbwuy1WZSpKS.xfVPQhHiID1dw7mYAA22L4LhAamoKLC')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'dc8d57df-5473-47aa-8824-1812bfa52721', N'thiennd', N'$2a$10$2/0fLBfh3DheRfXbyQyuG.SC3QcT.WXj5k/gHT5bi6GFpOJgU7weO')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'079882af-84d6-40c0-b707-21acc8417eb7', N'thiennd7', N'$2a$10$zzfCH8DIuf3HEKNKWRz0detQ3BRrubVCAqQKrajUjjFpgsJrL5Coq')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'979f29a1-3d6c-4442-b4e2-2914adc5939a', N'thiennd8', N'$2a$10$hBh7vhLI1llMcGZXrH2bl.M7vkf/5nisywsfMdpn5otG3YD779bD6')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'6399cd0c-9625-4f4a-88b0-5461ba4c9f3e', N'thiennd2', N'$2a$10$A8xJZbbyCE7Du70MrSWwZumhMidpQ.uAZSpGIANQ3MQ72EyXIWgRK')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'fe09468e-69b9-49a6-b76d-8a53b4621449', N'thiennd6', N'$2a$10$4akcBcGnZK2btXRzdDJKPOqUkXUxgC3CyfIfJ2J7/l/rd4gpaevfa')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'234ed690-5bf5-460a-a3ce-8e05c5af48b5', N'thiennd9', N'$2a$10$oyfqOjlK8wGt0DRP166GBeLGsO1zpYAwuZ47teJD60l8EChU.4.e2')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'74d61b1c-cc58-4076-9157-b4f5f2fbcede', N'thiennd10', N'$2a$10$Vn0RqZOrKvmtQtTamd7dPug1OtW1T5SAQCwCYyXMk6P973NcAXz6q')
INSERT [dbo].[app_user] ([app_user_id], [username], [encrypted_password]) VALUES (N'de4ef41b-48fb-47d8-95b7-fcb590386a01', N'thiennd3', N'$2a$10$t63kJeIdc5CZ.vLWW31Li.wA9Pw.GdzZJikaVCo6gCcNxOdTtzJUC')
/****** Object:  Table [dbo].[app_role]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[app_role](
	[role_id] [bigint] NOT NULL,
	[role_name] [varchar](30) NOT NULL,
 CONSTRAINT [PK__app_role__760965CC060DEAE8] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ__app_role__783254B108EA5793] UNIQUE NONCLUSTERED 
(
	[role_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[app_role] ([role_id], [role_name]) VALUES (1, N'admin')
INSERT [dbo].[app_role] ([role_id], [role_name]) VALUES (2, N'custommer')
/****** Object:  Table [dbo].[customer]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[customer](
	[app_user_id] [uniqueidentifier] NOT NULL,
	[avatar] [varchar](max) NULL,
	[fullname] [nvarchar](200) NOT NULL,
	[status_online] [bit] NOT NULL,
	[last_online] [datetimeoffset](7) NOT NULL,
	[email] [varchar](254) NOT NULL,
	[phone] [varchar](10) NULL,
	[gender] [bit] NOT NULL,
	[birth] [date] NOT NULL,
	[city] [nvarchar](200) NULL,
	[customer_description] [nvarchar](max) NULL,
	[last_change_password] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK__customer__06D526140CBAE877] PRIMARY KEY CLUSTERED 
(
	[app_user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'683e0ef7-1560-434a-b512-0c0b548637c2', N'defaultavt.jpg', N'thiennd4', 0, CAST(0x07D904F43DA46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x07D904F43DA46C3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'c93ac409-5d7d-4ed9-8aeb-0deecb58512f', N'defaultavt.jpg', N'thiennd3', 0, CAST(0x0762701642A46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x0762701642A46C3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'dc8d57df-5473-47aa-8824-1812bfa52721', N'defaultavt.jpg', N'thiennd', 1, CAST(0x07AE4A2D62776B3F0BA401 AS DateTimeOffset), N'thienndse05883@fpt.edu.vn', NULL, 1, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x0700000000000000000000 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'079882af-84d6-40c0-b707-21acc8417eb7', N'defaultavt.jpg', N'thiennd5', 0, CAST(0x07463EC04BA46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x07463EC04BA46C3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'979f29a1-3d6c-4442-b4e2-2914adc5939a', N'defaultavt.jpg', N'thiennd8', 0, CAST(0x07284C5151A46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x07284C5151A46C3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'6399cd0c-9625-4f4a-88b0-5461ba4c9f3e', N'defaultavt.jpg', N'thiennd2', 1, CAST(0x07FF417859816B3F0BA401 AS DateTimeOffset), N'thiennd2@ssd', NULL, 1, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x07FF417859816B3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'fe09468e-69b9-49a6-b76d-8a53b4621449', N'defaultavt.jpg', N'thiennd6', 0, CAST(0x0700025E46A46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x0700025E46A46C3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'234ed690-5bf5-460a-a3ce-8e05c5af48b5', N'defaultavt.jpg', N'thiennd8', 0, CAST(0x07F17B9157A46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x07F17B9157A46C3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'74d61b1c-cc58-4076-9157-b4f5f2fbcede', N'defaultavt.jpg', N'thiennd10', 0, CAST(0x075965C95CA46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x075965C95CA46C3F0BA401 AS DateTimeOffset))
INSERT [dbo].[customer] ([app_user_id], [avatar], [fullname], [status_online], [last_online], [email], [phone], [gender], [birth], [city], [customer_description], [last_change_password]) VALUES (N'de4ef41b-48fb-47d8-95b7-fcb590386a01', N'defaultavt.jpg', N'thiennd7', 0, CAST(0x07D6693D37A46C3F0BA401 AS DateTimeOffset), N'thiennd3@gmail', NULL, 0, CAST(0xAE210B00 AS Date), NULL, NULL, CAST(0x07D6693D37A46C3F0BA401 AS DateTimeOffset))
/****** Object:  Table [dbo].[user_role]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_role](
	[app_user_id] [uniqueidentifier] NOT NULL,
	[role_id] [bigint] NOT NULL,
 CONSTRAINT [PK__user_rol__D1B5B048108B795B] PRIMARY KEY CLUSTERED 
(
	[app_user_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[user_role] ([app_user_id], [role_id]) VALUES (N'dc8d57df-5473-47aa-8824-1812bfa52721', 1)
/****** Object:  Table [dbo].[message]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[message](
	[message_id] [uniqueidentifier] NOT NULL,
	[user_1] [uniqueidentifier] NULL,
	[user_2] [uniqueidentifier] NULL,
 CONSTRAINT [PK_message] PRIMARY KEY CLUSTERED 
(
	[message_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[message] ([message_id], [user_1], [user_2]) VALUES (N'2fa91157-f077-4100-b97e-00115c351b24', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'6399cd0c-9625-4f4a-88b0-5461ba4c9f3e')
INSERT [dbo].[message] ([message_id], [user_1], [user_2]) VALUES (N'7a23f546-0117-4fbd-8fdb-001786daf0ab', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'683e0ef7-1560-434a-b512-0c0b548637c2')
INSERT [dbo].[message] ([message_id], [user_1], [user_2]) VALUES (N'78294107-ed72-473d-93e6-00501977bc2d', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'74d61b1c-cc58-4076-9157-b4f5f2fbcede')
INSERT [dbo].[message] ([message_id], [user_1], [user_2]) VALUES (N'cea6e70c-266f-4459-8ec6-010d1ffc62b4', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'fe09468e-69b9-49a6-b76d-8a53b4621449')
/****** Object:  Table [dbo].[relationship]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[relationship](
	[cus1_id] [uniqueidentifier] NOT NULL,
	[cus2_id] [uniqueidentifier] NOT NULL,
	[relationship_status] [int] NOT NULL,
 CONSTRAINT [UQ__relation__71B2D9B0173876EA] UNIQUE NONCLUSTERED 
(
	[cus1_id] ASC,
	[cus2_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notify]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notify](
	[notify_id] [uniqueidentifier] NOT NULL,
	[cus_id] [uniqueidentifier] NOT NULL,
	[date_create] [datetimeoffset](7) NOT NULL,
	[notify_content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__notify__DD351C961B0907CE] PRIMARY KEY CLUSTERED 
(
	[notify_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[message_info]    Script Date: 03/16/2019 06:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[message_info](
	[message_id] [uniqueidentifier] NOT NULL,
	[cus_send_id] [uniqueidentifier] NOT NULL,
	[cus_receive_id] [uniqueidentifier] NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[send_time] [datetimeoffset](7) NOT NULL,
	[message_status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[message_info] ([message_id], [cus_send_id], [cus_receive_id], [message], [send_time], [message_status]) VALUES (N'2fa91157-f077-4100-b97e-00115c351b24', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'6399cd0c-9625-4f4a-88b0-5461ba4c9f3e', N'haha', CAST(0x0780114CB35F2E3F0B0000 AS DateTimeOffset), 1)
INSERT [dbo].[message_info] ([message_id], [cus_send_id], [cus_receive_id], [message], [send_time], [message_status]) VALUES (N'7a23f546-0117-4fbd-8fdb-001786daf0ab', N'683e0ef7-1560-434a-b512-0c0b548637c2', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'bhihi', CAST(0x070006CCC12A723E0B0000 AS DateTimeOffset), 1)
INSERT [dbo].[message_info] ([message_id], [cus_send_id], [cus_receive_id], [message], [send_time], [message_status]) VALUES (N'2fa91157-f077-4100-b97e-00115c351b24', N'6399cd0c-9625-4f4a-88b0-5461ba4c9f3e', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'lala', CAST(0x0780CE4C2A8F5A3E0B0000 AS DateTimeOffset), 1)
INSERT [dbo].[message_info] ([message_id], [cus_send_id], [cus_receive_id], [message], [send_time], [message_status]) VALUES (N'78294107-ed72-473d-93e6-00501977bc2d', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'74d61b1c-cc58-4076-9157-b4f5f2fbcede', N'jisdjsds', CAST(0x070014F68416083F0B0000 AS DateTimeOffset), 1)
INSERT [dbo].[message_info] ([message_id], [cus_send_id], [cus_receive_id], [message], [send_time], [message_status]) VALUES (N'cea6e70c-266f-4459-8ec6-010d1ffc62b4', N'dc8d57df-5473-47aa-8824-1812bfa52721', N'fe09468e-69b9-49a6-b76d-8a53b4621449', N'sdsđs', CAST(0x070000DE391A543F0B0000 AS DateTimeOffset), 1)
/****** Object:  Default [DF__app_user__app_us__20C1E124]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[app_user] ADD  CONSTRAINT [DF__app_user__app_us__20C1E124]  DEFAULT (newid()) FOR [app_user_id]
GO
/****** Object:  Default [DF__message__id__21B6055D]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[message_info] ADD  CONSTRAINT [DF__message__id__21B6055D]  DEFAULT (newid()) FOR [message_id]
GO
/****** Object:  Default [DF__notify__notify_i__22AA2996]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[notify] ADD  CONSTRAINT [DF__notify__notify_i__22AA2996]  DEFAULT (newid()) FOR [notify_id]
GO
/****** Object:  ForeignKey [FK__customer__app_us__24927208]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[customer]  WITH CHECK ADD  CONSTRAINT [FK__customer__app_us__24927208] FOREIGN KEY([app_user_id])
REFERENCES [dbo].[app_user] ([app_user_id])
GO
ALTER TABLE [dbo].[customer] CHECK CONSTRAINT [FK__customer__app_us__24927208]
GO
/****** Object:  ForeignKey [FK_message_customer]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[message]  WITH CHECK ADD  CONSTRAINT [FK_message_customer] FOREIGN KEY([user_1])
REFERENCES [dbo].[customer] ([app_user_id])
GO
ALTER TABLE [dbo].[message] CHECK CONSTRAINT [FK_message_customer]
GO
/****** Object:  ForeignKey [FK_message_customer1]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[message]  WITH CHECK ADD  CONSTRAINT [FK_message_customer1] FOREIGN KEY([user_2])
REFERENCES [dbo].[customer] ([app_user_id])
GO
ALTER TABLE [dbo].[message] CHECK CONSTRAINT [FK_message_customer1]
GO
/****** Object:  ForeignKey [FK_message_info_message]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[message_info]  WITH CHECK ADD  CONSTRAINT [FK_message_info_message] FOREIGN KEY([message_id])
REFERENCES [dbo].[message] ([message_id])
GO
ALTER TABLE [dbo].[message_info] CHECK CONSTRAINT [FK_message_info_message]
GO
/****** Object:  ForeignKey [FK__notify__cus_id__276EDEB3]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[notify]  WITH CHECK ADD  CONSTRAINT [FK__notify__cus_id__276EDEB3] FOREIGN KEY([cus_id])
REFERENCES [dbo].[customer] ([app_user_id])
GO
ALTER TABLE [dbo].[notify] CHECK CONSTRAINT [FK__notify__cus_id__276EDEB3]
GO
/****** Object:  ForeignKey [FK_relationship_customer]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[relationship]  WITH CHECK ADD  CONSTRAINT [FK_relationship_customer] FOREIGN KEY([cus1_id])
REFERENCES [dbo].[customer] ([app_user_id])
GO
ALTER TABLE [dbo].[relationship] CHECK CONSTRAINT [FK_relationship_customer]
GO
/****** Object:  ForeignKey [FK_relationship_customer1]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[relationship]  WITH CHECK ADD  CONSTRAINT [FK_relationship_customer1] FOREIGN KEY([cus2_id])
REFERENCES [dbo].[customer] ([app_user_id])
GO
ALTER TABLE [dbo].[relationship] CHECK CONSTRAINT [FK_relationship_customer1]
GO
/****** Object:  ForeignKey [FK__user_role__app_u__2A4B4B5E]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FK__user_role__app_u__2A4B4B5E] FOREIGN KEY([app_user_id])
REFERENCES [dbo].[app_user] ([app_user_id])
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FK__user_role__app_u__2A4B4B5E]
GO
/****** Object:  ForeignKey [FK__user_role__role___2B3F6F97]    Script Date: 03/16/2019 06:35:10 ******/
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FK__user_role__role___2B3F6F97] FOREIGN KEY([role_id])
REFERENCES [dbo].[app_role] ([role_id])
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FK__user_role__role___2B3F6F97]
GO
