import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDatepicker } from '@angular/material/datepicker';
import { AlumnoService } from '../services/alumno.service';


@Component({
  selector: 'app-registro-alumnos',
  templateUrl: './registro-alumnos.component.html',
  styleUrls: ['./registro-alumnos.component.css']
})


export class RegistroAlumnoComponent implements OnInit{

  // Datos del form a registrar
  nombreForm: string;
  apellidoForm: string;
  fechaNacForm: string;
  @ViewChild(MatDatepicker) picker!: MatDatepicker<Date>;
  materiaForm: string;


  // declaro el constructor y le paso por parámetro el service del registro para luego acceder a los métodos
  constructor(private alumnoService: AlumnoService ){}


  ngOnInit(): void {}
  // metodo que registra un alumno. Lo trae desde el registrar.service.ts
  registrarAlumno(form: NgForm): void{
    this.alumnoService.registrarAlumno({
    nombre: this.nombreForm,
    apellido: this.apellidoForm,
    fechaNacimiento: new Date(this.fechaNacForm),
    materiaId: this.materiaForm,
    });
  }
}

