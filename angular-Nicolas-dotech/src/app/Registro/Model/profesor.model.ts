import { Materia } from './materia.model';

export interface Profesor{
  nombre: string;
  apellido: string;
  edad: number;
  fechaIncorporacion: Date;
  materiaId: number;
}
