import { Component, Input } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { PersonDoctoralDto } from "src/modules/student/dtos/person-lot.dtos/person-doctoral.dtos/person-doctoral.dto";


@Component({
  selector: 'app-doctoral',
  templateUrl: './doctoral.component.html',
  styleUrls: ['./doctoral.component.css']
})
export class DoctoralComponent {
  @Input() personDoctoral: PersonDoctoralDto;

  constructor(public translate: TranslateService) { }
}
