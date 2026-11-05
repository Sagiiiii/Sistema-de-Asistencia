import { TemplateRef } from '@angular/core';

export type TableSortOrder = 'asc' | 'desc' | '';

export type TableColumnType =
  | 'text'
  | 'number'
  | 'currency'
  | 'date'
  | 'boolean'
  | 'badge'
  | 'template'
  | 'action';

export type TableBadgeSeverity = 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';

export interface TableColumn<T> {
  /** Propiedad del registro (o clave) que llena la columna. */
  field: keyof T | string;
  /** Texto del encabezado. */
  header: string;
  /** Tipo de renderizado de la celda. Por defecto: text. */
  type?: TableColumnType;
  /** Habilita el orden por esta columna. */
  sortable?: boolean;
  /** Ancho en px o % (ej: '120px'). */
  width?: string;
  /** Alineación del contenido. */
  align?: 'left' | 'center' | 'right';
  /** Código de moneda para type=currency (PEN, USD, ...). Por defecto: PEN. */
  currency?: string;
  /** Formato de Angular DatePipe para type=date. Por defecto: dd/MM/yyyy. */
  dateFormat?: string;
  /** Formato de dígitos para type=number. Por defecto: 1.2-2. */
  digitsInfo?: string;
  /** Etiquetas y severidades para type=badge. */
  badge?: {
    label: Record<string, string>;
    severity?: Record<string, TableBadgeSeverity>;
  };
  /** Template personalizado para type=template (contexto: $implicit = fila). */
  template?: TemplateRef<{ $implicit: T }>;
  /** Clases extra en el <th> y las celdas. */
  bodyClass?: string;
}

export interface TableRequest {
  /** Página actual, empezando en 1. */
  page: number;
  pageSize: number;
  sortField?: string;
  sortOrder: TableSortOrder;
  /** Filtros externos libres. */
  filters?: unknown;
}

export interface PageResult<T> {
  totalRecords: number;
  items: T[];
}

export interface TableAction<T> {
  icon: string;
  label: string;
  severity?: TableBadgeSeverity | 'primary';
  /** Oculta el botón según la fila. */
  visible?: (row: T) => boolean;
}

export interface TableActionEvent<T> {
  action: TableAction<T>;
  row: T;
}

export interface TablePageEvent {
  first?: number;
  rows?: number;
}

export interface TableSortEvent {
  field?: string;
  order?: number;
}
