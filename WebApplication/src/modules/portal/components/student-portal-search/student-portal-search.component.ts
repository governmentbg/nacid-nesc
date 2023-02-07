import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { TranslateService } from "@ngx-translate/core";
import { StudentPortalSearchDto } from "../../dtos/basic/student-portal-search.dto";

@Component({
  selector: 'student-portal-search',
  templateUrl: 'student-portal-search.component.html',
  styleUrls: ['student-portal-search.component.css']
})

export class StudentPortalSearchComponent {
  model: StudentPortalSearchDto;
  hasImg: boolean;
  uan: string;

  constructor(
    public translate: TranslateService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe((data: { model: StudentPortalSearchDto }) => this.model = data.model);

    if (this.model.imgFile !== null && this.model.imgFile !== undefined) {
      this.hasImg = true;
    }
  }
}