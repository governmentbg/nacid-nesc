import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { SamlRequest } from './saml-request.model';

@Component({
  selector: 'eauth-send-request',
  templateUrl: 'eAuth-send-request.component.html'
})
export class EAuthSendRequestComponent implements OnInit {

  model: SamlRequest;
  @Input() samlRequest: SamlRequest;

  constructor(public translate: TranslateService,
    private sanitizer: DomSanitizer) {
  }

  ngOnInit() {
    this.model = this.samlRequest;
  }

  trustUrl(url: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}
