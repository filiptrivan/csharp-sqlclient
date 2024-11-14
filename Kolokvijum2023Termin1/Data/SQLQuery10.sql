begin tran

create table katedra (
	id bigint primary key identity(1,1),
	naziv nvarchar(30) not null,
)

create table predmet (
	id bigint primary key identity(1,1),
	naziv nvarchar(255) not null,
	espb int not null,
	katedraId bigint not null,
	constraint FK_K foreign key (katedraId) references katedra (id)
)

insert into katedra values ('kat 1');
insert into katedra values ('kat 2');
insert into katedra values ('kat 3');
insert into katedra values ('kat 4');
insert into katedra values ('kat 5');
insert into katedra values ('kat 6');

insert into predmet values ('predmet 1', 5, 1);
insert into predmet values ('predmet 2', 5, 1);
insert into predmet values ('predmet 3', 5, 2);
insert into predmet values ('predmet 4', 5, 2);
insert into predmet values ('predmet 5', 5, 3);

commit