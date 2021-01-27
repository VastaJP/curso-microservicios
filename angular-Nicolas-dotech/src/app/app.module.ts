import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppComponent } from './app.component';
import { AlumnosComponent } from './Listado/alumnos.component';
import { MateriasComponent } from './Listado/materias.component';
import { RegistroAlumnoComponent } from './Registro/registro-alumnos.component';
import { RegistroProfesorComponent } from './Registro/registro-profesor.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { InicioComponent } from './Inicio/inicio.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MateriaService } from './services/materia.service';
import { AlumnoService } from './services/alumno.service';
import { ProfesorService } from './services/profesor.service';

@NgModule({
  declarations: [
    AppComponent,
    AlumnosComponent,
    MateriasComponent,
    RegistroProfesorComponent,
    RegistroAlumnoComponent,
    InicioComponent,
  ],
  imports: [
    // agrego cosas para usar a futuro en la app
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    HttpClientModule, // con este, angular puede detectar los componentes web html dentro del proyecto
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  // tslint:disable-next-line: max-line-length
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'es-ES' }, MateriaService, AlumnoService, ProfesorService ], // acá agrego los servicios que necesito incluir en la app, los hace globales
  bootstrap: [AppComponent],
})
export class AppModule {}
