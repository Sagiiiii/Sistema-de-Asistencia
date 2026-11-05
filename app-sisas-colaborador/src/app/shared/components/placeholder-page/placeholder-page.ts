import { Component, computed, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Card } from 'primeng/card';

import { PageHeader } from '../page-header/page-header';

/**
 * Página de ejemplo para rutas en construcción.
 * Toma el título desde la data de la ruta.
 */
@Component({
  selector: 'app-placeholder-page',
  imports: [PageHeader, Card],
  templateUrl: './placeholder-page.html',
  styleUrls: ['./placeholder-page.scss'],
})
export class PlaceholderPage {
  private readonly route = inject(ActivatedRoute);

  readonly title = computed(() => (this.route.snapshot.data['title'] as string) ?? 'Página');
}
