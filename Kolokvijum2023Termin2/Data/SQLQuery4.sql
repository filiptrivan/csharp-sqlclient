create table organizaciona_jedinica (
id bigint not null primary key identity (1,1),
naziv nvarchar(100) not null
)

create table radnik (
id bigint not null primary key identity (1,1),
radna_knjizica nvarchar(10) not null,
jmbg nchar(13) not null,
ime nvarchar(100) not null,
prezime nvarchar(100) not null,
oj bigint not null,
constraint FK_O foreign key (oj) references organizaciona_jedinica (id)
)

insert into organizaciona_jedinica values ('Tim');
insert into organizaciona_jedinica values ('Stridon');