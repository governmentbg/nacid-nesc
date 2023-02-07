import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "src/infrastructure/configuration/configuration";
import { BaseResource } from "src/infrastructure/services/base.resource";
import { UserHistoryLogResultDto } from "../models/user-history-log-result.dto";
import { UserHistoryLogFilter } from "../services/user-history-log.filter";

@Injectable({
  providedIn: 'root'
})
export class UserLogHistoryResource extends BaseResource {

  constructor(
    public http: HttpClient,
    public configuration: Configuration,
  ) {
    super(http, configuration);
  }

  getLogHistory(filter: UserHistoryLogFilter): Observable<UserHistoryLogResultDto> {
    //TODO Change route
    return this.http.get<UserHistoryLogResultDto>(`${this.configuration.restUrl}/student/historyLogs` + this.composeQueryString(filter));
  }
}