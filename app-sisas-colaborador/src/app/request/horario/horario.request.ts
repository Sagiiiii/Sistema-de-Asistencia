export interface HorarioRequest {
  nombre?: string | null;
  estado?: number | null;
  tipo?: number | null;
  turno?: string | null;
  fechaInicio?: string | null;
  fechaFin?: Date | string | null;
  horaInicio?: string | null;
  horaFin?: string | null;
  horaAperturaIngreso?: string | null;
  horaCierreIngreso?: string | null;
  tolerancia?: string | null;
  descripcion?: string | null;
}
