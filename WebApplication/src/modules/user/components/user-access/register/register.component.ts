import { Component, ViewChild } from "@angular/core";
import { NgForm } from "@angular/forms";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
import { finalize } from "rxjs";
import { LoadingIndicatorService } from "src/app/loading-indicator/loading-indicator.service";
import { RegExps } from "src/infrastructure/constants/constants";
import { ChangeTabService } from "src/modules/student/services/change-tab.service";
import { RegisterIdentificationEnum } from "src/modules/user/enums/register-identification.enum";
import { RegisterDto } from "src/modules/user/models/register.dto";
import { UserRegisterResource } from "src/modules/user/resources/user-register.resource";

@Component({
  selector: 'user-register',
  templateUrl: 'register.component.html'
})

export class RegisterComponent {
  @ViewChild('newProfileForm', { static: false }) newProfileForm: NgForm;
  registerModel: RegisterDto = new RegisterDto();
  identificationTypes = RegisterIdentificationEnum;

  emailRegex = RegExps.EMAIL_REGEX;

  constructor(
    private registerResource: UserRegisterResource,
    private loadingIndicator: LoadingIndicatorService,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private changeTabService: ChangeTabService,
  ) { }

  requestProfile(): void {
    this.loadingIndicator.show();
    this.registerResource.register(this.registerModel)
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe((message: string) => {
        if (message !== '' && message !== null) {
          this.toastrService.error(this.translateService.instant('toastrError.UserRegisterEmailMismatch_1') + message +
            this.translateService.instant('toastrError.UserRegisterEmailMismatch_2'));
        } else {
          this.toastrService.success(this.translateService.instant('toastrSuccess.UserRequestedRegister'));
          this.newProfileForm.resetForm();
          this.changeTabService.setTabIndex(0);
        }
      })
  }

  clearIdentificator(): void {
    this.registerModel.identificator = '';
  }
}