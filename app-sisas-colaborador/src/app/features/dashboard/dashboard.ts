import { Component, signal } from '@angular/core';
import { Card } from 'primeng/card';
import { TableModule } from 'primeng/table';
import { Tag } from 'primeng/tag';
import { Button } from 'primeng/button';

import { PageHeader } from '../../shared/components/page-header/page-header';

interface Stat {
  label: string;
  value: string;
  delta: string;
  positive: boolean;
  icon: string;
  accent: string;
}

interface Activity {
  user: string;
  action: string;
  time: string;
  status: 'success' | 'warning' | 'danger' | 'info';
}

@Component({
  selector: 'app-dashboard',
  imports: [PageHeader, Card, TableModule, Tag, Button],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.scss'],
})
export class Dashboard {
  readonly stats: Stat[] = [
    { label: 'Usuarios activos', value: '1,284', delta: '+12%', positive: true, icon: 'pi pi-users', accent: 'bg-primary-50 text-primary-600' },
    { label: 'Ventas del mes', value: 'S/ 84,230', delta: '+8%', positive: true, icon: 'pi pi-dollar', accent: 'bg-emerald-50 text-emerald-600' },
    { label: 'Órdenes pendientes', value: '47', delta: '-3%', positive: false, icon: 'pi pi-clock', accent: 'bg-amber-50 text-amber-600' },
    { label: 'Tickets abiertos', value: '12', delta: '+2', positive: false, icon: 'pi pi-life-ring', accent: 'bg-rose-50 text-rose-600' },
  ];

  readonly activities = signal<Activity[]>([
    { user: 'María López', action: 'Creó la orden #1024', time: 'hace 5 min', status: 'success' },
    { user: 'Carlos Ruiz', action: 'Actualizó el perfil de un cliente', time: 'hace 12 min', status: 'info' },
    { user: 'Ana Torres', action: 'Rechazó el pago #8810', time: 'hace 30 min', status: 'danger' },
    { user: 'Pedro Sánchez', action: 'Exportó el reporte de ventas', time: 'hace 1 h', status: 'warning' },
    { user: 'Sofía Castro', action: 'Registró un nuevo usuario', time: 'hace 2 h', status: 'success' },
  ]);

  getSeverity(status: Activity['status']): 'success' | 'info' | 'warn' | 'danger' {
    return status === 'warning' ? 'warn' : status;
  }
}
