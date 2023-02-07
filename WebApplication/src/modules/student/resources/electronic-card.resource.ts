import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "src/infrastructure/configuration/configuration";
import { BaseResource } from "src/infrastructure/services/base.resource";
import { ElectronicCardDto } from "../dtos/electronic-card/electronic-card-info.dto";

@Injectable()
export class ElectronicCardResource extends BaseResource {

  constructor(
    public http: HttpClient,
    public configuration: Configuration,
  ) {
    super(http, configuration);
  }

  getStudentElectronicCardInfo(): Observable<ElectronicCardDto> {
    return this.http.get<ElectronicCardDto>(`${this.configuration.restUrl}/electronicCard`);
  }

  getStudentElectronicCardPdf(inBulgarian: boolean): Observable<string> {
    return this.http.get<string>(`${this.configuration.restUrl}/electronicCard/pdf?inBulgarian=` + inBulgarian);
  }
}