import { Routes } from '@angular/router';

export const usersRoutes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('../../shared/components/placeholder-page/placeholder-page').then((m) => m.PlaceholderPage),
    data: { title: 'Usuarios' },
  },
];
