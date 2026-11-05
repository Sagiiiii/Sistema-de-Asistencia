import { Component, computed, effect, input, output, signal } from '@angular/core';
import { CurrencyPipe, DatePipe, DecimalPipe, NgTemplateOutlet } from '@angular/common';
import { Observable } from 'rxjs';

import { TableModule } from 'primeng/table';
import { Button } from 'primeng/button';
import { Tag } from 'primeng/tag';

import {
  PageResult,
  TableAction,
  TableActionEvent,
  TableBadgeSeverity,
  TableColumn,
  TablePageEvent,
  TableRequest,
  TableSortEvent,
} from './list-table.model';

@Component({
  selector: 'app-list-table',
  imports: [
    TableModule,
    Button,
    Tag,
    DatePipe,
    DecimalPipe,
    CurrencyPipe,
    NgTemplateOutlet,
  ],
  templateUrl: './list-table.html',
  styleUrls: ['./list-table.scss'],
})
export class ListTable<T> {
  readonly columns = input.required<TableColumn<T>[]>();
  readonly dataLoader = input.required<(req: TableRequest) => Observable<PageResult<T>>>();

  readonly pageSize = input(10);
  readonly pageSizeOptions = input<number[]>([10, 20, 50]);
  readonly pageLinks = input(5);
  readonly sortBy = input('');
  readonly sortDir = input<'asc' | 'desc'>('asc');

  readonly selectable = input(false);
  readonly selected = input<T[]>([]);
  readonly selectedCompareAttr = input('id');

  readonly actions = input<TableAction<T>[]>([]);

  readonly refreshId = input<number>(0);
  readonly filters = input<unknown>();

  readonly emptyMessage = input('No hay registros para mostrar.');

  readonly rowClick = output<T>();
  readonly selectedChange = output<T[]>();
  readonly action = output<TableActionEvent<T>>();
  readonly request = output<TableRequest>();

  protected readonly rows = signal<T[]>([]);
  protected readonly totalRecords = signal(0);
  protected readonly loading = signal(false);
  protected readonly first = signal(0);
  protected readonly pageSizeState = signal(this.pageSize());
  protected readonly sortFieldState = signal('');
  protected readonly sortOrderState = signal(1);
  protected readonly selection = signal<T[]>([]);

  protected readonly displayColumns = computed<TableColumn<T>[]>(() => {
    const cols = [...this.columns()];
    if (this.actions().length) {
      cols.push({ field: '__actions', header: 'Acciones', type: 'action', align: 'right' } as TableColumn<T>);
    }
    return cols;
  });

  protected readonly colspan = computed(
    () => this.displayColumns().length + (this.selectable() ? 1 : 0),
  );

  constructor() {
    this.sortFieldState.set(this.sortBy());
    this.sortOrderState.set(this.sortDir() === 'desc' ? -1 : 1);

    effect(
      () => {
        this.refreshId();
        this.filters();
        this.first.set(0);
        queueMicrotask(() => this.load());
      },
      { allowSignalWrites: true },
    );

    effect(
      () => {
        const incoming = this.selected();
        if (!this.isSameSelection(incoming, this.selection())) {
          this.selection.set(incoming ?? []);
        }
      },
      { allowSignalWrites: true },
    );
  }

  reload(): void {
    this.load();
  }

  protected load(): void {
    const loader = this.dataLoader();
    if (!loader) {
      this.rows.set([]);
      this.totalRecords.set(0);
      return;
    }

    const pageSize = this.pageSizeState();
    const first = this.first();
    const order = this.sortOrderState();
    const req: TableRequest = {
      page: Math.floor(first / pageSize) + 1,
      pageSize,
      sortField: this.sortFieldState() || undefined,
      sortOrder: order === -1 ? 'desc' : order === 1 ? 'asc' : '',
      filters: this.filters(),
    };

    this.request.emit(req);
    this.loading.set(true);
    loader(req).subscribe({
      next: (result) => {
        this.rows.set(result?.items ?? []);
        this.totalRecords.set(result?.totalRecords ?? 0);
        this.loading.set(false);
      },
      error: () => {
        this.rows.set([]);
        this.totalRecords.set(0);
        this.loading.set(false);
      },
    });
  }

  protected onPage(event: TablePageEvent): void {
    this.first.set(event.first ?? 0);
    if (event.rows) {
      this.pageSizeState.set(event.rows);
    }
    this.load();
  }

  protected onSort(event: TableSortEvent): void {
    if (event.field !== undefined) {
      this.sortFieldState.set(event.field);
    }
    if (event.order !== undefined) {
      this.sortOrderState.set(event.order);
    }
    this.load();
  }

  protected onSelectionChange(value: T[]): void {
    this.selection.set(value ?? []);
    this.selectedChange.emit(this.selection());
  }

  protected onRowClick(row: T): void {
    this.rowClick.emit(row);
  }

  protected onAction(event: Event, action: TableAction<T>, row: T): void {
    event.stopPropagation();
    this.action.emit({ action, row });
  }

  protected fieldName(column: TableColumn<T>): string {
    return String(column.field);
  }

  protected cellValue(column: TableColumn<T>, row: T): any {
    return (row as Record<string, any>)[String(column.field)];
  }

  protected cellClass(column: TableColumn<T>): string {
    const align =
      column.align === 'right' ? 'text-right' : column.align === 'center' ? 'text-center' : 'text-left';
    return `${align} ${column.bodyClass ?? ''}`.trim();
  }

  protected badgeLabel(column: TableColumn<T>, row: T): string {
    const value = this.cellValue(column, row);
    const label = column.badge?.label?.[String(value)];
    return label ?? String(value ?? '');
  }

  protected badgeSeverity(column: TableColumn<T>, row: T): TableBadgeSeverity {
    const value = this.cellValue(column, row);
    return column.badge?.severity?.[String(value)] ?? 'secondary';
  }

  private isSameSelection(a: T[], b: T[]): boolean {
    const key = this.selectedCompareAttr();
    if (a.length !== b.length) {
      return false;
    }
    return a.every((item, i) => (item as Record<string, unknown>)[key] === (b[i] as Record<string, unknown>)[key]);
  }
}
