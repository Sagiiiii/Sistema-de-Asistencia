import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

import { APP_NAME, SIDEBAR_ITEMS } from '../../../../core/constants/app.constants';
import { SidebarItem } from '../../../../core/models/sidebar-item.model';
import { LayoutService } from '../../../../core/services/layout.service';

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.scss'],
})
export class SidebarComponent implements OnInit {
  readonly layout = inject(LayoutService);
  readonly router = inject(Router);
  readonly items = SIDEBAR_ITEMS;
  readonly appName = APP_NAME;

  /** Submenú expandido (indice del item en SIDEBAR_ITEMS). */
  expandedIndex: number | null = null;

  ngOnInit(): void {
    this.autoExpandActiveMenu();
  }

  toggleSubmenu(index: number): void {
    this.expandedIndex = this.expandedIndex === index ? null : index;
  }

  isChildActive(item: SidebarItem): boolean {
    return !!item.children?.some((child) => this.router.url.startsWith(child.route));
  }

  private autoExpandActiveMenu(): void {
    const index = this.items.findIndex((item) => this.isChildActive(item));
    if (index >= 0) {
      this.expandedIndex = index;
    }
  }
}
