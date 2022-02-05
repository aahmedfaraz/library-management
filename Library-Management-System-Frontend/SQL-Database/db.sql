--create Database saba

--create table Persons
--(
--personId int identity(1,1) primary key not null,
--name varchar(255) not null,
--email varchar(255) not null unique,
--password varchar(255) not null,
--role Varchar(255) not null
--)

--Insert into Persons values
--('Ahmed Faraz' ,'ahmedfaraz@gmail.com','ahmed123$','admin'),
--('Ahmed' ,'ahmedfaraz1@gmail.com','ahmed1233$','student'),
--('Saba Sunawar','sabasunawar@gmail.com','saba123$','student'),
--('Amna Nadeem','amnanadeem@gmail.com','amna123$','librarian'),
--('Saba Rao','sabarao@gmail.com','sabarao123$','librarian'),
--('Amna Nadeem','amnanadeem1@gmail.com','amnaa123$','student')



--select * from Persons

--create table Books
--(
--bookId int identity(100,5) not null primary key,
--title varchar(255) not null,
--author varchar(255) not null,
--category varchar(255) not null,
--availablility varchar(255) not null default 'true'
--)

--Insert into  Books values 
--('Calculus','Saba','Mathematics','true'),
--('Probability','Amna','Mathematics','true'),
--('Stats','Ahmed','Mathematics','true'),
--('Design','Saba','Software Engineering','true'),
--('Architect','Amna','Software Engineering','true'),
--('Requirement Elicitation','Ahmed','Software Engineering','true'),
--('Processor','Ahmed','Computer Science','true'),
--('Electronics','Saba','Computer Science','true'),
--('Architectural Design','Amna','Computer Science','true'),
--('Requirement Analyser','Ahmed','Software Engineering','true')

select * from Books

--create table IssueRequests
--(
--id int identity (600,2) not null primary key,
--status varchar(255) default 'pending' not null,
--personId int,
--bookId int,
--CONSTRAINT FK_BookId FOREIGN KEY (bookId)
--REFERENCES Books(bookId),
--CONSTRAINT FK_PersonId FOREIGN KEY (personId)
--REFERENCES Persons(personId)
--)


--delete from Books
--delete from IssueRequests

select * from Persons where role='student'

--select * from Persons where role='librarian'

select * from Persons where role='admin'

--select personId, name, email from Persons where email='ahmedfaraz1@gmail.com'

delete from Persons where personId=11


delete from IssueRequests where id in (612,614)

select count(bookId) from IssueRequests where bookId='600' and status='pending'

update Books set availablility='true' where availablility='false'

--select email from Persons where email='ahmedfaraz@gmail.com'

--Insert into IssueRequests values ('pending',@personId,@bookId)


select * from Persons
select * from Books
select * from IssueRequests