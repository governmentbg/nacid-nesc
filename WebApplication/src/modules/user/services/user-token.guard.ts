import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { LoadingIndicatorService } from 'src/app/loading-indicator/loading-indicator.service';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { TypeOfActivation } from '../enums/type-of-activation.enum';
import { UserActivationResource } from '../resources/user-activation.resource';
import { UserLoginService } from './user-login.service';

@Injectable()
export class UserTokenGuard implements CanActivate {
  constructor(
    private router: Router,
    private config: Configuration,
    private userService: UserLoginService,
    private loadingIndicator: LoadingIndicatorService,
    private resource: UserActivationResource
  ) { }

  canActivate(route: ActivatedRouteSnapshot, _: RouterStateSnapshot): boolean {
    let url = route.url.join(" ");
    let typeOfActivation = TypeOfActivation.UserActivation;

    if (url.includes("passwordRecovery")) {
      typeOfActivation = TypeOfActivation.PasswordRecovery;
    }
    else if (url.includes("changeEmail")) {
      typeOfActivation = TypeOfActivation.NewEmailActivation;
    }
    else if (url.includes("activation")) {
      typeOfActivation = TypeOfActivation.UserActivation;
    }

    this.resource.checkToken(route.queryParams.token, typeOfActivation)
      .pipe(finalize(() => this.loadingIndicator.hide()))
      .subscribe();

    const params = route.queryParams;

    const token = localStorage.getItem(this.config.tokenProperty);
    if (token) {
      this.userService.logout();
    }

    if (params && params['token']) {
      return true;
    }

    this.router.navigate[''];
    return false;
  }
}
