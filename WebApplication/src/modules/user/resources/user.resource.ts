import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { BaseResource } from 'src/infrastructure/services/base.resource';
import { RegixGRAOResponse } from '../models/regix-grao-response.dto';
import { UserChangeEmailAddressDto } from '../models/user-change-email-address.dto';
import { UserChangePasswordDto } from '../models/user-change-password.dto';

@Injectable({
  providedIn: 'root'
})
export class UserResource extends BaseResource {

  constructor(
    protected http: HttpClient,
    protected configuration: Configuration
  ) {
    super(http, configuration, 'User');
  }

  changePassword(model: UserChangePasswordDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/NewPassword`, model);
  }

  sendUserChangeEmailAddressLink(model: UserChangeEmailAddressDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/NewEmailAddress`, model);
  }

  TakeNameFromGRAO(): Observable<RegixGRAOResponse> {
    return this.http.post<RegixGRAOResponse>(`${this.baseUrl}/TakeNameFromGRAO`, null)
  }

  changeUserName(regixGRAO: RegixGRAOResponse): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/changeUserName`, regixGRAO)
  }
}
