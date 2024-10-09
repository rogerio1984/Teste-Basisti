import { Component, inject } from '@angular/core';
import { IAssuntoData } from '../../../interfaces/Assunto';
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
  selector: 'app-assunto-list',
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
  templateUrl: './assunto-list.component.html',
  styleUrl: './assunto-list.component.css',
})
export class AssuntoListComponent {
  //UserList: Observable<IUserData[]> | undefined;
  AssuntoList: IAssuntoData[] = [];
  httpService = inject(HttpService);
  router = inject(Router);
  toaster = inject(ToastrService);
  displayedColumns: string[] = [
    'codAs',
    'descricao',
    'action',
  ];
  ngOnInit() {

    this.httpService.getAllAssuntos().subscribe((data) => {     
      console.log('retorno');     
      this.AssuntoList = data; 
      console.log(data);     
    });
  }
  editAssunto(codAs: number) {
    console.log(codAs);
    this.router.navigateByUrl(`/assunto/${codAs}`);
  }
  DeleteAssunto(codAs: number) {
    console.log(codAs);
    this.httpService.deleteAssunto(codAs).subscribe((data) => {
      console.log(data);
      this.toaster.success('Assunto Deleted Successfully');
      this.ngOnInit();
    });
  }
}
