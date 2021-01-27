import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { Materia } from '../Registro/Model/materia.model';
import { Profesor } from '../Registro/Model/profesor.model';
import { MateriaService } from '../services/materia.service';
import { ProfesorService } from '../services/profesor.service';


@Component({
  selector: 'app-listado-materias',
  templateUrl: './materias.component.html',
  styleUrls: ['./materias.component.css'],
})

export class MateriasComponent implements OnInit, OnDestroy, AfterViewInit{

    profesor: Profesor;
    profesores: [];

    materia: Materia;
    materias: [];

    private materiasSubscription!: Subscription;
    private profesorSubscription!: Subscription;

    dataSourceMateria = new MatTableDataSource<Materia>();
    dataSourceProfesor = new MatTableDataSource<Profesor>();

    desplegarColumnasMaterias: string[] = ['Nombre', 'Descripcion', 'ProfesorId'];
    desplegarColumnasProfesores: string[] = ['Nombre', 'Apellido', 'Edad', 'FechaIncorporacion', 'MateriaId'];

    timeoutMaterias: any = null;
    timeoutProfesores: any = null;

    filterValueMaterias: any;
    filterValueProfesores: any;

  constructor(private materiaService: MateriaService, private profesorService: ProfesorService) {}


  hacerFiltroMaterias(event: any): void{
    clearTimeout(this.timeoutMaterias);
    const $this = this;
    this.timeoutMaterias = setTimeout(() => {
      if (event.keycode !== 13) {
        const filterValueLocalMaterias = {
          propiedad: 'Nombre',
          valor: event.target.value,
        };

        $this.filterValueMaterias = filterValueLocalMaterias;

        $this.materiaService.cargarMaterias();
      }
    }, 1000);
    this.dataSourceMateria.filter = (event.target as HTMLInputElement).value;
  }

  hacerFiltroProfesor(event: any): void{
    clearTimeout(this.timeoutProfesores);
    const $this = this;
    this.timeoutProfesores = setTimeout(() => {
      if (event.keycode !== 13) {
        const filterValueLocalProfesores = {
          propiedad: 'Nombre',
          valor: event.target.value,
        };

        $this.filterValueProfesores = filterValueLocalProfesores;

        $this.profesorService.cargarProfesores();
      }
    }, 1000);
    this.dataSourceProfesor.filter = (event.target as HTMLInputElement).value;
  }

  ngAfterViewInit(): void{
  }

  //
  ngOnInit(): void {
    this.materiaService.cargarMaterias();
    this.materiasSubscription = this.materiaService.obtenerActualListener()
      // tslint:disable-next-line: deprecation
      .subscribe( (materias: Materia[]) => {
        this.dataSourceMateria.data = materias;
      });
    this.profesorService.cargarProfesores();
    this.profesorSubscription = this.profesorService.obtenerActualListener()
      // tslint:disable-next-line: deprecation
      .subscribe( (profesores: Profesor[]) => {
        this.dataSourceProfesor.data = profesores;
    });
  }

  ngOnDestroy(): void{
    this.materiasSubscription.unsubscribe();
    this.profesorSubscription.unsubscribe();
  }

}



