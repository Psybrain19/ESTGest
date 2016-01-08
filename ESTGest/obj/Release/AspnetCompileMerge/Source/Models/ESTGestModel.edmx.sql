
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/02/2015 19:56:22
-- Generated from EDMX file: C:\Users\Bruno\Documents\Visual Studio 2015\Projects\ESTGest\ESTGest\Models\ESTGestModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ESTGestDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Arduino_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Arduino] DROP CONSTRAINT [FK_Arduino_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_Course_CourseCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course] DROP CONSTRAINT [FK_Course_CourseCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseClass_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseClass] DROP CONSTRAINT [FK_CourseClass_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseClass_Schedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseClass] DROP CONSTRAINT [FK_CourseClass_Schedule];
GO
IF OBJECT_ID(N'[dbo].[FK_Discipline_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Discipline] DROP CONSTRAINT [FK_Discipline_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_Discipline_ScheduleContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Discipline] DROP CONSTRAINT [FK_Discipline_ScheduleContent];
GO
IF OBJECT_ID(N'[dbo].[FK_Presence_Discipline]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Presence] DROP CONSTRAINT [FK_Presence_Discipline];
GO
IF OBJECT_ID(N'[dbo].[FK_Presence_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Presence] DROP CONSTRAINT [FK_Presence_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseProductList_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseProductList] DROP CONSTRAINT [FK_PurchaseProductList_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseProductList_Purchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseProductList] DROP CONSTRAINT [FK_PurchaseProductList_Purchase];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_RoomType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_RoomType];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_ScheduleContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_ScheduleContent];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleContent_Schedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleContent] DROP CONSTRAINT [FK_ScheduleContent_Schedule];
GO
IF OBJECT_ID(N'[dbo].[FK_User_BankAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_BankAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_User_ChargeAccountReference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_ChargeAccountReference];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_User_CourseClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_CourseClass];
GO
IF OBJECT_ID(N'[dbo].[FK_User_PurchaseProductList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_PurchaseProductList];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDisciplineList_Discipline]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDisciplineList] DROP CONSTRAINT [FK_UserDisciplineList_Discipline];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDisciplineList_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDisciplineList] DROP CONSTRAINT [FK_UserDisciplineList_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPresenceList_Presence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPresenceList] DROP CONSTRAINT [FK_UserPresenceList_Presence];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPresenceList_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPresenceList] DROP CONSTRAINT [FK_UserPresenceList_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Arduino]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Arduino];
GO
IF OBJECT_ID(N'[dbo].[BankAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankAccount];
GO
IF OBJECT_ID(N'[dbo].[ChargeAccountReference]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChargeAccountReference];
GO
IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[CourseCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseCategory];
GO
IF OBJECT_ID(N'[dbo].[CourseClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseClass];
GO
IF OBJECT_ID(N'[dbo].[Discipline]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Discipline];
GO
IF OBJECT_ID(N'[dbo].[Presence]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Presence];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Purchase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchase];
GO
IF OBJECT_ID(N'[dbo].[PurchaseProductList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseProductList];
GO
IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO
IF OBJECT_ID(N'[dbo].[RoomType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomType];
GO
IF OBJECT_ID(N'[dbo].[Schedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schedule];
GO
IF OBJECT_ID(N'[dbo].[ScheduleContent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleContent];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserDisciplineList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserDisciplineList];
GO
IF OBJECT_ID(N'[dbo].[UserPresenceList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserPresenceList];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Arduino'
CREATE TABLE [dbo].[Arduino] (
    [a_id] int IDENTITY(1,1) NOT NULL,
    [a_value] nvarchar(50)  NOT NULL,
    [a_room_id] int  NOT NULL
);
GO

-- Creating table 'BankAccount'
CREATE TABLE [dbo].[BankAccount] (
    [ba_id] int IDENTITY(1,1) NOT NULL,
    [ba_number] nvarchar(50)  NOT NULL,
    [bar_cash] int  NULL
);
GO

-- Creating table 'ChargeAccountReference'
CREATE TABLE [dbo].[ChargeAccountReference] (
    [car_id] int IDENTITY(1,1) NOT NULL,
    [car_reference] nvarchar(50)  NOT NULL,
    [car_state] int  NOT NULL,
    [car_valtime] datetime  NOT NULL,
    [car_amount] int  NOT NULL
);
GO

-- Creating table 'Course'
CREATE TABLE [dbo].[Course] (
    [c_id] int IDENTITY(1,1) NOT NULL,
    [c_designation] nvarchar(50)  NOT NULL,
    [c_coursecat_id] int  NOT NULL
);
GO

-- Creating table 'CourseCategory'
CREATE TABLE [dbo].[CourseCategory] (
    [cc_id] int IDENTITY(1,1) NOT NULL,
    [cc_designation] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'CourseClass'
CREATE TABLE [dbo].[CourseClass] (
    [cc_id] int  NOT NULL,
    [cc_designation] nvarchar(50)  NOT NULL,
    [cc_course_id] int  NOT NULL,
    [cc_schedule_id] int  NOT NULL
);
GO

-- Creating table 'Discipline'
CREATE TABLE [dbo].[Discipline] (
    [d_id] int IDENTITY(1,1) NOT NULL,
    [d_designation] nvarchar(50)  NOT NULL,
    [d_value] int  NULL,
    [d_yearcourse] int  NULL,
    [d_credits] int  NULL,
    [d_user_id] int  NOT NULL,
    [d_course_id] int  NOT NULL,
    [d_scontent_id] int  NOT NULL
);
GO

-- Creating table 'Presence'
CREATE TABLE [dbo].[Presence] (
    [p_id] int IDENTITY(1,1) NOT NULL,
    [p_discipline_id] int  NOT NULL,
    [p_room_id] int  NOT NULL,
    [p_checkin] time  NOT NULL,
    [p_checkout] time  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [pr_id] int IDENTITY(1,1) NOT NULL,
    [pr_designation] nvarchar(50)  NOT NULL,
    [pr_price] int  NOT NULL
);
GO

-- Creating table 'Purchase'
CREATE TABLE [dbo].[Purchase] (
    [p_id] int IDENTITY(1,1) NOT NULL,
    [p_designation] nvarchar(50)  NOT NULL,
    [p_total] int  NULL,
    [p_product_id] int  NOT NULL
);
GO

-- Creating table 'PurchaseProductList'
CREATE TABLE [dbo].[PurchaseProductList] (
    [ppl_id] int IDENTITY(1,1) NOT NULL,
    [ppl_purchase_id] int  NOT NULL,
    [ppl_product_id] int  NOT NULL
);
GO

-- Creating table 'Room'
CREATE TABLE [dbo].[Room] (
    [r_id] int  NOT NULL,
    [r_designation] nvarchar(50)  NOT NULL,
    [r_arduino_id] int  NOT NULL,
    [r_dscontent_id] int  NOT NULL,
    [r_roomtype_id] int  NOT NULL
);
GO

-- Creating table 'RoomType'
CREATE TABLE [dbo].[RoomType] (
    [rt_id] int IDENTITY(1,1) NOT NULL,
    [rt_designation] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Schedule'
CREATE TABLE [dbo].[Schedule] (
    [sch_id] int IDENTITY(1,1) NOT NULL,
    [sch_designation] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ScheduleContent'
CREATE TABLE [dbo].[ScheduleContent] (
    [scontent_id] int IDENTITY(1,1) NOT NULL,
    [scontent_sch_id] int  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [u_id] int IDENTITY(1,1) NOT NULL,
    [u_name] nvarchar(50)  NOT NULL,
    [u_number] int  NOT NULL,
    [u_course_id] int  NOT NULL,
    [u_courseclass_id] int  NOT NULL,
    [u_purchaselist_id] int  NOT NULL,
    [u_bankaccount_id] int  NOT NULL,
    [u_chargeaccref_id] int  NOT NULL,
    [u_disciplineist_id] int  NOT NULL
);
GO

-- Creating table 'UserDisciplineList'
CREATE TABLE [dbo].[UserDisciplineList] (
    [udl_id] int IDENTITY(1,1) NOT NULL,
    [udl_user_id] int  NOT NULL,
    [udl_discipline_id] int  NOT NULL
);
GO

-- Creating table 'UserPresenceList'
CREATE TABLE [dbo].[UserPresenceList] (
    [upl_id] int IDENTITY(1,1) NOT NULL,
    [upl_user_id] int  NOT NULL,
    [upl_presence_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [a_id] in table 'Arduino'
ALTER TABLE [dbo].[Arduino]
ADD CONSTRAINT [PK_Arduino]
    PRIMARY KEY CLUSTERED ([a_id] ASC);
GO

-- Creating primary key on [ba_id] in table 'BankAccount'
ALTER TABLE [dbo].[BankAccount]
ADD CONSTRAINT [PK_BankAccount]
    PRIMARY KEY CLUSTERED ([ba_id] ASC);
GO

-- Creating primary key on [car_id] in table 'ChargeAccountReference'
ALTER TABLE [dbo].[ChargeAccountReference]
ADD CONSTRAINT [PK_ChargeAccountReference]
    PRIMARY KEY CLUSTERED ([car_id] ASC);
GO

-- Creating primary key on [c_id] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [PK_Course]
    PRIMARY KEY CLUSTERED ([c_id] ASC);
GO

-- Creating primary key on [cc_id] in table 'CourseCategory'
ALTER TABLE [dbo].[CourseCategory]
ADD CONSTRAINT [PK_CourseCategory]
    PRIMARY KEY CLUSTERED ([cc_id] ASC);
GO

-- Creating primary key on [cc_id] in table 'CourseClass'
ALTER TABLE [dbo].[CourseClass]
ADD CONSTRAINT [PK_CourseClass]
    PRIMARY KEY CLUSTERED ([cc_id] ASC);
GO

-- Creating primary key on [d_id] in table 'Discipline'
ALTER TABLE [dbo].[Discipline]
ADD CONSTRAINT [PK_Discipline]
    PRIMARY KEY CLUSTERED ([d_id] ASC);
GO

-- Creating primary key on [p_id] in table 'Presence'
ALTER TABLE [dbo].[Presence]
ADD CONSTRAINT [PK_Presence]
    PRIMARY KEY CLUSTERED ([p_id] ASC);
GO

-- Creating primary key on [pr_id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([pr_id] ASC);
GO

-- Creating primary key on [p_id] in table 'Purchase'
ALTER TABLE [dbo].[Purchase]
ADD CONSTRAINT [PK_Purchase]
    PRIMARY KEY CLUSTERED ([p_id] ASC);
GO

-- Creating primary key on [ppl_id] in table 'PurchaseProductList'
ALTER TABLE [dbo].[PurchaseProductList]
ADD CONSTRAINT [PK_PurchaseProductList]
    PRIMARY KEY CLUSTERED ([ppl_id] ASC);
GO

-- Creating primary key on [r_id] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [PK_Room]
    PRIMARY KEY CLUSTERED ([r_id] ASC);
GO

-- Creating primary key on [rt_id] in table 'RoomType'
ALTER TABLE [dbo].[RoomType]
ADD CONSTRAINT [PK_RoomType]
    PRIMARY KEY CLUSTERED ([rt_id] ASC);
GO

-- Creating primary key on [sch_id] in table 'Schedule'
ALTER TABLE [dbo].[Schedule]
ADD CONSTRAINT [PK_Schedule]
    PRIMARY KEY CLUSTERED ([sch_id] ASC);
GO

-- Creating primary key on [scontent_id] in table 'ScheduleContent'
ALTER TABLE [dbo].[ScheduleContent]
ADD CONSTRAINT [PK_ScheduleContent]
    PRIMARY KEY CLUSTERED ([scontent_id] ASC);
GO

-- Creating primary key on [u_id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([u_id] ASC);
GO

-- Creating primary key on [udl_id] in table 'UserDisciplineList'
ALTER TABLE [dbo].[UserDisciplineList]
ADD CONSTRAINT [PK_UserDisciplineList]
    PRIMARY KEY CLUSTERED ([udl_id] ASC);
GO

-- Creating primary key on [upl_id] in table 'UserPresenceList'
ALTER TABLE [dbo].[UserPresenceList]
ADD CONSTRAINT [PK_UserPresenceList]
    PRIMARY KEY CLUSTERED ([upl_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [a_room_id] in table 'Arduino'
ALTER TABLE [dbo].[Arduino]
ADD CONSTRAINT [FK_Arduino_Room]
    FOREIGN KEY ([a_room_id])
    REFERENCES [dbo].[Room]
        ([r_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Arduino_Room'
CREATE INDEX [IX_FK_Arduino_Room]
ON [dbo].[Arduino]
    ([a_room_id]);
GO

-- Creating foreign key on [u_bankaccount_id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_BankAccount]
    FOREIGN KEY ([u_bankaccount_id])
    REFERENCES [dbo].[BankAccount]
        ([ba_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_BankAccount'
CREATE INDEX [IX_FK_User_BankAccount]
ON [dbo].[User]
    ([u_bankaccount_id]);
GO

-- Creating foreign key on [u_chargeaccref_id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_ChargeAccountReference]
    FOREIGN KEY ([u_chargeaccref_id])
    REFERENCES [dbo].[ChargeAccountReference]
        ([car_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_ChargeAccountReference'
CREATE INDEX [IX_FK_User_ChargeAccountReference]
ON [dbo].[User]
    ([u_chargeaccref_id]);
GO

-- Creating foreign key on [c_coursecat_id] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [FK_Course_CourseCategory]
    FOREIGN KEY ([c_coursecat_id])
    REFERENCES [dbo].[CourseCategory]
        ([cc_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_CourseCategory'
CREATE INDEX [IX_FK_Course_CourseCategory]
ON [dbo].[Course]
    ([c_coursecat_id]);
GO

-- Creating foreign key on [cc_course_id] in table 'CourseClass'
ALTER TABLE [dbo].[CourseClass]
ADD CONSTRAINT [FK_CourseClass_Course]
    FOREIGN KEY ([cc_course_id])
    REFERENCES [dbo].[Course]
        ([c_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseClass_Course'
CREATE INDEX [IX_FK_CourseClass_Course]
ON [dbo].[CourseClass]
    ([cc_course_id]);
GO

-- Creating foreign key on [d_course_id] in table 'Discipline'
ALTER TABLE [dbo].[Discipline]
ADD CONSTRAINT [FK_Discipline_Course]
    FOREIGN KEY ([d_course_id])
    REFERENCES [dbo].[Course]
        ([c_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Discipline_Course'
CREATE INDEX [IX_FK_Discipline_Course]
ON [dbo].[Discipline]
    ([d_course_id]);
GO

-- Creating foreign key on [u_course_id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Course]
    FOREIGN KEY ([u_course_id])
    REFERENCES [dbo].[Course]
        ([c_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Course'
CREATE INDEX [IX_FK_User_Course]
ON [dbo].[User]
    ([u_course_id]);
GO

-- Creating foreign key on [cc_schedule_id] in table 'CourseClass'
ALTER TABLE [dbo].[CourseClass]
ADD CONSTRAINT [FK_CourseClass_Schedule]
    FOREIGN KEY ([cc_schedule_id])
    REFERENCES [dbo].[Schedule]
        ([sch_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseClass_Schedule'
CREATE INDEX [IX_FK_CourseClass_Schedule]
ON [dbo].[CourseClass]
    ([cc_schedule_id]);
GO

-- Creating foreign key on [u_courseclass_id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_CourseClass]
    FOREIGN KEY ([u_courseclass_id])
    REFERENCES [dbo].[CourseClass]
        ([cc_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_CourseClass'
CREATE INDEX [IX_FK_User_CourseClass]
ON [dbo].[User]
    ([u_courseclass_id]);
GO

-- Creating foreign key on [d_scontent_id] in table 'Discipline'
ALTER TABLE [dbo].[Discipline]
ADD CONSTRAINT [FK_Discipline_ScheduleContent]
    FOREIGN KEY ([d_scontent_id])
    REFERENCES [dbo].[ScheduleContent]
        ([scontent_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Discipline_ScheduleContent'
CREATE INDEX [IX_FK_Discipline_ScheduleContent]
ON [dbo].[Discipline]
    ([d_scontent_id]);
GO

-- Creating foreign key on [p_discipline_id] in table 'Presence'
ALTER TABLE [dbo].[Presence]
ADD CONSTRAINT [FK_Presence_Discipline]
    FOREIGN KEY ([p_discipline_id])
    REFERENCES [dbo].[Discipline]
        ([d_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Presence_Discipline'
CREATE INDEX [IX_FK_Presence_Discipline]
ON [dbo].[Presence]
    ([p_discipline_id]);
GO

-- Creating foreign key on [udl_discipline_id] in table 'UserDisciplineList'
ALTER TABLE [dbo].[UserDisciplineList]
ADD CONSTRAINT [FK_UserDisciplineList_Discipline]
    FOREIGN KEY ([udl_discipline_id])
    REFERENCES [dbo].[Discipline]
        ([d_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDisciplineList_Discipline'
CREATE INDEX [IX_FK_UserDisciplineList_Discipline]
ON [dbo].[UserDisciplineList]
    ([udl_discipline_id]);
GO

-- Creating foreign key on [p_room_id] in table 'Presence'
ALTER TABLE [dbo].[Presence]
ADD CONSTRAINT [FK_Presence_Room]
    FOREIGN KEY ([p_room_id])
    REFERENCES [dbo].[Room]
        ([r_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Presence_Room'
CREATE INDEX [IX_FK_Presence_Room]
ON [dbo].[Presence]
    ([p_room_id]);
GO

-- Creating foreign key on [upl_presence_id] in table 'UserPresenceList'
ALTER TABLE [dbo].[UserPresenceList]
ADD CONSTRAINT [FK_UserPresenceList_Presence]
    FOREIGN KEY ([upl_presence_id])
    REFERENCES [dbo].[Presence]
        ([p_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPresenceList_Presence'
CREATE INDEX [IX_FK_UserPresenceList_Presence]
ON [dbo].[UserPresenceList]
    ([upl_presence_id]);
GO

-- Creating foreign key on [ppl_product_id] in table 'PurchaseProductList'
ALTER TABLE [dbo].[PurchaseProductList]
ADD CONSTRAINT [FK_PurchaseProductList_Product]
    FOREIGN KEY ([ppl_product_id])
    REFERENCES [dbo].[Product]
        ([pr_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseProductList_Product'
CREATE INDEX [IX_FK_PurchaseProductList_Product]
ON [dbo].[PurchaseProductList]
    ([ppl_product_id]);
GO

-- Creating foreign key on [ppl_purchase_id] in table 'PurchaseProductList'
ALTER TABLE [dbo].[PurchaseProductList]
ADD CONSTRAINT [FK_PurchaseProductList_Purchase]
    FOREIGN KEY ([ppl_purchase_id])
    REFERENCES [dbo].[Purchase]
        ([p_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseProductList_Purchase'
CREATE INDEX [IX_FK_PurchaseProductList_Purchase]
ON [dbo].[PurchaseProductList]
    ([ppl_purchase_id]);
GO

-- Creating foreign key on [u_purchaselist_id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_PurchaseProductList]
    FOREIGN KEY ([u_purchaselist_id])
    REFERENCES [dbo].[PurchaseProductList]
        ([ppl_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_PurchaseProductList'
CREATE INDEX [IX_FK_User_PurchaseProductList]
ON [dbo].[User]
    ([u_purchaselist_id]);
GO

-- Creating foreign key on [r_roomtype_id] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [FK_Room_RoomType]
    FOREIGN KEY ([r_roomtype_id])
    REFERENCES [dbo].[RoomType]
        ([rt_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_RoomType'
CREATE INDEX [IX_FK_Room_RoomType]
ON [dbo].[Room]
    ([r_roomtype_id]);
GO

-- Creating foreign key on [r_dscontent_id] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [FK_Room_ScheduleContent]
    FOREIGN KEY ([r_dscontent_id])
    REFERENCES [dbo].[ScheduleContent]
        ([scontent_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_ScheduleContent'
CREATE INDEX [IX_FK_Room_ScheduleContent]
ON [dbo].[Room]
    ([r_dscontent_id]);
GO

-- Creating foreign key on [scontent_sch_id] in table 'ScheduleContent'
ALTER TABLE [dbo].[ScheduleContent]
ADD CONSTRAINT [FK_ScheduleContent_Schedule]
    FOREIGN KEY ([scontent_sch_id])
    REFERENCES [dbo].[Schedule]
        ([sch_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleContent_Schedule'
CREATE INDEX [IX_FK_ScheduleContent_Schedule]
ON [dbo].[ScheduleContent]
    ([scontent_sch_id]);
GO

-- Creating foreign key on [udl_user_id] in table 'UserDisciplineList'
ALTER TABLE [dbo].[UserDisciplineList]
ADD CONSTRAINT [FK_UserDisciplineList_User]
    FOREIGN KEY ([udl_user_id])
    REFERENCES [dbo].[User]
        ([u_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDisciplineList_User'
CREATE INDEX [IX_FK_UserDisciplineList_User]
ON [dbo].[UserDisciplineList]
    ([udl_user_id]);
GO

-- Creating foreign key on [upl_user_id] in table 'UserPresenceList'
ALTER TABLE [dbo].[UserPresenceList]
ADD CONSTRAINT [FK_UserPresenceList_User]
    FOREIGN KEY ([upl_user_id])
    REFERENCES [dbo].[User]
        ([u_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPresenceList_User'
CREATE INDEX [IX_FK_UserPresenceList_User]
ON [dbo].[UserPresenceList]
    ([upl_user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------