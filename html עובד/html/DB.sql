CREATE TABLE [dbo].[Activity] (
    [ActivityId]      NVARCHAR (10) NOT NULL,
    [ActivitiesName]  NVARCHAR (50) NOT NULL,
    [ActivitiesPlace] NVARCHAR (50) NOT NULL,
    [ActivitiesDate]  DATETIME      NOT NULL,
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ShabessCamp] (
    [Id]                     NVARCHAR (10) NOT NULL,
    [TimeOfPrayInBeitKneset] DATETIME      NOT NULL,
    [Lecturers]              NVARCHAR (50) NOT NULL,
    [ActivitiesId]           INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ShabessCamp_ToActivity] FOREIGN KEY ([ActivitiesId]) REFERENCES [dbo].[Activity] ([Id])
);
CREATE TABLE [dbo].[Person] (
    [PersonId]      NVARCHAR (9) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [Address] NVARCHAR (50) NOT NULL,
    [password]  NVARCHAR (50) NOT NULL,
    [Email]   NVARCHAR (50)      NOT NULL,
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[Students] (
    [Age]        FLOAT (53)    NOT NULL,
    [FatherName] NVARCHAR (50) NOT NULL,
    [MotherName] NVARCHAR (50) NOT NULL,
    [ClassNum]   NVARCHAR (10) NOT NULL,
    [Sister]     BIT           NOT NULL,
    [Pharm]      NVARCHAR (50) NOT NULL,
    [Id]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Students_ToPerson] FOREIGN KEY ([Id]) REFERENCES [dbo].[Person] ([Id])
);

CREATE TABLE [dbo].[StudentToActivities] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [ActivitiesId] INT NOT NULL,
    [StudentId]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StudentToActivities_ToStudent] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]),
    CONSTRAINT [FK_StudentToActivities_ToActivity] FOREIGN KEY ([ActivitiesId]) REFERENCES [dbo].[Activity] ([Id])
);

CREATE TABLE [dbo].[Teacher] (
    [Educator] BIT NOT NULL,
    [Id]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Teacher_ToPerson] FOREIGN KEY ([Id]) REFERENCES [dbo].[Person] ([Id])
);
CREATE TABLE [dbo].[TeachersToActivities] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [TeacherId]    INT NOT NULL,
    [ActivitiesId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TeachersToActivities_ToTeacher] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teacher] ([Id]),
    CONSTRAINT [FK_TeachersToActivities_ToActivity] FOREIGN KEY ([ActivitiesId]) REFERENCES [dbo].[Activity] ([Id])
);

CREATE TABLE [dbo].[Trip] (
    [Id]                NVARCHAR (10) NOT NULL,
    [Guide]             NVARCHAR (50) NOT NULL,
    [DurationOfTheTrip] FLOAT (53)    NOT NULL,
    [Sites]             NVARCHAR (50) NOT NULL,
    [Buses]             NVARCHAR (50) NOT NULL,
    [IdActivities]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trip_ToActivity] FOREIGN KEY ([IdActivities]) REFERENCES [dbo].[Activity] ([Id])
);


