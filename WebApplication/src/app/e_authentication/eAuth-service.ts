import { Injectable } from '@angular/core';
import { EAuthSendRequestComponent } from './eAuth-send-request.component';
import { SamlRequestService } from './saml-request.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { LoadingIndicatorService } from '../loading-indicator/loading-indicator.service';

@Injectable({
  providedIn: 'root'
})
export class EAuthService {

  constructor(
    private modalService: NgbModal,
    private samlRequestService: SamlRequestService,
    private loadingIndicator: LoadingIndicatorService,
    private config: Configuration) {
  }

  authenticate(serviceType: string, serviceUrl: string, serviceAction: string) {
    this.loadingIndicator.show();
    sessionStorage.setItem('serviceUrl', serviceUrl);
    sessionStorage.setItem('serviceAction', serviceAction);
    this.samlRequestService.getSamlRequest(serviceType, this.config.projectAlias)
      .subscribe(data => {
        const modalInstance = this.modalService.open(EAuthSendRequestComponent);
        modalInstance.componentInstance.samlRequest = data;
        this.loadingIndicator.hide();
      });
  }
}