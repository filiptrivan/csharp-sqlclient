create table rec (
	Id bigint primary key identity(1,1),
	Naziv nvarchar(max) not null
)

create table jezik(
	Id bigint primary key identity(1,1),
	Naziv nvarchar(max) not null
)

create table prevod(
	Id bigint identity(1,1),
	RecId bigint not null,
	JezikId bigint not null,
	Naziv nvarchar(max) not null,
	constraint PK primary key (Id, RecId, JezikId),
	constraint FK_R foreign key (RecId) references rec (Id),
	constraint FK_J foreign key (JezikId) references jezik (Id),
)

insert into jezik values ('Srpski');
insert into jezik values ('Nemacki');

insert into Rec values ('Lako');
insert into Rec values ('Jako');
insert into Rec values ('Meko');
