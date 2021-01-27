import { Profesor } from './profesor.model';

export interface Materia{
  materiaId: number;
  nombre: string;
  descripcion: string;
  profesorId: Profesor;
}
