import { Routes } from '@angular/router';
import { AutorListComponent } from './components/autor/autor-list/autor-list.component';
import { AssuntoListComponent } from './components/assunto/assunto-list/assunto-list.component';
import { LivroListComponent } from './components/livro/livro-list/livro-list.component';

import path from 'path';

import { AutorFormComponent } from './components/autor/autor-form/autor-form.component';
import { AssuntoFormComponent } from './components/assunto/assunto-form/assunto-form.component';
import { LivroFormComponent } from './components/livro/livro-form/livro-form.component';

import { DefaultComponent } from './components/default.component';

export const routes: Routes = [
  {
    path: '',
    component:DefaultComponent
  },
  {
    path: 'default',
    component:AutorListComponent
  },
  {
    path: 'autor-list',
    component:AutorListComponent
  },
  {
    path:'create-autor',
    component:AutorFormComponent

  },
  {
    path:'autor/:codAu',
    component:AutorFormComponent
  },
  {
    path: 'assunto-list',
    component:AssuntoListComponent
  },
  {
    path:'create-assunto',
    component:AssuntoFormComponent

  },
  {
    path:'assunto/:codAs',
    component:AssuntoFormComponent
  },
  
  {
    path: 'livro-list',
    component:LivroListComponent
  },
  {
    path:'create-livro',
    component:LivroFormComponent

  },
  {
    path:'livro/:codl',
    component:LivroFormComponent
  },
];
