import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { LoadingIndicatorService } from 'src/app/loading-indicator/loading-indicator.service';
import { RegExps } from 'src/infrastructure/constants/constants';
import { UserChangeEmailAddressDto } from '../../models/user-change-email-address.dto';
import { UserResource } from '../../resources/user.resource';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-user-change-email-address',
  templateUrl: './user-change-email-address.component.html',
  styleUrls: ['./user-change-email-address.component.css']
})
export class UserChangeEmailAddressModalComponent {
  model: UserChangeEmailAddressDto = new UserChangeEmailAddressDto();
  isLoading: boolean = false;

  emailRegex = RegExps.EMAIL_REGEX;
  passwordRegex = RegExps.PASSWORD_REGEX;

  constructor(
    private resource: UserResource,
    public dialogRef: MatDialogRef<UserChangeEmailAddressModalComponent>,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private loadingIndicator: LoadingIndicatorService
  ) {
  }

  sendUserChangeEmailAddressLink(): void {
    this.isLoading = true;
    this.loadingIndicator.show();
    this.resource.sendUserChangeEmailAddressLink(this.model)
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe(
        next => {
          this.isLoading = false;
          this.toastrService.success(this.translateService.instant('toastrSuccess.UserChangeNewEmail'));
          this.dialogRef.close();
        },
        error => {
          this.isLoading = false;
        }
      );
  }

  close(): void {
    this.dialogRef.close();
  }
}
