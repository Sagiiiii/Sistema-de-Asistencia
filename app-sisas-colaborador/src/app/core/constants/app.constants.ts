import { SidebarItem } from '../models/sidebar-item.model';
import { environment } from '../../../environments/environment';

/**
 * Configuración central del menú de navegación.
 * Agrega o edita las entradas aquí para reflejar los cambios en el sidebar.
 */
export const SIDEBAR_ITEMS: SidebarItem[] = [
  {
    route: '/dashboard',
    label: 'Dashboard',
    icon: 'pi pi-home',
  },
  {
    route: '/horario',
    label: 'Horarios',
    icon: 'pi pi-calendar-plus',
  },
  {
    route: '/products',
    label: 'Productos',
    icon: 'pi pi-shopping-bag',
    children: [
      { route: '/products/list', label: 'Listado', icon: 'pi pi-th-large' },
      { route: '/products/categories', label: 'Categorías', icon: 'pi pi-tags' },
    ],
  },
  {
    route: '/reports',
    label: 'Reportes',
    icon: 'pi pi-chart-bar',
    children: [
      { route: '/reports/sales', label: 'Ventas', icon: 'pi pi-dollar' },
      { route: '/reports/analytics', label: 'Analítica', icon: 'pi pi-wave-pulse' },
    ],
  }
  
];

export const APP_NAME = environment.appName ;
export const APP_VERSION = '0.1.0';
