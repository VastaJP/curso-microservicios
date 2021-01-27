import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profesor } from '../Registro/Model/profesor.model';


@Injectable({
  providedIn: 'root',
})
export class ProfesorService {

  baseUrl = environment.baseUrl;
  private profesor!: Profesor;
  profesorLista: Profesor[] = [];

  profesorSubject = new Subject<Profesor[]>();

  constructor(private router: Router, private http: HttpClient){}

  registrarProfesor(profe: Profesor): void{
    console.log(profe);
    this.http.post<Profesor>(this.baseUrl + 'Profesor/registrar',  profe) // le paso como parámetro la url + endpoint
  // tslint:disable-next-line: deprecation
      .subscribe((response) => {
        this.profesor = {
          nombre: response.nombre,
          apellido: response.apellido,
          edad: response.edad,
          fechaIncorporacion: response.fechaIncorporacion,
          materiaId: response.materiaId
        };
        this.router.navigate(['/']);
      });

  }

  cargarProfesores(): any {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    this.http.get<Profesor[]>(this.baseUrl + 'Profesor/GetProfesores')
      // tslint:disable-next-line: deprecation
      .subscribe( (data) => {
        this.profesorLista = data;
        this.profesorSubject.next([...this.profesorLista]);
      });
  }

  obtenerActualListener(): Observable<any>{
    return this.profesorSubject.asObservable();
  }

}
