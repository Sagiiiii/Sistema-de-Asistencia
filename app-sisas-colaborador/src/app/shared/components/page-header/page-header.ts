import { Component, input } from '@angular/core';

@Component({
  selector: 'app-page-header',
  imports: [],
  templateUrl: './page-header.html',
  styleUrls: ['./page-header.scss'],
})
export class PageHeader {
  /** Título principal de la página. */
  readonly title = input.required<string>();

  /** Descripción o subtítulo. */
  readonly subtitle = input<string>();
}
