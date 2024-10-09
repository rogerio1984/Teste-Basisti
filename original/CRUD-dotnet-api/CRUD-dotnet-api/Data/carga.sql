use basisti;

/*Inserindo assuntos*/
insert into assunto values('Romance');
insert into assunto values('Ficção Científica');
insert into assunto values('História');
insert into assunto values('Filosofia');
insert into assunto values('Infantil');
insert into assunto values('Política');

select * from assunto;

/* Inserindo autores*/
insert into autor values('Machado de Assis');
insert into autor values('George Orwell');
insert into autor values('Antoine de Saint-Exupéry');
select * from autor;

/*Inserindo livros e seus assuntos*/
insert into livro values(1,'Dom Casmurro','Editora Globo',3,2020);
insert into livro_assunto values(1,1);
insert into livro_autor values(1,1)


insert into livro values(2,'1984','Companhia das Letras',2,2019);
insert into livro_assunto values(2,2);
insert into livro_autor values(2,2)


insert into livro values(3,'O Pequeno Príncipe','Agir',5,2018);
insert into livro_assunto values(3,4);
insert into livro_assunto values(3,5);
insert into livro_autor values(3,3)


insert into FormaCompra values(1,'Balcão');
insert into FormaCompra values(2,'Internet');
insert into FormaCompra values(3,'Evento');


insert into Livro_FormaCompra values(1,1,50);
insert into Livro_FormaCompra values(2,1,60);
insert into Livro_FormaCompra values(3,1,150);
