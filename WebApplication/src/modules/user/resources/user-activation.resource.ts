import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { BaseResource } from 'src/infrastructure/services/base.resource';
import { UserActivationNewEmailAddressDto } from '../models/user-activation-new-email-address.dto';
import { UserActivationDto } from '../models/user-activation.dto';
import { TypeOfActivation } from '../enums/type-of-activation.enum';

@Injectable()
export class UserActivationResource extends BaseResource {
  constructor(protected http: HttpClient,
    protected configuration: Configuration) {
    super(http, configuration, 'Activation');
  }

  activateUser(model: UserActivationDto): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}`, model);
  }

  checkToken(token: string, typeOfActivation: TypeOfActivation): Observable<void> {
    return this.http.get<void>(`${this.baseUrl}?token=${token}&typeOfActivation=${typeOfActivation}`)
  }

  sendActivationLink(userId: number): Observable<void> {
    return this.http.get<void>(`${this.baseUrl}/userActivation?userId=${userId}`);
  }

  activateNewEmailAddress(model: UserActivationNewEmailAddressDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/newEmail`, model);
  }
}
