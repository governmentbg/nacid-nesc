import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router } from "@angular/router";
import { TranslateService } from "@ngx-translate/core";
import { ReCaptchaV3Service } from "ng-recaptcha";
import { catchError, finalize, Observable, of, switchMap } from "rxjs";
import { LoadingIndicatorService } from "src/app/loading-indicator/loading-indicator.service";
import { ChangeLanguageService } from "src/app/menu/change-language/change-language.service";
import { StudentPortalSearchDto } from "../dtos/basic/student-portal-search.dto";
import { HomeResource } from "./home.resource";

@Injectable()
export class StudentPortalSearchResolver implements Resolve<StudentPortalSearchDto> {

  model: Observable<StudentPortalSearchDto>;

  constructor(
    private resource: HomeResource,
    private loadingIndicator: LoadingIndicatorService,
    private reCaptcha3: ReCaptchaV3Service,
    private router: Router,
    private translateService: TranslateService,
    private changeLanguageService: ChangeLanguageService
  ) { }

  resolve(route: ActivatedRouteSnapshot)
    : StudentPortalSearchDto | Observable<StudentPortalSearchDto> | Promise<StudentPortalSearchDto> {
    let lg = route.queryParams.lg;
    if (lg !== undefined) {
      localStorage.setItem('currentLanguage', lg);
      this.translateService.use(lg);
      this.changeLanguageService.setLanguage(lg);
    }

    let uan = route.queryParams.uan;

    this.loadingIndicator.show();

    return this.reCaptcha3.execute('importantAction').pipe(
      switchMap((token: string) => {
        return this.model = this.resource.getStudent(uan, token)
          .pipe(
            finalize(() => this.loadingIndicator.hide()),
            catchError(() => {
              this.router.navigate(['search']);
              return of();
            })
          );
      })
    );
  }
}
