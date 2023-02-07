import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserAccessComponent } from './components/user-access/user-access.component';
import { UserActivationNewEmailAddressComponent } from './components/user-activation-email-address/user-activation-new-email-address.component';
import { UserActivationComponent } from './components/user-activation/user-activation.component';
import { UserForgottenPasswordComponent } from './components/user-forgotten-password/user-forgotten-password.component';
import { UserHistoryLogModalComponent } from './components/user-history-log-modal/user-history-log-modal.component';
import { UserPasswordRecoveryComponent } from './components/user-password-recovery/user-password-recovery.component';
import { UserTokenGuard } from './services/user-token.guard';

const routes: Routes = [
  {
    path: 'access',
    component: UserAccessComponent
  },
  {
    path: 'forgottenPassword',
    component: UserForgottenPasswordComponent
  },
  {
    path: 'passwordRecovery',
    component: UserPasswordRecoveryComponent,
    canActivate: [UserTokenGuard]
  },
  {
    path: 'user/activation',
    component: UserActivationComponent,
    canActivate: [UserTokenGuard]
  },
  {
    path: 'user/changeEmail',
    component: UserActivationNewEmailAddressComponent,
    canActivate: [UserTokenGuard]
  },
  {
    path: 'user/historyLogs',
    component: UserHistoryLogModalComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
