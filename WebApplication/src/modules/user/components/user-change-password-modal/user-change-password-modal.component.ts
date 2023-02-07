import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { RegExps } from 'src/infrastructure/constants/constants';
import { UserChangePasswordDto } from '../../models/user-change-password.dto';
import { UserResource } from '../../resources/user.resource';

@Component({
  selector: 'app-user-change-password-modal',
  templateUrl: './user-change-password-modal.component.html',
  styleUrls: ['./user-change-password-modal.component.css']
})
export class UserChangePasswordModalComponent {
  model: UserChangePasswordDto = new UserChangePasswordDto();

  passwordRegex = RegExps.PASSWORD_REGEX;

  hide = true;
  hideNew = true;
  hideNewAgain = true;

  constructor(
    private resource: UserResource,
    public dialogRef: MatDialogRef<UserChangePasswordModalComponent>,
    private toastrService: ToastrService,
    private translateService: TranslateService) {
  }

  change(): void {
    if (this.model.newPassword === this.model.newPasswordAgain) {
      this.resource.changePassword(this.model)
        .subscribe(() => {
          this.toastrService.success(this.translateService.instant('toastrSuccess.UserChangePassword'));
          this.dialogRef.close();
        });
    } else {
      this.toastrService.error(this.translateService.instant('toastrError.UserChangePasswordNewPasswordsMismatch'));
    }
  }

  close(): void {
    this.dialogRef.close();
  }
}
