import { Injectable } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { UserLoginEventEnum } from '../enums/user-login-event.enum';
import { UserLoginInfoDto } from '../models/user-login-info.dto';

@Injectable({
  providedIn: 'root'
})
export class UserLoginService {
  private loginSubject: Subject<{ event: UserLoginEventEnum }> = new Subject();

  public isLogged = false;

  constructor(private configuration: Configuration) {
    this.isLogged = localStorage.getItem(this.configuration.tokenProperty) ? true : false;
  }

  login(userLoginInfoDto: UserLoginInfoDto): void {
    localStorage.setItem(this.configuration.tokenProperty, userLoginInfoDto.token);
    localStorage.setItem(this.configuration.usernameProperty, userLoginInfoDto.username);
    localStorage.setItem(this.configuration.fullNameProperty, userLoginInfoDto.fullName);
    localStorage.setItem(this.configuration.fullNameAltProperty, userLoginInfoDto.fullNameAlt);

    this.isLogged = true;
    this.loginSubject.next({ event: UserLoginEventEnum.login });
  }

  logout(): void {
    localStorage.removeItem(this.configuration.tokenProperty);
    localStorage.removeItem(this.configuration.usernameProperty);
    localStorage.removeItem(this.configuration.fullNameProperty);
    localStorage.removeItem(this.configuration.fullNameAltProperty);

    this.isLogged = false;

    this.loginSubject.next({ event: UserLoginEventEnum.logout });
  }

  subscribe(next: (value: { event: UserLoginEventEnum }) => void): Subscription {
    return this.loginSubject.subscribe(next);
  }
}
