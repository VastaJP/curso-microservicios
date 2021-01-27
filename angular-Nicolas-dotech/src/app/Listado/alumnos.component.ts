import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { Alumno } from '../Registro/Model/alumno.model';
import { AlumnoService } from '../services/alumno.service';

@Component({
  selector: 'app-listado-alumnos',
  templateUrl: './alumnos.component.html',
  styleUrls: ['./alumnos.component.css'],
})


export class AlumnosComponent implements OnInit, OnDestroy, AfterViewInit{

  desplegarColumnas: string[] = ['Nombre', 'Apellido', 'FechaNacimiento', 'Materia'];
  dataSource = new MatTableDataSource<Alumno>();
  sort = 'Apellido';
  filterValue: any;
  timeout: any = null;
  sortDirection = 'asc';

  @ViewChild(MatSort) ordenamiento!: MatSort;

  private alumnosSubscription!: Subscription;

  constructor(private alumnosService: AlumnoService) {}

  alumno: Alumno ;

  alumnos: [];

  ordenarColumna(event: any): void{
    this.sort = event.active;
    this.sortDirection = event.direction;
    this.alumnosService.cargarAlumnos();
  }

  hacerFiltro(event: any): void{
    clearTimeout(this.timeout);
    const $this = this;
    this.timeout = setTimeout(() => {
      if (event.keycode !== 13) {
        const filterValueLocal = {
          propiedad: 'Nombre',
          valor: event.target.value,
        };

        $this.filterValue = filterValueLocal;

        $this.alumnosService.cargarAlumnos();
      }
    }, 1000);
    this.dataSource.filter = (event.target as HTMLInputElement).value;
  }

  ngAfterViewInit(): void{
    this.dataSource.sort = this.ordenamiento;
  }

  ngOnInit(): void
  {
    this.alumnosService.cargarAlumnos();
    this.alumnosSubscription = this.alumnosService.obtenerActualListener()
      // tslint:disable-next-line: deprecation
      .subscribe( (alumnos: Alumno[]) => {
        this.dataSource.data = alumnos;
        console.log(alumnos);
      });
  }

  ngOnDestroy(): void {
    this.alumnosSubscription.unsubscribe();
  }

}
