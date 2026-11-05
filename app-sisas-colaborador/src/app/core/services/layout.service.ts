import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class LayoutService {
  /** Sidebar abierto en móvil (overlay). */
  readonly mobileOpen = signal(false);

  toggleMobile(): void {
    this.mobileOpen.update((value) => !value);
  }

  closeMobile(): void {
    this.mobileOpen.set(false);
  }
}
