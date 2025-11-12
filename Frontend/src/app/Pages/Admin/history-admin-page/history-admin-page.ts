import { Component, Signal } from '@angular/core';
import { Observable } from 'rxjs';
import { AuditLog } from '../../../Interfaces/audit-log';
import { AuditLogService } from '../../../Services/audit-log-service';
import { ApiResponse } from '../../../Interfaces/api-response';
import { AsyncPipe, DatePipe } from '@angular/common';
import { InputDirective } from "../../../Directives/input-directive";
import { FormsModule } from '@angular/forms';
import { LoaderService } from '../../../Services/loader-service';
import { LoaderComponent } from "../../../Components/loader-component/loader-component";

@Component({
  selector: 'app-history-admin-page',
  imports: [AsyncPipe, DatePipe, InputDirective, FormsModule, LoaderComponent],
  templateUrl: './history-admin-page.html',
  styleUrl: './history-admin-page.css'
})
export class HistoryAdminPage {
  dateString: string = new Date().toISOString().slice(0, 10);
  auditLogs$!: Observable<ApiResponse<AuditLog[]>>;
  constructor(private auditLogService: AuditLogService, public loaderService: LoaderService) { }
  ngOnInit() {
    this.auditLogs$ = this.auditLogService.getAuditLogsByDate(this.dateString);
  }
  onDateChange() {
    this.auditLogs$ = this.auditLogService.getAuditLogsByDate(this.dateString);
  }
  
}
