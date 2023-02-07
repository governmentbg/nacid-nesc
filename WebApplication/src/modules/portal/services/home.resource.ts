import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "src/infrastructure/configuration/configuration";
import { StudentPortalSearchDto } from "../dtos/basic/student-portal-search.dto";

@Injectable({
  providedIn: 'root'
})
export class HomeResource {

  constructor(private http: HttpClient, private configuration: Configuration) { }

  getStudent(uan: string, captchaToken: string): Observable<StudentPortalSearchDto> {
    return this.http.get<StudentPortalSearchDto>(`${this.configuration.restUrl}/studentPortal?uan=${uan}&captcha=${captchaToken}`);
  }
}