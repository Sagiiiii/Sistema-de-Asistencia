export interface BasePaginationRequest {
  numPage: number;
  order: 'desc' | 'asc';
  sort: string;
  records: 5 | 10 | 20 | 50;
}

export interface BaseFilterRequest {
  numFilter: number;
  textFilter: string;
  stateFilter: number | null;
}

export interface UserToken {
  message: string;
}
