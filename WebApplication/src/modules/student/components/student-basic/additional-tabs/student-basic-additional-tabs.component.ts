import { Component, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PersonBasicDto } from 'src/modules/student/dtos/person-lot.dtos/person-basic.dtos/person-basic.dto';

@Component({
  selector: 'app-student-basic-additional-tabs',
  templateUrl: './student-basic-additional-tabs.component.html',
  styleUrls: ['./student-basic-additional-tabs.component.css']
})
export class StudentBasicAdditionalTabsComponent {
  @Input() personBasic: PersonBasicDto;
  missing: string = "MISSING";

  constructor(public translate: TranslateService) {
  }

}