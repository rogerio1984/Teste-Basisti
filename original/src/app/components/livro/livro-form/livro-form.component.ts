import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatSelectModule  } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { HttpService } from '../../../services/http.service';
import { ToastrService } from 'ngx-toastr';

import {  
  FormBuilder,
  FormsModule,
  Validators,
  ReactiveFormsModule,
  FormGroup,
} from '@angular/forms';
import { ILivroData } from '../../../interfaces/Livro';
import { IAssuntoData } from '../../../interfaces/Assunto';
import { IAutorData } from '../../../interfaces/Autor';
import { DataComponent } from '../../data/data.component';

@Component({
  selector: 'app-autor-form',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
  ],
  templateUrl: './livro-form.component.html',
  styleUrl: './livro-form.component.css',
})
export class LivroFormComponent {
  formBuilder = inject(FormBuilder);
  httpService = inject(HttpService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  toster = inject(ToastrService);

  assuntoList: IAssuntoData[] = [];
  autorList: IAutorData[] = [];
  assuntoSelecionado = '';
  autorSelecionado = '';

  livroForm = this.formBuilder.group({
    codl: [0, [Validators.required,Validators.pattern('^[0-9]*$'),Validators.maxLength(10)]]!,
    titulo: ['',  [Validators.required,Validators.maxLength(40)]]!,
    editora: ['',  [Validators.required,Validators.maxLength(40)]]!,
    assuntosStr: ['', Validators.required]!,
    autoresStr: ['', Validators.required]!,
    edicao: [0, [Validators.required,Validators.pattern('^[0-9]*$'),Validators.maxLength(2)]]!,
    anoPublicacao: ['', 
      [
        Validators.required,
        Validators.pattern('^[0-9]*$'),
        Validators.required,Validators.maxLength(4),
        Validators.required,Validators.minLength(4)
      ]]!,
  });


  codlEdit: number = 0;
  isEdit = false;
  
  ngOnInit() {
    this.codlEdit = this.route.snapshot.params['codl'];
    if (this.codlEdit) {
      this.isEdit = true;
      this.httpService.getLivro(this.codlEdit).subscribe((result) => {
        console.log(result);          
        this.livroForm.patchValue(result);
        this.assuntoSelecionado = result.assuntosStr;
        this.autorSelecionado = result.autoresStr;
      });
     
    }
    
    this.httpService.getAllAssuntos().subscribe((data) => {     
      console.log('retorno');     
      this.assuntoList = data; 
      console.log(data);     
    });

    this.httpService.getAllAutores().subscribe((data) => {     
      console.log('retorno');     
      this.autorList = data; 
      console.log(data);     
    });
  }

  onSubmit() {
    console.log(this.livroForm.value);


     const livro: ILivroData = {
      codl:  this.livroForm.value.codl!,
      titulo: this.livroForm.value.titulo!,
      editora: this.livroForm.value.editora!,
      autoresStr:this.livroForm.value.autoresStr!,
      assuntosStr:this.livroForm.value.assuntosStr!, 
      valoresStr:'',      
      edicao: this.livroForm.value.edicao!,
      anoPublicacao: this.livroForm.value.anoPublicacao!
    };

    if (this.isEdit) {
      this.httpService.updateLivro(this.codlEdit, livro).subscribe((data) => {
        console.log('Livro updated successfully');
        this.toster.success('Livro updated successfully');
        this.router.navigateByUrl('/livro-list');
      });
    } else {
      this.httpService.createLivro(livro).subscribe((data) => {
        console.log('livro created successfully');
        this.toster.success('Livro created successfully');
        this.router.navigateByUrl('/livro-list');
      });
    }
  }
}
