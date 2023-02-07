import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UserLoginInfoDto } from 'src/modules/user/models/user-login-info.dto';
import { UserLoginService } from 'src/modules/user/services/user-login.service';
import { EAuthResponseStatus } from './eAuth-response-status.enum';

@Component({
  selector: 'eauth-redirect-response',
  template: ''
})
export class EAuthRedirectResponseComponent implements OnInit {
  responseStatus: any;
  userName: string;
  loginDto: UserLoginInfoDto = new UserLoginInfoDto();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private loginService: UserLoginService) {
  }

  ngOnInit() {
    this.responseStatus = EAuthResponseStatus[this.route.snapshot.queryParams.responseStatus];
    this.userName = this.route.snapshot.queryParams.name;

    this.loginDto.token = this.route.snapshot.queryParams.token;
    this.loginDto.uan = this.route.snapshot.queryParams.uan;
    this.loginDto.username = this.route.snapshot.queryParams.username;
    this.loginDto.fullName = this.route.snapshot.queryParams.fullname;
    this.loginDto.fullNameAlt = this.route.snapshot.queryParams.fullnamealt;

    if (this.responseStatus === EAuthResponseStatus.Success) {
      this.loginService.login(this.loginDto);
      this.router.navigate(['student']);
    } else {
      this.setErrorMessage();
      this.router.navigate(['access']);
    }
  }

  setErrorMessage() {
    if (this.responseStatus === EAuthResponseStatus.AuthenticationFailed) {
      this.toastrService.error(this.translateService.instant('toastrError.EAuthResponseStatus.AuthenticationFailed'));
    }
    if (this.responseStatus === EAuthResponseStatus.CanceledByUser) {
      this.toastrService.error(this.translateService.instant('toastrError.EAuthResponseStatus.CanceledByUser'));
    }
    if (this.responseStatus === EAuthResponseStatus.InvalidResponseXML) {
      this.toastrService.error(this.translateService.instant('toastrError.EAuthResponseStatus.InvalidResponseXML'));
    }
    if (this.responseStatus === EAuthResponseStatus.InvalidSignature) {
      this.toastrService.error(this.translateService.instant('toastrError.EAuthResponseStatus.InvalidSignature'));
    }
    if (this.responseStatus === EAuthResponseStatus.MissingEGN) {
      this.toastrService.error(this.translateService.instant('toastrError.EAuthResponseStatus.MissingEGN'));
    }
    if (this.responseStatus === EAuthResponseStatus.NotDetectedQES) {
      this.toastrService.error(this.translateService.instant('toastrError.EAuthResponseStatus.NotDetectedQES'));
    }
    if (this.responseStatus === EAuthResponseStatus.NoEgnMatch) {
      this.toastrService.error(this.translateService.instant('toastrError.EAuthResponseStatus.NoEgnMatch'));
    }
  }
}
