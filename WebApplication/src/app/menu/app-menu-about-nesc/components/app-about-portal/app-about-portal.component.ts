import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-about-portal',
  templateUrl: './app-about-portal.component.html',
  styleUrls: ['../app-about-styles.component.css']
})

export class AppAboutPortalComponent implements OnInit {
  constructor(public translate: TranslateService) { }

  ngOnInit() { }
}