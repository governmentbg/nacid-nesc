import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { GenderTypeEnumLocalizationEn } from 'src/infrastructure/constants/enum-localization-en.const';
import { GenderTypeEnumLocalization } from 'src/infrastructure/constants/enum-localization.const';
import { UserChangeEmailAddressModalComponent } from 'src/modules/user/components/user-change-email-address-modal/user-change-email-address.component';
import { PersonBasicDto } from '../../dtos/person-lot.dtos/person-basic.dtos/person-basic.dto';

@Component({
  selector: 'app-student-basic',
  templateUrl: './student-basic.component.html',
  styleUrls: ['./student-basic.component.css']
})
export class StudentBasicComponent {
  @Input() personBasic: PersonBasicDto;
  @Input() uan: string;
  genderLocalization = GenderTypeEnumLocalization;
  genderLocalizationEn = GenderTypeEnumLocalizationEn;

  constructor(public translate: TranslateService,
    public dialog: MatDialog) {
  }

  openChangeEmailAddressDialog() {
    this.dialog.open(UserChangeEmailAddressModalComponent, { scrollStrategy: new NoopScrollStrategy() });

  }
}