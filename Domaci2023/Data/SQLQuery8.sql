begin tran

create table predmet(
	id bigint not null primary key identity(1,1),
	naziv nvarchar(255) not null,
	espb int not null,
);

go

create table zvanje(
	id bigint not null primary key identity(1,1),
	naziv nvarchar(30) not null,
);

go

create table nastavnik(
	id bigint not null primary key identity(1,1),
	ime nvarchar(100) not null,
	prezime nvarchar(100) not null,
	zvanje_id bigint not null,
	constraint FK_Zvanje foreign key (zvanje_id) references zvanje(id)
);

go

insert into predmet values ('m', 5);
insert into predmet values ('a', 5);
insert into predmet values ('b', 5);
insert into predmet values ('v', 5);
insert into predmet values ('g', 5);
insert into predmet values ('d', 5);
insert into predmet values ('dj', 5);
insert into predmet values ('e', 5);
insert into predmet values ('z', 5);

go

insert into zvanje values ('asistent');
insert into zvanje values ('asistent sa doktoratom');
insert into zvanje values ('docent');
insert into zvanje values ('vanredni profesor');
insert into zvanje values ('redovni profesor');

go

insert into nastavnik values ('d', 'b', 1);
insert into nastavnik values ('a', 't', 1);
insert into nastavnik values ('c', 'd', 2);
insert into nastavnik values ('e', 'f', 2);
insert into nastavnik values ('a', 't', 3);
insert into nastavnik values ('a', 't', 3);
insert into nastavnik values ('a', 't', 4);
insert into nastavnik values ('a', 't', 4);
insert into nastavnik values ('a', 't', 5);
insert into nastavnik values ('a', 't', 5);

commit