import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UserActivationResource } from 'src/modules/user/resources/user-activation.resource';
import { UserActivationNewEmailAddressDto } from '../../models/user-activation-new-email-address.dto';

@Component({
  selector: 'app-user-activation-new-email-address',
  templateUrl: './user-activation-new-email-address.component.html'
})
export class UserActivationNewEmailAddressComponent implements OnInit {
  model: UserActivationNewEmailAddressDto = new UserActivationNewEmailAddressDto();

  currentDate = new Date();

  constructor(
    private route: ActivatedRoute,
    private resource: UserActivationResource,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.model.token = this.route.snapshot.queryParams.token;
  }

  activateNewEmailAddress(): void {
    this.resource.activateNewEmailAddress(this.model).subscribe({
      next: () => {
        this.toastrService.success(this.translateService.instant('toastrSuccess.UserActivateNewEmail', 5000));
        setTimeout(() => {
          this.router.navigate(['access']);
        }, 4000);
      }
    });
  }
}
