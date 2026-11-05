import { Component, inject } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Avatar } from 'primeng/avatar';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';
import { Menu } from 'primeng/menu';

import { LayoutService } from '../../../../core/services/layout.service';

@Component({
  selector: 'app-topbar',
  imports: [Button, Divider, Avatar, Menu],
  templateUrl: './topbar.html',
  styleUrls: ['./topbar.scss'],
})
export class TopbarComponent {
  readonly layout = inject(LayoutService);

  readonly userMenuItems: MenuItem[] = [
    { label: 'Mi perfil', icon: 'pi pi-user', routerLink: '/settings' },
    { label: 'Configuración', icon: 'pi pi-cog', routerLink: '/settings' },
  ];
}
