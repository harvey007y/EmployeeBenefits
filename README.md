# EmployeeBenefits
Employee Benefits MVC

<h3>Business Need: </h3>
<p>One of the critical functions that we provide for our clients is the ability to pay for their employees’ benefits packages. A portion of these costs are deducted from their paycheck, and we handle that deduction. Please demonstrate how you would code the following scenario: 
	<ul>
		<li> The cost of benefits is $1000/year for each employee </li>
<li> Each dependent (children and possibly spouses) incurs a cost of $500/year </li>
<li> Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent</li>
		</ul>
	</p>
	<p>

We’d like to see this calculation used in a web application where employers input employees and their dependents, and get a preview of the costs. This is of course a contrived example. We want to know how you would implement the application structure and calculations and get a brief preview of how you work. 
Please implement a web application based on these assumptions: 
<ul>
	<li> All employees are paid $2000 per paycheck before deductions </li>
	<li> There are 26 paychecks in a year </li>
	</ul>
</p>
Here is the sql that can be used to create the tables needed for this project:

USE [EmployeeDB]
GO

/****** Object:  Table [dbo].[tblEmployee]    Script Date: 3/5/2020 12:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[City] [varchar](50) NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [EmployeeDB]
GO

/****** Object:  Table [dbo].[tblDependents]    Script Date: 3/5/2020 10:48:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDependents](
	[DependentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Type] [nchar](10) NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Dependents] PRIMARY KEY CLUSTERED 
(
	[DependentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblDependents]  WITH CHECK ADD  CONSTRAINT [FK_Dependents_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO

ALTER TABLE [dbo].[tblDependents] CHECK CONSTRAINT [FK_Dependents_tblEmployee]
GO

<br /><br />
Here is a screenshot of the Home page:<br /><br />
<center>
<a href="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Home.PNG" target="_blank"><img src="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Home.PNG" border="0" alt="Screenshot for HomePage" width="800px"/><br />(click to enlarge)</a>
 <br /><br /></center>
 <br /><br />
Here is a screenshot of the Employee Edit page:<br /><br />
<center>
<a href="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Edit.PNG" target="_blank"><img src="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Edit.PNG" border="0" alt="Screenshot for Employee Edit Page" width="800px"/><br />(click to enlarge)</a>
 <br /><br /></center>
  <br /><br />
Here is a screenshot of the Employee Details page:<br /><br />
<center>
<a href="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Details.PNG" target="_blank"><img src="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Details.PNG" border="0" alt="Screenshot for Employee Details Page" width="800px"/><br />(click to enlarge)</a>
 <br /><br /></center>
   <br /><br />
Here is a screenshot of the Employee Dependents List page:<br /><br />
<center>
<a href="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Dependents.PNG" target="_blank"><img src="https://github.com/harvey007y/EmployeeBenefits/blob/master/EmployeeBenefits.Site/Images/Dependents.PNG" border="0" alt="Screenshot for Employee Dependents List Page" width="800px"/><br />(click to enlarge)</a>
 <br /><br /></center>
