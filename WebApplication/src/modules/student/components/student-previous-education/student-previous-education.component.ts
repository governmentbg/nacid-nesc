import { Component, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PreviousEducationTypeEnumLocalizationEn, PreviousHighSchoolEducationTypeEnumLocalizationEn } from 'src/infrastructure/constants/enum-localization-en.const';
import { PreviousEducationTypeEnumLocalization, PreviousHighSchoolEducationTypeEnumLocalization } from 'src/infrastructure/constants/enum-localization.const';
import { BaseStudentDoctoralDto } from '../../dtos/person-lot.dtos/base.dtos/base-student-doctoral.dto';

@Component({
  selector: 'app-student-previous-education',
  templateUrl: './student-previous-education.component.html',
  styleUrls: ['./student-previous-education.component.css']
})
export class StudentPreviousEducationComponent {
  @Input() person: BaseStudentDoctoralDto = new BaseStudentDoctoralDto();
  peTypeLocalization = PreviousEducationTypeEnumLocalization;
  peTypeLocalizationEn = PreviousEducationTypeEnumLocalizationEn;
  highSchoolLocalization = PreviousHighSchoolEducationTypeEnumLocalization;
  highSchoolLocalizationEn = PreviousHighSchoolEducationTypeEnumLocalizationEn;

  constructor(public translate: TranslateService) {
  }
}
