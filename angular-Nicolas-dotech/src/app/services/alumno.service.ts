import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Alumno } from '../Registro/Model/alumno.model';


@Injectable({
  providedIn: 'root',
})
export class AlumnoService {

  baseUrl = environment.baseUrl;
  private alumno!: Alumno;
  alumnosLista: Alumno[] = [];

  alumnoSubject = new Subject<Alumno[]>();

  constructor(private router: Router, private http: HttpClient){}

  registrarAlumno( alumn: Alumno): void{
    console.log(alumn);
    this.http.post<Alumno>(this.baseUrl + 'Alumno/registrar',  alumn) // le paso como parámetro la url + endpoint
  // tslint:disable-next-line: deprecation
      .subscribe((response) => {
        this.alumno = {
          nombre: response.nombre,
          apellido: response.apellido,
          fechaNacimiento: response.fechaNacimiento,
          materiaId: response.materiaId,
        };
        this.router.navigate(['/']);
      });

  }

  cargarAlumnos(): any {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    this.http.get<Alumno[]>(this.baseUrl + 'Alumno/GetAlumnos')
      // tslint:disable-next-line: deprecation
      .subscribe( (data) => {
        this.alumnosLista = data;
        this.alumnoSubject.next([...this.alumnosLista]);
      });
  }

  obtenerActualListener(): Observable<any>{
    return this.alumnoSubject.asObservable();
  }

}
