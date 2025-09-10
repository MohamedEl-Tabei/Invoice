import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Interfaces/api-response';
import { AuditLog } from '../Interfaces/audit-log';
import { Constants } from '../Constants';

@Injectable({
  providedIn: 'root'
})
export class AuditLogService {
  constructor(private httpClient: HttpClient) { }
  getAuditLogsByDate(dateString: string): Observable<ApiResponse<AuditLog[]>> {

    return this.httpClient.get<ApiResponse<AuditLog[]>>(`${Constants.API_URL}AuditLog`, { params: { date: dateString } });
  }
}
