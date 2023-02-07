import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs';
import { LoadingIndicatorService } from 'src/app/loading-indicator/loading-indicator.service';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { RegixGRAOResponse } from '../../models/regix-grao-response.dto';
import { UserResource } from '../../resources/user.resource';

@Component({
  selector: 'app-user-change-name',
  templateUrl: 'user-change-name-modal.component.html',
  styleUrls: ['user-change-name-modal.component.css']
})

export class UserChangeNameModalComponent implements OnInit {
  fullNames: string;
  fullNamesAlt: string;
  regixGRAOResponse: RegixGRAOResponse = new RegixGRAOResponse();

  constructor(
    private resource: UserResource,
    public dialogRef: MatDialogRef<UserChangeNameModalComponent>,
    private loadingIndicator: LoadingIndicatorService,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private configuration: Configuration
  ) {
  }

  ngOnInit(): void {
    this.loadingIndicator.show();
    this.resource.TakeNameFromGRAO()
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe((response: RegixGRAOResponse) => {
        this.regixGRAOResponse = response;
        this.fullNames = response.personNames.firstName + ' ' + response.personNames.surName + ' ' + response.personNames.familyName;
        this.fullNamesAlt = response.latinNames.firstName + ' ' + response.latinNames.surName + ' ' + response.latinNames.familyName;
      });
  }

  changeUserName(): void {
    this.loadingIndicator.show();
    this.resource.changeUserName(this.regixGRAOResponse)
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe(() => {
        this.toastrService.success(this.translateService.instant('toastrSuccess.UserChangeName', 5000));

        localStorage.setItem(this.configuration.fullNameProperty, this.regixGRAOResponse.personNames.firstName + ' ' + this.regixGRAOResponse.personNames.familyName);
        localStorage.setItem(this.configuration.fullNameAltProperty, this.regixGRAOResponse.latinNames.firstName + ' ' + this.regixGRAOResponse.latinNames.familyName);

        setTimeout(() => {
          location.reload();
        }, 5000);
      });
  }

  close(): void {
    this.dialogRef.close();
  }
}