import { Component, OnInit } from '@angular/core';
import { LoadingIndicatorService } from 'src/app/loading-indicator/loading-indicator.service';
import { ElectronicCardDto } from '../../dtos/electronic-card/electronic-card-info.dto';
import { ElectronicCardResource } from '../../resources/electronic-card.resource';
import { finalize } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import * as FileSaver from 'file-saver';

@Component({
  selector: 'app-electronic-card',
  templateUrl: './electronic-card.component.html',
  styleUrls: ['./electronic-card.component.css']
})
export class ElectronicCardComponent implements OnInit {
  electronicCardInfo: ElectronicCardDto = new ElectronicCardDto();
  qrCodeImageBg: SafeResourceUrl;
  qrCodeImageEn: SafeResourceUrl;

  constructor(
    private electronicCardResource: ElectronicCardResource,
    private loadingIndicator: LoadingIndicatorService,
    public translate: TranslateService,
    private sanitizer: DomSanitizer
  ) {
  }

  ngOnInit(): void {
    this.loadingIndicator.show();
    this.electronicCardResource.getStudentElectronicCardInfo()
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe({
        next: (electronicCard: ElectronicCardDto) => {
          this.electronicCardInfo = electronicCard;
          this.qrCodeImageBg = this.sanitizer.bypassSecurityTrustResourceUrl(`data:image/png;base64, ${electronicCard.qrCodeImageBg}`);
          this.qrCodeImageEn = this.sanitizer.bypassSecurityTrustResourceUrl(`data:image/png;base64, ${electronicCard.qrCodeImageEn}`);
        }
      });
  }

  getStudentElectronicCardPdf() {
    this.loadingIndicator.show();
    let inBulgarian = this.translate.currentLang === 'bg';
    this.electronicCardResource.getStudentElectronicCardPdf(inBulgarian)
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe({
        next: (electronicCardPdf64: string) => {
          let byteArray = this.base64ToArrayBuffer(electronicCardPdf64);
          let blob: any = new Blob([byteArray], { type: 'application/octet-stream' });
          FileSaver.saveAs(blob, 'ElectronicCard.pdf', true);
        }
      });
  }

  private base64ToArrayBuffer(base64: string): ArrayBuffer {
    var binary_string = window.atob(base64);
    var len = binary_string.length;
    var bytes = new Uint8Array(len);
    for (var i = 0; i < len; i++) {
      bytes[i] = binary_string.charCodeAt(i);
    }
    return bytes.buffer;
  }
}
