import { Component, Input } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { PersonStudentDto } from "src/modules/student/dtos/person-lot.dtos/person-student.dtos/person-student.dto";
import { ChangeTabService } from "src/modules/student/services/change-tab.service";

@Component({
  selector: 'app-university',
  templateUrl: './university.component.html',
  styleUrls: ['./university.component.css']
})
export class UniversityComponent {
  @Input() personStudent: PersonStudentDto;

  constructor(
    private chageTabService: ChangeTabService,
    public translate: TranslateService
  ) { }

  changeTab(index: number) {
    this.chageTabService.setTabIndex(index);
  }
}
