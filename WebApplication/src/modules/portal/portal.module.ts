import { DatePipe } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { TranslateModule } from "@ngx-translate/core";
import { RecaptchaV3Module, RECAPTCHA_V3_SITE_KEY } from "ng-recaptcha";
import { CommonBootstrapModule } from "src/infrastructure/common-bootstrap.module";
import { HomeComponent } from "./components/home/home.component";
import { StudentPortalSearchComponent } from "./components/student-portal-search/student-portal-search.component";
import { PortalRoutingModule } from "./portal-routing.module";
import { HomeResource } from "./services/home.resource";
import { StudentPortalSearchResolver } from "./services/student-portal-search.resolver";

@NgModule({
  declarations: [
    HomeComponent,
    StudentPortalSearchComponent
  ],
  imports: [
    BrowserModule,
    RecaptchaV3Module,
    TranslateModule,
    FormsModule,
    CommonBootstrapModule,
    PortalRoutingModule,
  ],
  providers: [
    StudentPortalSearchResolver,
    HomeResource,
    DatePipe,
    { provide: RECAPTCHA_V3_SITE_KEY, useValue: "6LecCv4hAAAAAH3u8q696tscV6tFuTen1Sl4dCk5" }
  ]
})
export class PortalModule { }
