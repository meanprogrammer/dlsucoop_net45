GO
CREATE TABLE [dbo].[AccessTokens](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [nvarchar](50) NOT NULL,
	[AccessToken] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_AccessTokens] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdminAccount]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAccount](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[College]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[College](
	[CollegeID] [int] IDENTITY(1,1) NOT NULL,
	[CollegeName] [nvarchar](25) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[CollegeID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InboundSMS]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InboundSMS](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[MsgDateTime] [datetime] NULL,
	[DestinationAddress] [nvarchar](255) NULL,
	[MessageId] [nvarchar](255) NULL,
	[Message] [nvarchar](255) NULL,
	[ResourceURL] [nvarchar](255) NULL,
	[SenderAddress] [nvarchar](50) NULL,
	[Timestamp] [datetime] NULL,
	[IsRead] [bit] NULL,
 CONSTRAINT [PK_InboundSMS] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanAmountMatrix]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanAmountMatrix](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[LoanType] [int] NOT NULL,
	[LoanAmount] [float] NOT NULL,
	[RequiredShareCapital] [float] NOT NULL,
	[Interest] [float] NOT NULL,
	[MonthsPayable] [int] NOT NULL,
	[ProcessingFee] [float] NULL,
 CONSTRAINT [PK_LoanAmountMatrix] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanApplication]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanApplication](
	[TransactionID] [int] NOT NULL,
	[EmpNo] [nvarchar](10) NOT NULL,
	[CoMakerEmpNo] [nvarchar](10) NULL,
	[TypeOfLoan] [nvarchar](50) NOT NULL,
	[Reason] [text] NULL,
	[Amount] [money] NOT NULL,
	[NoOfMonths] [int] NOT NULL,
	[Confirmed] [bit] NULL,
	[DateApproved] [date] NULL,
	[DateDue] [date] NULL,
	[CoMaker2EmpNo] [nvarchar](10) NULL,
	[Done] [bit] NULL,
	[Declined] [bit] NULL,
	[Balance] [money] NULL,
 CONSTRAINT [PK_LoanApplication] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanTypes]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanTypes](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[LoanType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoanTypes] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MSGS]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MSGS](
	[ID] [nvarchar](50) NULL,
	[Source] [nvarchar](50) NULL,
	[Msg] [nvarchar](max) NULL,
	[UDH] [nvarchar](50) NULL,
	[DateReceived] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [int] NOT NULL,
	[PayAmount] [float] NOT NULL,
	[Note] [nvarchar](500) NULL,
	[PayDate] [datetime] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegDump]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegDump](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RegDump] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelativeEmployee]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelativeEmployee](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [nvarchar](50) NOT NULL,
	[RelativeEmpNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RelativeEmployee] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShareCapital]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShareCapital](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [nvarchar](50) NOT NULL,
	[ShareCapital] [float] NOT NULL,
 CONSTRAINT [PK_ShareCapital] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShareCapitalPayments]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShareCapitalPayments](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [nvarchar](50) NOT NULL,
	[DatePaid] [datetime] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_ShareCapitalPayments] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnconfirmedLoan]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnconfirmedLoan](
	[TransactionID] [int] NOT NULL,
	[ConfirmedByMaker] [bit] NULL,
	[ConfirmedByCoMaker] [bit] NULL,
	[DateFiled] [date] NOT NULL,
	[ConfirmCodeMakerSMS] [nvarchar](6) NULL,
	[ConfirmCodeCoMakerSMS] [nvarchar](6) NULL,
	[ConfirmCodeMakerEmail] [nvarchar](35) NULL,
	[ConfirmCodeCoMakerEmail] [nvarchar](35) NULL,
	[ConfirmedByCoMaker2] [bit] NULL,
	[ConfirmCodeCoMaker2SMS] [nvarchar](6) NULL,
	[ConfirmCodeCoMaker2Email] [nvarchar](35) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnconfirmedUsers]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnconfirmedUsers](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [nvarchar](10) NOT NULL,
	[DateRegistered] [date] NOT NULL,
	[ConfirmationCode] [nvarchar](35) NULL,
 CONSTRAINT [PK_UnconfirmedUsers] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserBeneficiaries]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBeneficiaries](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [nvarchar](10) NOT NULL,
	[BeneficiaryName] [nvarchar](100) NOT NULL,
	[DOB] [datetime] NOT NULL,
 CONSTRAINT [PK_UserBeneficiaries] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/25/2015 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [nvarchar](10) NOT NULL,
	[UserType] [nvarchar](15) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Email] [nvarchar](70) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](150) NULL,
	[Birthday] [date] NULL,
	[College] [nvarchar](30) NULL,
	[Dept] [nvarchar](30) NULL,
	[PhoneNumber] [nvarchar](13) NOT NULL,
	[DateConfirmed] [date] NULL,
	[MemberStatus] [nvarchar](50) NULL,
	[DateHired] [date] NULL,
	[Picture] [nvarchar](max) NULL,
	[ATMAccountNo] [nvarchar](50) NULL,
	[TINNo] [nvarchar](50) NULL,
	[SSSNo] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[CivilStatus] [nvarchar](20) NULL,
	[FatherName] [nvarchar](50) NULL,
	[FatherOccupation] [nvarchar](50) NULL,
	[MotherName] [nvarchar](50) NULL,
	[MotherOccupation] [nvarchar](50) NULL,
	[LegalSpouse] [nvarchar](50) NULL,
	[SpouseEmployer] [nvarchar](50) NULL,
	[BusinessName] [nvarchar](50) NULL,
	[BusinessAddress] [nvarchar](150) NULL,
	[OtherSourceOfIncome] [nvarchar](250) NULL,
	[EmergencyName] [nvarchar](50) NULL,
	[EmergencyAddress] [nvarchar](50) NULL,
	[EmergencyNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [Messages] SET  READ_WRITE 
GO
