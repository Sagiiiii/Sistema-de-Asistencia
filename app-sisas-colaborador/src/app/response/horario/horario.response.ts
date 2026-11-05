export interface ApiResponse<T> {
  isSuccess: boolean;
  data: T;
  message: string | null;
  errors: unknown;
}

export interface Horario {
  idHorario?: number;
  categoriaHorarioId?: number;
  nombre?: string;
  tipo?: number | string;
  turno?: string;
  estado?: number;
  stateHorario?: string;
  fechaInicio?: string;
  fechaFin?: string;
  horaInicio?: string;
  horaFin?: string;
  horaAperturaIngreso?: string;
  horaCierreIngreso?: string;
  tolerancia?: string;
  descripcion?: string;
  state?: number;
  estadoText?: string;
}

export interface HorarioList {
  items: Horario[];
  totalRecords: number;
}

export type HorarioApi = ApiResponse<HorarioList>;
