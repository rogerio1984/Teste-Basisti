import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { HttpService } from '../../../services/http.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormsModule,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { IAssuntoData } from '../../../interfaces/Assunto';
import { DataComponent } from '../../data/data.component';

@Component({
  selector: 'app-assunto-form',
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
  templateUrl: './assunto-form.component.html',
  styleUrl: './assunto-form.component.css',
})
export class AssuntoFormComponent {
  formBuilder = inject(FormBuilder);
  httpService = inject(HttpService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  toster = inject(ToastrService);
  assuntoForm = this.formBuilder.group({
    descricao: ['', [Validators.required,Validators.maxLength(20)]],
  })
  codAs: number = 0;
  isEdit = false;
  ngOnInit() {
    this.codAs = this.route.snapshot.params['codAs'];
    if (this.codAs) {
      this.isEdit = true;
      this.httpService.getAssunto(this.codAs).subscribe((result) => {
        console.log(result);
        debugger
        this.assuntoForm.patchValue(result);
      });
    }
  }

  onSubmit() {
    console.log(this.assuntoForm.value);

     const assunto: IAssuntoData = {
      codAs:  this.codAs,
      descricao: this.assuntoForm.value.descricao!
    };

    if (this.isEdit) {
      this.httpService.updateAssunto(this.codAs, assunto).subscribe((data) => {
        console.log('Assunto updated successfully');
        this.toster.success('Assunto updated successfully');
        this.router.navigateByUrl('/assunto-list');
      });
    } else {
      this.httpService.createAssunto(assunto).subscribe((data) => {
        console.log('Assunto created successfully');
        this.toster.success('Assunto created successfully');
        this.router.navigateByUrl('/assunto-list');
      });
    }
  }
}
