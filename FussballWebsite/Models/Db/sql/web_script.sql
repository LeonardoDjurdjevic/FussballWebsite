create database fussball collate utf8mb4_general_ci;

use fussball;

create table users(
		user_id int unsigned not null auto_increment,
		username varchar(100) not null,
		password varchar(300) not null,
		email varchar(150) null,
		birthdate date null,
		profilpicture varchar(100) null,
		gender int null,
		liga int null,
		role int null,
		
		constraint user_id_PK primary key (user_id)
);
