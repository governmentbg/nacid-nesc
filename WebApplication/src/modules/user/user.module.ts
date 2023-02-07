import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { UserLoginService } from './services/user-login.service';
import { UserRoutingModule } from './user-routing.module';
import { UserLoginResource } from './resources/user-login.resource';
import { UserForgottenPasswordComponent } from './components/user-forgotten-password/user-forgotten-password.component';
import { UserPasswordRecoveryComponent } from './components/user-password-recovery/user-password-recovery.component';
import { UserActivationResource } from './resources/user-activation.resource';
import { UserTokenGuard } from './services/user-token.guard';
import { CommonBootstrapModule } from 'src/infrastructure/common-bootstrap.module';
import { UserChangePasswordModalComponent } from './components/user-change-password-modal/user-change-password-modal.component';
import { CommonMaterialModule } from 'src/infrastructure/common-material.module';
import { UserActivationComponent } from './components/user-activation/user-activation.component';
import { UserChangeEmailAddressModalComponent } from './components/user-change-email-address-modal/user-change-email-address.component';
import { UserActivationNewEmailAddressComponent } from './components/user-activation-email-address/user-activation-new-email-address.component';
import { UserHistoryLogModalComponent } from './components/user-history-log-modal/user-history-log-modal.component';
import { UserRegisterResource } from './resources/user-register.resource';
import { LoginComponent } from './components/user-access/login/login.component';
import { RegisterComponent } from './components/user-access/register/register.component';
import { UserAccessComponent } from './components/user-access/user-access.component';
import { UserChangeNameModalComponent } from './components/user-change-name-modal/user-change-name-modal.component';

@NgModule({
  declarations: [
    UserAccessComponent,
    LoginComponent,
    RegisterComponent,
    UserForgottenPasswordComponent,
    UserPasswordRecoveryComponent,
    UserChangePasswordModalComponent,
    UserActivationComponent,
    UserChangeEmailAddressModalComponent,
    UserActivationNewEmailAddressComponent,
    UserHistoryLogModalComponent,
    UserChangeNameModalComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    CommonBootstrapModule,
    CommonMaterialModule,
    UserRoutingModule,
    TranslateModule
  ],
  providers: [
    UserLoginResource,
    UserRegisterResource,
    UserLoginService,
    UserActivationResource,
    UserTokenGuard
  ]
})
export class UserModule { }
