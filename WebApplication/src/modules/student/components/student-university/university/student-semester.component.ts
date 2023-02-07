import { Component, Input } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { CourseTypeEnumLocalizationEn, SemesterEnumLocalizationEn } from "src/infrastructure/constants/enum-localization-en.const";
import { CourseTypeEnumLocalization, SemesterEnumLocalization } from "src/infrastructure/constants/enum-localization.const";
import { StudentSemesterDto } from "src/modules/student/dtos/person-lot.dtos/person-student.dtos/student-semester.dto";

@Component({
  selector: 'app-student-semester',
  templateUrl: './student-semester.component.html'
})
export class StudentSemesterComponent {
  @Input() semesters: StudentSemesterDto[] = [];

  semesterColumns: string[] = ['status', 'event', 'period', 'courseSemester', 'feeType'];

  courseTypeLocalization = CourseTypeEnumLocalization;
  courseTypeLocalizationEn = CourseTypeEnumLocalizationEn;
  semesterLocalization = SemesterEnumLocalization;
  semesterLocalizationEn = SemesterEnumLocalizationEn;

  constructor(public translate: TranslateService) { }
}
