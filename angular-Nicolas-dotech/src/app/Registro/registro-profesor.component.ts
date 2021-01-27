import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatSelectChange } from '@angular/material/select';
import {MatSelectModule} from '@angular/material/select';
import { Subscription } from 'rxjs';
import { MateriaService } from '../services/materia.service';
import { ProfesorService } from '../services/profesor.service';
import { Materia } from './Model/materia.model';

@Component({
  selector: 'app-registro-profesor',
  templateUrl: './registro-profesor.component.html',
  styleUrls: ['./registro-profesor.component.css'],
})
export class RegistroProfesorComponent implements OnInit {
  // Datos formulario registro
  nombreForm: string;
  apellidoForm: string;
  edadForm: number;
  fechaIncForm: Date;

  @ViewChild(MatDatepicker) picker!: MatDatepicker<Date>;

  // Datos select input
  selectMateriaId: number;
  selectMateriaNombre: string;

  materias: Materia[];

  private materiaSubscription!: Subscription;

  // declaro el constructor y le paso por parámetro el service del registro para luego acceder a los métodos
  constructor(
    private materiaService: MateriaService,
    private profesorService: ProfesorService,
  ) {}

  ngOnInit(): void {
    this.materiaService.cargarMaterias();
    this.materiaSubscription = this.materiaService
      .obtenerActualListener()
      // tslint:disable-next-line: deprecation
      .subscribe((materiasConsulta: Materia[]) => {
        this.materias = materiasConsulta;
      });
  }

  // metodo que registra un objeto profesor. Lo trae desde el service
  registrarProfesor(form: NgForm): void {
    console.log(this.edadForm);
    this.profesorService.registrarProfesor({
      nombre: this.nombreForm,
      apellido: this.apellidoForm,
      edad: this.edadForm,
      fechaIncorporacion: this.fechaIncForm,
      materiaId: this.selectMateriaId,
    });
  }

  // metodo que registra un objeto profesor. Lo trae desde el service

  selected(event: MatSelectChange): void {
    console.log(this.selectMateriaId);
    // this.selectMateriaNombre = (event.source.selected as MatOption).viewValue;
  }

}
