export interface SidebarItem {
  /** Ruta de navegación del enlace. */
  route: string;
  /** Etiqueta visible en el menú. */
  label: string;
  /** Icono (clase CSS de PrimeIcons, ej: 'pi pi-home'). */
  icon: string;
  /** Si el enlace debe estar deshabilitado. */
  disabled?: boolean;
  /** Submenús anidados (1 nivel de profundidad soportado). */
  children?: SidebarItem[];
}
