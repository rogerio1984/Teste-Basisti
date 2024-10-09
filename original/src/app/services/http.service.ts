import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IAutorData } from '../interfaces/Autor';
import { IRelatorioData } from '../interfaces/Relatorio';
import { ILivroData } from '../interfaces/Livro';
import { IAssuntoData } from '../interfaces/Assunto';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  apiUrl = 'https://localhost:7208';
  http = inject(HttpClient);
  constructor() {}

  //servicoes de autores
  getReport() {
    return this.http.get<IRelatorioData[]>(this.apiUrl + '/api/Autor/GetReport');
  }
  getAllAutores() {
    return this.http.get<IAutorData[]>(this.apiUrl + '/api/Autor');
  }
  createAutor(data: IAutorData) {
    return this.http.post(this.apiUrl + '/api/Autor', data);
  }
  getAutor(CodAu: number) {
    return this.http.get<IAutorData>(this.apiUrl + '/api/Autor/' + CodAu);
  }
  updateAutor(CodAu: number, data: IAutorData) {
    return this.http.put(this.apiUrl + '/api/Autor/' + CodAu, data);
  }
  deleteAutor(CodAu: number) {
    return this.http.delete(this.apiUrl + '/api/Autor/' + CodAu);
  }

  //servicoes de assuntos
  getAllAssuntos() {
    return this.http.get<IAssuntoData[]>(this.apiUrl + '/api/Assunto');
  }
  createAssunto(data: IAssuntoData) {
    return this.http.post(this.apiUrl + '/api/Assunto', data);
  }
  getAssunto(codAs: number) {
    return this.http.get<IAssuntoData>(this.apiUrl + '/api/Assunto/' + codAs);
  }
  updateAssunto(codAs: number, data: IAssuntoData) {
    return this.http.put(this.apiUrl + '/api/Assunto/' + codAs, data);
  }
  deleteAssunto(codAs: number) {
    return this.http.delete(this.apiUrl + '/api/Assunto/' + codAs);
  }

  
  //servicoes de livros
  getAllLivros() {
    return this.http.get<ILivroData[]>(this.apiUrl + '/api/Livro');
  }
  createLivro(data: ILivroData) {
    return this.http.post(this.apiUrl + '/api/Livro', data);
  }
  getLivro(codL: number) {
    return this.http.get<ILivroData>(this.apiUrl + '/api/Livro/' + codL);
  }
  updateLivro(codL: number, data: ILivroData) {
    return this.http.put(this.apiUrl + '/api/Livro/' + codL, data);
  }
  deleteLivro(codL: number) {
    return this.http.delete(this.apiUrl + '/api/Livro/' + codL);
  }
}
