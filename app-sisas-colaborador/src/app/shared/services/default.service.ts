import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class DefaultService {

  constructor() { }

  /**
   * Returns a paginated, sorted and filtered list
   */
  abstract GetAll(
    size: number,
    sort: string,
    order: 'desc' | 'asc',
    page: number,
    getInputs: {
      numFilter?: number,
      textFilter?: string,
      stateFilter?: number | null
    }
  ): Observable<unknown>;
}
