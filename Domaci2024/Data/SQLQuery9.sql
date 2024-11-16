create table profesor (
id bigint not null primary key identity(1,1),
ime nvarchar(max) not null,
prezime nvarchar(max) not null,
zvanje nvarchar(max) not null,
email_kreatora nvarchar(max) not null,
)

create table predmet (
id bigint not null primary key identity(1,1),
naziv nvarchar(max) not null,
kod nchar(10) not null,
espb int not null,
)

create table angazovanje (
profesorid bigint not null,
predmetid bigint not null,
constraint FK_1 foreign key (profesorid) references profesor(id),
constraint FK_2 foreign key (predmetid) references predmet(id),
)

insert into predmet values('Mata', '1234567890', 10);
insert into predmet values('Engleski', '1234567890', 7);
insert into predmet values('PP', '1234567890', 7);
insert into predmet values('P1', '1234567890', 7);