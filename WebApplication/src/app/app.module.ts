import { HttpClient, HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { ToastrModule } from 'ngx-toastr';
import { Configuration, configurationFactory } from 'src/infrastructure/configuration/configuration';
import { AuthGuard } from 'src/infrastructure/guards/auth.guard';
import { InterceptorsModule } from 'src/infrastructure/interceptors/interceptors.module';
import { UserModule } from 'src/modules/user/user.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoadingIndicatorComponent } from './loading-indicator/loading-indicator.component';
import { LoadingIndicatorService } from './loading-indicator/loading-indicator.service';
import { CommonBootstrapModule } from 'src/infrastructure/common-bootstrap.module';
import { AppUserComponent } from './menu/app-user/app-user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonMaterialModule } from 'src/infrastructure/common-material.module';
import { StudentModule } from 'src/modules/student/student.module';
import { AppHeaderComponent } from './app-header/app-header.component';
import { EAuthModule } from './e_authentication/eAuth-module';
import { ChangeLanguageComponent } from './menu/change-language/change-language.component';
import { AppMenuComponent } from './menu/app-menu/app-menu.component';
import { AppMenuMobileComponent } from './menu/app-menu-mobile/app-menu-mobile.component';
import { AppMenuItemComponent } from './menu/app-menu-items/app-menu-items.component';
import { PortalModule } from 'src/modules/portal/portal.module';
import { FormsModule } from '@angular/forms';
import { FeedbackModalComponent } from './feedback-modal/feedback-mdoal.component';
import { FeedbackResource } from './feedback-modal/resources/feedback.resource';
import { CommonModule } from '@angular/common';
import { AppAboutUanVerificationComponent } from './menu/app-menu-about-nesc/components/app-about-uan-verification/app-about-uan-verification.component';
import { AppAboutNescComponent } from './menu/app-menu-about-nesc/components/app-about-nesc/app-about-nesc.component';
import { AppAboutPortalComponent } from './menu/app-menu-about-nesc/components/app-about-portal/app-about-portal.component';
import { registerLocaleData } from '@angular/common';
import localeBg from '@angular/common/locales/bg';
import { ChangeLanguageService } from './menu/change-language/change-language.service';
import { AppFooterComponent } from './app-footer/app-footer.component';
registerLocaleData(localeBg);

@NgModule({
  declarations: [
    AppComponent,
    AppMenuComponent,
    AppUserComponent,
    AppMenuItemComponent,
    AppMenuMobileComponent,
    AppHeaderComponent,
    AppFooterComponent,
    LoadingIndicatorComponent,
    ChangeLanguageComponent,
    FeedbackModalComponent,
    AppAboutUanVerificationComponent,
    AppAboutNescComponent,
    AppAboutPortalComponent
  ],
  imports: [
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    ToastrModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CommonBootstrapModule,
    CommonMaterialModule,
    UserModule,
    StudentModule,
    EAuthModule,
    PortalModule,
    FormsModule,
    TranslateModule,
    CommonModule
  ],
  providers: [
    LoadingIndicatorService,
    FeedbackResource,
    ChangeLanguageService,
    Configuration,
    {
      provide: APP_INITIALIZER,
      useFactory: configurationFactory,
      deps: [Configuration],
      multi: true
    },
    InterceptorsModule,
    AuthGuard,
    { provide: LOCALE_ID, useValue: 'bg-BG' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
