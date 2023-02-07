import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "src/infrastructure/configuration/configuration";
import { PersonLotDto } from "../dtos/person-lot.dtos/person-lot.dto";

@Injectable()
export class StudentResource {
  constructor(protected http: HttpClient,
    protected configuration: Configuration) {
  }

  getStudent(): Observable<PersonLotDto> {
    return this.http.get<PersonLotDto>(`${this.configuration.restUrl}/student`);
  }
}