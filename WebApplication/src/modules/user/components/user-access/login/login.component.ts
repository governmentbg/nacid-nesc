import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { finalize } from "rxjs";
import { EAuthService } from "src/app/e_authentication/eAuth-service";
import { LoadingIndicatorService } from "src/app/loading-indicator/loading-indicator.service";
import { LoginDto } from "src/modules/user/models/login.dto";
import { UserLoginInfoDto } from "src/modules/user/models/user-login-info.dto";
import { UserLoginResource } from "src/modules/user/resources/user-login.resource";
import { UserLoginService } from "src/modules/user/services/user-login.service";

@Component({
  selector: 'user-login',
  templateUrl: 'login.component.html'
})

export class LoginComponent {
  model: LoginDto = new LoginDto();

  constructor(
    private router: Router,
    private loginResource: UserLoginResource,
    private eAuthService: EAuthService,
    private loadingIndicator: LoadingIndicatorService,
    private userLoginService: UserLoginService
  ) { }

  login(): void {
    this.loadingIndicator.show();
    this.loginResource.login(this.model)
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe({
        next: (userLoginInfoDto: UserLoginInfoDto) => {
          this.userLoginService.login(userLoginInfoDto);
          this.router.navigate(['student']);
        }
      });
  }

  logInEAuth(): void {
    this.eAuthService.authenticate('default', '/', 'navigate');
  }
}