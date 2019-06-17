drop database if exists tc_changes;
create database tc_changes;
use tc_changes;

create table users
(
    id_users int unsigned not null auto_increment,
		primary key(id_users),
    name char(42) not null
)
    engine=innodb
    default character set utf8 collate utf8_unicode_ci;
	
	
create table changes
(
    id_changes int unsigned not null auto_increment,
		primary key(id_changes),
    user_ int unsigned not null,
		foreign key(user_) references users(id_users),
	source char(200) not null,
	destination char(200) not null,
    time_ datetime not null
)
    engine=innodb
    default character set utf8 collate utf8_unicode_ci;
	
