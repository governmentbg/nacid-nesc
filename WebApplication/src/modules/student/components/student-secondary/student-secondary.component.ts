import { Component, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PersonSecondaryDto } from '../../dtos/person-lot.dtos/person-secondary.dtos/person-secondary.dto';

@Component({
  selector: 'app-student-secondary',
  templateUrl: './student-secondary.component.html',
  styleUrls: ['./student-secondary.component.css']
})
export class StudentSecondaryComponent {
  @Input() personSecondary: PersonSecondaryDto;

  constructor(public translate: TranslateService) { }
}