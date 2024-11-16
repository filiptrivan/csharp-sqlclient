create table osoba (
jmbg nvarchar not null primary key,
ime nvarchar(max) not null,
prezime nvarchar(max) not null
)

create table instrument (
id bigint not null primary key identity(1,1),
naziv nvarchar(max) not null,
)

create table osobainstrument (
jmbg nvarchar not null,
instrumentid bigint not null,
constraint FK_j foreign key (jmbg) references osoba(jmbg),
constraint FK_i foreign key (instrumentid) references instrument(id),
constraint PK primary key (jmbg, instrumentid)
)

insert into osoba values ('1', 'filip', 'trivan');
insert into osoba values ('2', 'a', 't');
insert into osoba values ('3', 'b', 't');
insert into osoba values ('4', 'd', 't');

insert into instrument values ('saksofon');
insert into instrument values ('gitara');

insert into osobainstrument values ('1', 1);
insert into osobainstrument values ('1', 2);
insert into osobainstrument values ('2', 2);
insert into osobainstrument values ('3', 2);
insert into osobainstrument values ('4', 2);
