# SimpleMVCWithCRUDOperations
This example allows us to create an ASP.NET MVC by performing CRUD (Create, Read, Update and Delete) operations for a sample Customer Record Management System.

# Steps to Debug the project
1. Open Microsoft Visual Studio Enterprise 2015
2. Make sure GitHub Extension for Visual Studio is installed.
3. File > Open > Open from GitHub...
4. Sign in GitHub
5. Search by SimpleMVCWithCRUDOperations
6. Set Local path ~\SimpleMVCWithCRUDOperations
7. Clone Repository
8. Open the slnCRUD from Team Explorer
9. Before Debugging, create the database
10. Open SQL Server 2016
11. Copy and paste the script below:   
########################################################   
CREATE DATABASE DbCompanyLtd   
GO   
USE [DbCompanyLtd]   
GO   
CREATE TABLE [dbo].[tbCustomer](    
    [CustomerId] INT IDENTITY(1,1) NOT NULL,    
    [FirstName] VARCHAR(20) NOT NULL,    
    [LastName] VARCHAR(20) NOT NULL,   
    [Address] VARCHAR(50) NULL,    
    [Email] VARCHAR(50) NULL,   
    [ContactNo] INT NULL,   
    [IsActive] BIT NOT NULL DEFAULT 1   
)   
#########################################################
12. Execute the script
13. Back to Visual Studio, set the Connection String accordingly
14. Clean and build solution
15. Finally press F5 to Start Debugging
