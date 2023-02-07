import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs/operators';
import { LoadingIndicatorService } from 'src/app/loading-indicator/loading-indicator.service';
import { RegExps } from 'src/infrastructure/constants/constants';
import { UserRecoveryPasswordDto } from '../../models/user-recovery-password.dto';
import { UserForgottenPasswordResource } from '../../resources/user-forgotten-password.resource';

@Component({
  selector: 'app-user-password-recovery',
  templateUrl: './user-password-recovery.component.html',
  styleUrls: ['./user-password-recovery.component.css']
})
export class UserPasswordRecoveryComponent implements OnInit {
  model: UserRecoveryPasswordDto = new UserRecoveryPasswordDto();
  passwordRegex = RegExps.PASSWORD_REGEX;

  constructor(
    private toastrService: ToastrService,
    private loadingIndicator: LoadingIndicatorService,
    private resource: UserForgottenPasswordResource,
    private route: ActivatedRoute,
    private router: Router,
    private translateService: TranslateService) { }

  ngOnInit(): void {
    this.model.token = this.route.snapshot.queryParams.token;
  }

  recoverPassword() {
    this.loadingIndicator.show();

    if (this.model.newPassword === this.model.newPasswordAgain) {
      this.resource.recoverPassword(this.model)
        .pipe(finalize(() => this.loadingIndicator.hide()))
        .subscribe(() => {
          this.toastrService.success(this.translateService.instant('toastrSuccess.UserChangePassword'));
          this.router.navigate(['access']);
        });
    } else {
      this.loadingIndicator.hide();
      this.toastrService.error(this.translateService.instant('toastrError.UserChangePasswordNewPasswordsMismatch'));
    }
  }
}
