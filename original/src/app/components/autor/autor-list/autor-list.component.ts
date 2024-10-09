import { Component, inject } from '@angular/core';
import { IAutorData } from '../../../interfaces/Autor';
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
  selector: 'app-autor-list',
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
  templateUrl: './autor-list.component.html',
  styleUrl: './autor-list.component.css',
})
export class AutorListComponent {
  //UserList: Observable<IUserData[]> | undefined;
  AutorList: IAutorData[] = [];
  httpService = inject(HttpService);
  router = inject(Router);
  toaster = inject(ToastrService);
  displayedColumns: string[] = [
    'codAu',
    'nome',
    'action',
  ];
  ngOnInit() {

    this.httpService.getAllAutores().subscribe((data) => {     
      console.log('retorno');     
      this.AutorList = data; 
      console.log(data);     
    });
  }
  // ngOnInit(): void {
  //   this.AutorList = this.httpService.getAllAutores();
  // }
  editAutor(codAu: number) {
    console.log(codAu);
    this.router.navigateByUrl(`/autor/${codAu}`);
  }
  DeleteAutor(codAu: number) {
    console.log(codAu);
    this.httpService.deleteAutor(codAu).subscribe((data) => {
      console.log(data);
      this.toaster.success('Autor Deleted Successfully');
      this.ngOnInit();
    });
  }
  applyFilter(value: string) {
    value = value.trim(); // Remove whitespace
    value = value.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    // this.AutorList.filter = value;
  }
}
