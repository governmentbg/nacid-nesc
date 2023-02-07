import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "src/infrastructure/configuration/configuration";
import { BaseResource } from "src/infrastructure/services/base.resource";
import { FeedbackDto } from "../dtos/feedback.dto";

@Injectable()
export class FeedbackResource extends BaseResource {
  constructor(protected http: HttpClient,
    protected configuration: Configuration) {
    super(http, configuration, 'Feedback');
  }

  sendFeedback(model: FeedbackDto): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}`, model);
  }
}