import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: './app-about-uan-verification',
  templateUrl: './app-about-uan-verification.component.html',
  styleUrls: ['../app-about-styles.component.css']
})

export class AppAboutUanVerificationComponent implements OnInit {
  constructor(public translate: TranslateService) { }

  ngOnInit() { }
}