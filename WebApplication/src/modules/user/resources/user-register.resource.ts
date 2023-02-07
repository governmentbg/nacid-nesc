import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "src/infrastructure/configuration/configuration";
import { RegisterDto } from "../models/register.dto";

@Injectable()
export class UserRegisterResource {
  constructor(
    private http: HttpClient,
    private configuration: Configuration
  ) { }

  register(model: RegisterDto): Observable<string> {
    return this.http.post<string>(`${this.configuration.restUrl}/Register`, model);
  }
}
