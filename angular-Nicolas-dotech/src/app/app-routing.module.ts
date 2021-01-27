import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { InicioComponent } from './Inicio/inicio.component';
import { AlumnosComponent } from './Listado/alumnos.component';
import { MateriasComponent } from './Listado/materias.component';
import { RegistroAlumnoComponent } from './Registro/registro-alumnos.component';
import { RegistroProfesorComponent } from './Registro/registro-profesor.component';

const routes: Routes = [
  { path: '', component: InicioComponent},
  { path: 'listado-materias', component: MateriasComponent},
  {path: 'listado-alumnos', component: AlumnosComponent},
  { path: 'registro-alumno', component: RegistroAlumnoComponent},
  {path: 'registro-profesor', component: RegistroProfesorComponent}
];

@NgModule({
imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]
})

export class AppRoutingModule{}
