import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { HttpService } from '../../../services/http.service';
import { ToastrService } from 'ngx-toastr';
import {
  FormBuilder,
  FormsModule,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { IAutorData } from '../../../interfaces/Autor';
import { DataComponent } from '../../data/data.component';

@Component({
  selector: 'app-autor-form',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './autor-form.component.html',
  styleUrl: './autor-form.component.css',
})
export class AutorFormComponent {
  formBuilder = inject(FormBuilder);
  httpService = inject(HttpService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  toster = inject(ToastrService);
  autorForm = this.formBuilder.group({
    nome: ['', [Validators.required,Validators.maxLength(40)]],
  })
  codAu: number = 0;
  isEdit = false;
  ngOnInit() {
    this.codAu = this.route.snapshot.params['codAu'];
    if (this.codAu) {
      this.isEdit = true;
      this.httpService.getAutor(this.codAu).subscribe((result) => {
        console.log(result);
        debugger
        this.autorForm.patchValue(result);
      });
    }
  }


  onSubmit() {
    console.log(this.autorForm.value);

     const autor: IAutorData = {
      codAu:  this.codAu,
      nome: this.autorForm.value.nome!
    };

    if (this.isEdit) {
      this.httpService.updateAutor(this.codAu, autor).subscribe((data) => {
        console.log('Autor updated successfully');
        this.toster.success('Autor updated successfully');
        this.router.navigateByUrl('/autor-list');
      });
    } else {
      this.httpService.createAutor(autor).subscribe((data) => {
        console.log('Autor created successfully');
        this.toster.success('Autor created successfully');
        this.router.navigateByUrl('/autor-list');
      });
    }
  }
}
