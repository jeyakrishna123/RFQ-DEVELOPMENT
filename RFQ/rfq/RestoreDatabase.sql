-- =====================================================
-- Add Tbl_Configuration to DIM_RECORDING_USRS Database
-- Run this script in SQL Server Management Studio (SSMS)
-- =====================================================

USE [DIM_RECORDING_USRS]
GO

-- Create the Configuration Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tbl_Configuration]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Tbl_Configuration](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [Key] [nvarchar](255) NOT NULL,
        [Type] [nvarchar](50) NULL,
        [Value] [nvarchar](MAX) NULL,
        [CreatedBy] [nvarchar](50) NULL,
        [CreatedDate] [datetime] NULL,
        [ModifiedBy] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        CONSTRAINT [PK_Tbl_Configuration] PRIMARY KEY CLUSTERED ([ID] ASC)
    )
    PRINT 'Table Tbl_Configuration created successfully.'
END
ELSE
BEGIN
    PRINT 'Table Tbl_Configuration already exists.'
END
GO

-- Insert sample configuration data
INSERT INTO [dbo].[Tbl_Configuration] ([Key], [Type], [Value], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
VALUES
('DwngByProductionOrder', 'Query', 'SELECT REPLACE(LTRIM(REPLACE(B.PROD_ORDR_NBR,''0'','' '')),'' '',''0'')', NULL, NULL, '00663977', '2022-02-17 01:48:17.330'),
('DwngByConfirmationNo', 'Query', 'SELECT REPLACE(LTRIM(REPLACE(B.PROD_ORDR_NBR,''0'','' '')),'' '',''0'')', NULL, NULL, '00663977', '2022-02-17 01:48:17.330'),
('Drawing_Folder', 'Folder', 'C:\Users\admin\Documents\GitHub\Auto-Ballooning-IES\IES_s...', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('Baloon_Drawing', 'Folder', 'D:\Auto Balloon\Drawed Images', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('ErrorLog_Folder', 'Folder', 'D:\Auto Balloon\ErrorLog\', NULL, NULL, '00663977', '2022-02-17 01:48:17.330'),
('InspectionReportPDF_Folder', 'Folder', 'D:\Auto Balloon\Inspection Result Export', NULL, NULL, 'JT00060', '2022-02-17 01:48:17.330'),
('InspectionImagePDF_Folder', 'Folder', 'D:\Auto Balloon\PDF Upload', NULL, NULL, '00663977', '2022-02-17 01:48:17.330'),
('BalloonWidth', 'Settings', '150', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('BalloonHeight', 'Settings', '150', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('BalloonColor', 'Settings', '255-0-0-255', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('BalloonTextColor', 'Settings', '255-255-0-0', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('BalloonFontSize', 'Settings', '20', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('BallonNumberFontSize', 'Settings', '50', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('MinMaxOneDigit', 'Settings', '0.03', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('MinMaxTwoDigit', 'Settings', '0.015', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('MinMaxThreeDigit', 'Settings', '0.005', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527'),
('MinMaxFourDigit', 'Settings', '0.001', NULL, NULL, 'JT00060', '2022-10-05 01:49:43.527')
GO

-- Verify the data
SELECT * FROM [dbo].[Tbl_Configuration]
GO
