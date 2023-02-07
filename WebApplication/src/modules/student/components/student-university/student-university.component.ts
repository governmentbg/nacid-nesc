import { Component, Input } from '@angular/core';
import { PersonStudentDto } from '../../dtos/person-lot.dtos/person-student.dtos/person-student.dto';

@Component({
  selector: 'app-student-university',
  templateUrl: './student-university.component.html'
})
export class StudentUniversityComponent {
  @Input() personStudents: PersonStudentDto[];
  constructor(
  ) {
  }
}