import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { UserLoginService } from 'src/modules/user/services/user-login.service';
import { ActionConfirmationModalComponent } from 'src/infrastructure/components/action-confirmation-modal/action-confirmation-modal.component';
import { UserChangePasswordModalComponent } from 'src/modules/user/components/user-change-password-modal/user-change-password-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { UserChangeEmailAddressModalComponent } from 'src/modules/user/components/user-change-email-address-modal/user-change-email-address.component';
import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { UserHistoryLogModalComponent } from 'src/modules/user/components/user-history-log-modal/user-history-log-modal.component';
import { UserChangeNameModalComponent } from 'src/modules/user/components/user-change-name-modal/user-change-name-modal.component';

@Component({
  selector: 'app-user',
  templateUrl: './app-user.component.html',
  styleUrls: ['./app-user.component.css']
})
export class AppUserComponent implements OnInit {
  fullName: string;
  fullNameAlt: string;
  menuOpened: boolean;

  constructor(
    private configuration: Configuration,
    private userLoginService: UserLoginService,
    private router: Router,
    private modal: NgbModal,
    public dialog: MatDialog,
    config: NgbModalConfig,
    public translate: TranslateService
  ) {
    config.backdrop = 'static';
    config.keyboard = false;
  }

  ngOnInit(): void {
    this.fullName = localStorage.getItem(this.configuration.fullNameProperty);
    this.fullNameAlt = localStorage.getItem(this.configuration.fullNameAltProperty);
  }

  openChangePasswordDialog() {
    this.dialog.open(UserChangePasswordModalComponent, { scrollStrategy: new NoopScrollStrategy() });
  }

  openChangeEmailAddressDialog() {
    this.dialog.open(UserChangeEmailAddressModalComponent, { scrollStrategy: new NoopScrollStrategy() });

  }

  openHistoryLogDialog() {
    this.dialog.open(UserHistoryLogModalComponent, { scrollStrategy: new NoopScrollStrategy() })
  }

  openChangeNameDialog() {
    this.dialog.open(UserChangeNameModalComponent, { scrollStrategy: new NoopScrollStrategy() });
  }

  logout(): void {
    const confirmationModal = this.modal.open(ActionConfirmationModalComponent, { backdrop: 'static' });
    const confirmationMessage = localStorage.getItem('currentLanguage') === 'bg' ?
      "Сигурни ли сте, че искате да излезете от системата?" : "Are you sure you want to exit the system?";
    confirmationModal.componentInstance.confirmationMessage = confirmationMessage;
    confirmationModal.result
      .then((result: boolean) => {
        if (result) {
          this.userLoginService.logout();
          this.router.navigate(['access']);
        }
      });
  }
}
