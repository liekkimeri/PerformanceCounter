
use PerformanceCounter

CREATE TABLE Host (
    ID int IDENTITY(1,1) ,
    HostName varchar(255) NOT NULL,
    IP varchar(255) NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE Perfermance  (
    Perfermance_ID int IDENTITY(1,1) ,
    cpu float NOT NULL,
    ram int NOT NULL,
    timeStamp date NOT NULL,
    PRIMARY KEY (Perfermance_ID),
    ID int FOREIGN KEY REFERENCES Host(ID)
);

CREATE TABLE DriveInfo (
    DriveInfo_ID int IDENTITY(1,1) ,
    name varchar(255) NOT NULL,
    TotalFreeSpace BIGINT NOT NULL,
    timeStamp datetime NOT NULL,
    PRIMARY KEY (DriveInfo_ID),
    ID int FOREIGN KEY REFERENCES Host(ID)
);