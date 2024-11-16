create table jezik (
id bigint not null primary key identity(1,1),
naziv nvarchar(max) not null,
skraceni_naziv nvarchar(max) not null,
)

create table srb_rec (
id bigint not null primary key identity(1,1),
naziv nvarchar(max) not null,
)

create table prevod (
id bigint not null identity(1,1),
jezikid bigint not null,
srb_recid bigint not null,
constraint FK_j foreign key (jezikid) references jezik(id),
constraint FK_s foreign key (srb_recid) references srb_rec(id),
constraint PK primary key (id, jezikid, srb_recid),
)

alter table prevod add naziv nvarchar(max) not null

alter table srb_rec add napravljen datetime
alter table srb_rec add skracenica nvarchar(max);

insert into jezik values ('Srpski', 'srp');
insert into jezik values ('Engleski', 'en');

insert into srb_rec values ('Sto');

insert into prevod values (1, 1, 'Table');
insert into prevod values (1, 1, 'Desk');