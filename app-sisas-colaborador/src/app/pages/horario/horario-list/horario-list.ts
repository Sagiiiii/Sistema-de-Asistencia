import { Component, computed, inject, signal, viewChild } from '@angular/core';
import { Card } from 'primeng/card';
import { ButtonDirective } from 'primeng/button';
import { Ripple } from 'primeng/ripple';
import { Dialog } from 'primeng/dialog';
import { map, Observable } from 'rxjs';

import { PageHeader } from '../../../shared/components/page-header/page-header';
import { ListTable } from '../../../shared/components/list-table/list-table';
import {
  PageResult,
  TableAction,
  TableColumn,
  TableRequest,
} from '../../../shared/components/list-table/list-table.model';
import { AlertService } from '../../../shared/services/alert.service';
import { HorarioService } from '../../../core/services/horario/horario.service';
import { Horario, HorarioApi } from '../../../response/horario/horario.response';
import { HorarioRegister } from '../horario-register/horario-register';

@Component({
  selector: 'app-horario-list',
  imports: [PageHeader, Card, ListTable, ButtonDirective, Ripple, Dialog, HorarioRegister],
  templateUrl: './horario-list.html',
  styleUrls: ['./horario-list.scss'],
})
export class HorarioList {
  private readonly alert = inject(AlertService);
  private readonly horarioService = inject(HorarioService);

  private readonly listTable = viewChild.required(ListTable);

  protected readonly filterField = signal<'nombre' | 'descripcion'>('nombre');
  protected readonly filterText = signal('');

  protected readonly filters = computed(() => ({
    numFilter: this.filterField() === 'nombre' ? 1 : 2,
    textFilter: this.filterText().trim(),
    stateFilter: null as number | null,
  }));

  protected readonly registerVisible = signal(false);



  protected onFilterInput(event: Event): void {
    this.filterText.set((event.target as HTMLInputElement).value);
  }

  protected onFieldChange(event: Event): void {
    this.filterField.set((event.target as HTMLSelectElement).value as 'nombre' | 'descripcion');
  }

  columns: TableColumn<Horario>[] = [
    { field: 'idHorario', header: 'ID', type: 'number', digitsInfo: '1.0-0', sortable: true, align: 'center', width: '90px' },
    { field: 'nombre', header: 'Horario', sortable: true },
    { field: 'fechaInicio', header: 'Fecha Inicio', sortable: true },
    { field: 'fechaFin', header: 'Fecha Fin', sortable: true },
    { field: 'horaInicio', header: 'Hora Inicio', sortable: true },
    { field: 'horaFin', header: 'Hora Fin', sortable: true },
    { field: 'horaAperturaIngreso', header: 'Hora Apertura Ingreso', sortable: true },
    { field: 'horaCierreIngreso', header: 'Hora Cierre Ingreso', sortable: true },
    { field: 'tolerancia', header: 'Tolerancia', sortable: true },
    { field: 'descripcion', header: 'Descripción', sortable: true },
    {
      field: 'stateHorario',
      header: 'Estado',
      type: 'badge',
      align: 'center',
      width: '110px',
      badge: {
        label: { Activo: 'Activo', Inactivo: 'Inactivo' },
        severity: { Activo: 'success', Inactivo: 'secondary' },
      },
    },
  ];

  actions: TableAction<Horario>[] = [
    { icon: 'pi pi-pencil', label: 'Editar', severity: 'primary' },
    { icon: 'pi pi-trash', label: 'Eliminar', severity: 'danger', visible: (row) => row.stateHorario === 'Activo' },
  ];

  loader = (req: TableRequest): Observable<PageResult<Horario>> => {
    const f = (req.filters ?? {}) as { numFilter?: number; textFilter?: string; stateFilter?: number | null };

    return this.horarioService
      .GetAll(
        req.pageSize,
        req.sortField ?? 'idHorario',
        req.sortOrder === 'desc' ? 'desc' : 'asc',
        req.page,
        {
          numFilter: f.numFilter ?? 0,
          textFilter: f.textFilter ?? '',
          stateFilter: f.stateFilter ?? null,
        },
      )
      .pipe(
        map((res: HorarioApi) => ({
          totalRecords: res.data?.totalRecords ?? 0,
          items: res.data?.items ?? [],
        })),
      );
  };

 

  

  onNew(): void {
    this.registerVisible.set(true);
  }

  onSaved(): void {
    this.registerVisible.set(false);
    this.listTable().reload();
  }

  onAction(event: { action: TableAction<Horario>; row: Horario }): void {
    if (event.action.label === 'Eliminar') {
      this.alert.error('Eliminar', `¿Eliminar el horario ${event.row.nombre}?`);
    } else {
      this.alert.success('Editar', `Editando el horario ${event.row.nombre}`);
    }
  }
}
