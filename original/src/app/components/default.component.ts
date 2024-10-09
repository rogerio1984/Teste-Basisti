import { Component, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../services/http.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconButton } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { ToastrService } from 'ngx-toastr';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { IRelatorioData } from '../interfaces/Relatorio';


@Component({
  selector: 'app-default',
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
  templateUrl: './default.component.html',
  styleUrl: './default.component.css',
})


export class DefaultComponent {  
  router = inject(Router);
  toaster = inject(ToastrService);
  httpService = inject(HttpService);

  relatorioList: IRelatorioData[] = [];

  ngOnInit() {
  
    this.httpService.getReport().subscribe((data) => {     
      console.log('retorno');     
      this.relatorioList = data; 
      console.log(data);     
    });
  }

  getAutorCount(autor: string): number {
    return this.relatorioList.filter(d => d.autor === autor).length;
  }
  
}
