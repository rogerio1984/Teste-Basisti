import { Component, inject } from '@angular/core';
import { ILivroData } from '../../../interfaces/Livro';
import { HttpService } from '../../../services/http.service';
import { Observable } from 'rxjs';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconButton } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { ToastrService } from 'ngx-toastr';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-livro-list',
  standalone: true,
  imports: [
    MatTableModule,
    MatButtonModule,
    RouterLink,
    MatIconButton,
    MatIconModule,
    MatFormFieldModule,
    CommonModule,
  ],
  templateUrl: './livro-list.component.html',
  styleUrl: './livro-list.component.css',
})
export class LivroListComponent {
  //UserList: Observable<IUserData[]> | undefined;
  LivroList: ILivroData[] = [];
  httpService = inject(HttpService);
  router = inject(Router);
  toaster = inject(ToastrService);
  displayedColumns: string[] = [
    'codl',
    'titulo',
    'editora',
    'edicao',
    'autoresStr',
    'assuntosStr',
    'anoPublicacao',
    'valoresStr',
    'action',
  ];
  ngOnInit() {

    this.httpService.getAllLivros().subscribe((data) => {     
      console.log('retorno');     
      this.LivroList = data; 
      console.log(data);     
    });
  }
  editLivro(codl: number) {
    console.log(codl);
    this.router.navigateByUrl(`/livro/${codl}`);
  }
  DeleteLivro(codl: number) {
    console.log(codl);
    this.httpService.deleteLivro(codl).subscribe((data) => {
      console.log(data);
      this.toaster.success('Livro Deleted Successfully');
      this.ngOnInit();
    });
  }
  applyFilter(value: string) {
    value = value.trim(); // Remove whitespace
    value = value.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    // this.AutorList.filter = value;
  }
}
