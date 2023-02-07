import { Component, Input, OnInit } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { PersonStudentDiplomaDto } from "src/modules/student/dtos/person-lot.dtos/person-student.dtos/person-student-diploma.dto";

@Component({
  selector: 'app-student-diploma',
  templateUrl: './student-diploma.component.html'
})
export class StudentDiplomaComponent implements OnInit {
  @Input() personStudentDiploma: PersonStudentDiplomaDto = new PersonStudentDiplomaDto();

  diplomaColumns: string[] = ['diplomaNumber', 'registrationDiplomaNumber', 'diplomaDate', 'diplomafile', 'isValid'];
  diplomaDataSource: PersonStudentDiplomaDto[] = [];

  constructor(public translate: TranslateService) { }

  ngOnInit(): void {
    this.diplomaDataSource.push(this.personStudentDiploma);
  }
}
