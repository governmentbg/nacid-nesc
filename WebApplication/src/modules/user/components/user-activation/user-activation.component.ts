import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { RegExps } from 'src/infrastructure/constants/constants';
import { UserActivationDto } from 'src/modules/user/models/user-activation.dto';
import { UserActivationResource } from 'src/modules/user/resources/user-activation.resource';

@Component({
  selector: 'app-user-activation',
  templateUrl: './user-activation.component.html',
  styleUrls: ['./user-activation.component.css']
})
export class UserActivationComponent implements OnInit {
  model: UserActivationDto = new UserActivationDto();

  passwordRegex = RegExps.PASSWORD_REGEX;

  currentDate = new Date();

  constructor(
    private route: ActivatedRoute,
    private resource: UserActivationResource,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.model.token = this.route.snapshot.queryParams.token;
  }

  activate(): void {
    if (this.model.password === this.model.passwordAgain) {
      this.resource.activateUser(this.model).subscribe({
        complete: () => {
          this.toastrService.success(this.translateService.instant('toastrSuccess.UserActivateProfile'));
          setTimeout(() => {
            this.router.navigate(['access']);
          }, 2000);
        }
      });
    } else {
      this.toastrService.error(this.translateService.instant('toastrError.UserChangePasswordNewPasswordsMismatch'));
    }
  }
}
