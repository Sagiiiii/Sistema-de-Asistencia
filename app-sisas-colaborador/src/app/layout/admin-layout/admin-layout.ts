import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { SidebarComponent } from './components/sidebar/sidebar';
import { TopbarComponent } from './components/topbar/topbar';
import { LayoutService } from '../../core/services/layout.service';

@Component({
  selector: 'app-admin-layout',
  imports: [RouterOutlet, SidebarComponent, TopbarComponent],
  templateUrl: './admin-layout.html',
  styleUrls: ['./admin-layout.scss'],
})
export class AdminLayout {
  constructor(readonly layout: LayoutService) {}

  get year(): number {
    return new Date().getFullYear();
  }
}
