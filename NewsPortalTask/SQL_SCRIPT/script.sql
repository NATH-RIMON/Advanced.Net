create table Categories
(
    Id       int identity
        constraint Categories_pk
            primary key nonclustered,
    Category varchar(50)
)
go

create table Users
(
    Id       int identity
        constraint Users_pk
            primary key nonclustered,
    Username varchar(15),
    Pass     varchar(128),
    UserType varchar(10)
)
go

create table News
(
    Id          int identity
        constraint News_pk
            primary key nonclustered,
    Title       varchar(256),
    Description varchar(1024),
    DatePosted  date,
    Category    varchar(50),
    PosterId    int
        constraint News_Users_Id_fk
            references Users
            on delete cascade
)
go

create table Comments
(
    Id            int identity
        constraint Comments_pk
            primary key nonclustered,
    Comment       varchar(512),
    CommenterName varchar(50),
    NewsId        int
        constraint Comments_News_Id_fk
            references News
            on delete cascade
)
go

create table Reacts
(
    Id          int identity
        constraint Reacts_pk
            primary key nonclustered,
    ReactType   varchar(50),
    ReactorName varchar(50),
    NewsId      int
        constraint Reacts_News_Id_fk
            references News
            on delete cascade
)
go


