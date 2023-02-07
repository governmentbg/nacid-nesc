import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs/operators';
import { LoadingIndicatorService } from 'src/app/loading-indicator/loading-indicator.service';
import { RegExps } from 'src/infrastructure/constants/constants';
import { ForgottenPasswordDto } from '../../models/forgotten-password.dto';
import { UserForgottenPasswordResource } from '../../resources/user-forgotten-password.resource';

@Component({
  selector: 'app-user-forgotten-password',
  templateUrl: './user-forgotten-password.component.html'
})
export class UserForgottenPasswordComponent {
  model: ForgottenPasswordDto = new ForgottenPasswordDto();

  emailRegex = RegExps.EMAIL_REGEX;

  constructor(
    private resource: UserForgottenPasswordResource,
    private toastrService: ToastrService,
    private loadingIndicator: LoadingIndicatorService,
    private translateService: TranslateService,
    private router: Router
  ) {
  }

  sendForgottenPassword(): void {
    this.loadingIndicator.show();

    this.resource.sendForgottenPassword(this.model)
      .pipe(
        finalize(() => {
          this.loadingIndicator.hide();
        }))
      .subscribe(() => {
        this.toastrService.success(this.translateService.instant('toastrSuccess.UserLinkForActivation'));
        this.router.navigate(['']);
        this.model = new ForgottenPasswordDto();
      });
  }
}
