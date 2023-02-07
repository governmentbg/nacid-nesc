import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ChangeTabService } from 'src/modules/student/services/change-tab.service';

@Component({
  selector: 'app-about-nesc',
  templateUrl: './app-about-nesc.component.html',
  styleUrls: ['../app-about-styles.component.css']
})

export class AppAboutNescComponent implements OnInit {
  constructor(
    public translate: TranslateService,
    private changeTabService: ChangeTabService) { }

  ngOnInit() { }

  switchTabInAccess() {
    this.changeTabService.setTabIndex(1);
  }
}