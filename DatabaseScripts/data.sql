SET IDENTITY_INSERT [dbo].[Employer] ON
INSERT INTO [dbo].[Employer] ([Id], [Name], [ContactNumber], [WebSite]) VALUES (1, N'ABC Tech holdings Pvt Ltd', N'02134567890', N'http://www.abctech.com')
INSERT INTO [dbo].[Employer] ([Id], [Name], [ContactNumber], [WebSite]) VALUES (2, N'IT World Pvt Ltd', N'0213456789', N'http://itworld.com')
INSERT INTO [dbo].[Employer] ([Id], [Name], [ContactNumber], [WebSite]) VALUES (3, N'Interlink Software Pvt Ltd', N'02134567899', N'http://interlink.com')
SET IDENTITY_INSERT [dbo].[Employer] OFF
SET IDENTITY_INSERT [dbo].[Candidate] ON
INSERT INTO [dbo].[Candidate] ([Id], [Name], [ContactNumber]) VALUES (1, N'John Davidson', N'02134567890')
INSERT INTO [dbo].[Candidate] ([Id], [Name], [ContactNumber]) VALUES (2, N'Mac Davis', N'02134567890')
INSERT INTO [dbo].[Candidate] ([Id], [Name], [ContactNumber]) VALUES (3, N'George Watson', N'021348999935')
SET IDENTITY_INSERT [dbo].[Candidate] OFF
SET IDENTITY_INSERT [dbo].[Advertisement] ON
INSERT INTO [dbo].[Advertisement] ([Id], [Title], [Description], [EmployerId], [SalaryInformation], [JobType]) VALUES (1, N'Senior Data Engineer', N'Full time Senior Data Engineer is wanted ', 1, N'90000 Per Annum', 1)
INSERT INTO [dbo].[Advertisement] ([Id], [Title], [Description], [EmployerId], [SalaryInformation], [JobType]) VALUES (2, N'Network Engineer', N'Full time Contract Senior Network Engineer  is wanted ', 3, N'95 per hour', 0)
SET IDENTITY_INSERT [dbo].[Advertisement] OFF
SET IDENTITY_INSERT [dbo].[Application] ON
INSERT INTO [dbo].[Application] ([Id], [AdvertisementId], [CandidateId]) VALUES (1, 1, 2)
INSERT INTO [dbo].[Application] ([Id], [AdvertisementId], [CandidateId]) VALUES (2, 2, 3)
SET IDENTITY_INSERT [dbo].[Application] OFF

