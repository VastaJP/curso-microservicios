import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Materia } from '../Registro/Model/materia.model';


@Injectable({
  providedIn: 'root',
})
export class MateriaService {

  baseUrl = environment.baseUrl;
  private materia!: Materia;
  materiaLista: Materia[] = [];

  materiaSubject = new Subject<Materia[]>();

  constructor(private router: Router, private http: HttpClient){}

  cargarMaterias(): any {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    this.http.get<Materia[]>(this.baseUrl + 'Materia/GetMaterias')
      // tslint:disable-next-line: deprecation
      .subscribe( (data) => {
        this.materiaLista = data;
        this.materiaSubject.next([...this.materiaLista]);
      });
  }

  obtenerActualListener(): Observable<any>{
    return this.materiaSubject.asObservable();
  }

}
