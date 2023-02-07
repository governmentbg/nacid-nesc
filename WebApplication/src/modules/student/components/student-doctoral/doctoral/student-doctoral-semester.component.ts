import { Component, Input } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { YearTypeEnumLocalizationEn } from "src/infrastructure/constants/enum-localization-en.const";
import { YearTypeEnumLocalization } from "src/infrastructure/constants/enum-localization.const";
import { DoctoralSemesterDto } from "src/modules/student/dtos/person-lot.dtos/person-doctoral.dtos/doctoral-semester.dto";

@Component({
  selector: 'app-student-doctoral-semester',
  templateUrl: './student-doctoral-semester.component.html'
})
export class StudentDoctoralSemesterComponent {
  @Input() semesters: DoctoralSemesterDto[];

  yearTypeLocalization = YearTypeEnumLocalization;
  yearTypeLocalizationEn = YearTypeEnumLocalizationEn;

  displayedColumns: string[] = ['status', 'event', 'educationYear', 'protocolNumber'];

  constructor(public translate: TranslateService) { }
}
