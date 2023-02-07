import { Component, Input } from '@angular/core';
import { PersonDoctoralDto } from '../../dtos/person-lot.dtos/person-doctoral.dtos/person-doctoral.dto';

@Component({
  selector: 'app-student-doctoral',
  templateUrl: './student-doctoral.component.html'
})
export class StudentDoctoralComponent {
  @Input() personDoctorals: PersonDoctoralDto[];

  constructor(
  ) {
  }
}