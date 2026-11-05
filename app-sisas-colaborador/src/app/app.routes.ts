import { Routes } from '@angular/router';

import { AdminLayout } from './layout/admin-layout/admin-layout';

export const routes: Routes = [
  {
    path: '',
    component: AdminLayout,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: 'dashboard',
        loadChildren: () => import('./features/dashboard/dashboard.routes').then((m) => m.dashboardRoutes),
      },
      {
        path: 'horario',
        loadComponent: () => import('./pages/horario/horario-list/horario-list').then((m) => m.HorarioList),
        data: { title: 'Horarios' },
      },
      {
        path: 'products/list',
        loadComponent: () =>
          import('./shared/components/placeholder-page/placeholder-page').then((m) => m.PlaceholderPage),
        data: { title: 'Productos' },
      },
      {
        path: 'products/categories',
        loadComponent: () =>
          import('./shared/components/placeholder-page/placeholder-page').then((m) => m.PlaceholderPage),
        data: { title: 'Categorías' },
      },
      {
        path: 'reports/sales',
        loadComponent: () =>
          import('./shared/components/placeholder-page/placeholder-page').then((m) => m.PlaceholderPage),
        data: { title: 'Ventas' },
      },
      {
        path: 'reports/analytics',
        loadComponent: () =>
          import('./shared/components/placeholder-page/placeholder-page').then((m) => m.PlaceholderPage),
        data: { title: 'Analítica' },
      }
      
    ],
  },
  {
    path: '**',
    loadComponent: () => import('./features/not-found/not-found').then((m) => m.NotFound),
  },
];
