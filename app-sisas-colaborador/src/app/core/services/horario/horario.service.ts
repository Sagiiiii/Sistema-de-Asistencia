import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { DefaultService } from '../../../shared/services/default.service';
import { AlertService } from '../../../shared/services/alert.service';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { endpoints } from '../../../shared/apis/endpoits';
import { HorarioApi } from '../../../response/horario/horario.response';
import { ApiResponse } from '../../../response/horario/horario.response';
import { ListHorarioRequest } from '../../../request/horario/list-category.request';
import { HorarioRequest } from '../../../request/horario/horario.request';


@Injectable({
  providedIn: 'root'
})
export class HorarioService extends DefaultService {

  constructor(
    @Inject(HttpClient) private _http: HttpClient,
    @Inject(AlertService) private _alert: AlertService
  ) {
    super();
  }

  GetAll(
    size: number,
    sort: string,
    order: 'desc' | 'asc',
    page: number,
    getInputs: {
      numFilter?: number,
      textFilter?: string,
      stateFilter?: number | null
    }
  ): Observable<HorarioApi> {
    const requestUrl = `${environment.api}${endpoints.LIST_HORARIOS}`;
    const body: ListHorarioRequest = {
      numPage: page,
      order,
      sort,
      records: size as 5 | 10 | 20 | 50,
      numFilter: getInputs.numFilter ?? 0,
      textFilter: getInputs.textFilter ?? '',
      stateFilter: getInputs.stateFilter ?? null
    };

    return this._http.post<HorarioApi>(requestUrl, body);
  }

  Register(request: HorarioRequest): Observable<ApiResponse<boolean>> {
    const requestUrl = `${environment.api}${endpoints.REGISTER_HORARIO}`;
    return this._http.post<ApiResponse<boolean>>(requestUrl, request);
  }
}
