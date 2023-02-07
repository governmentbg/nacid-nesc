import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { TranslateService } from "@ngx-translate/core";
import { Configuration } from "src/infrastructure/configuration/configuration";
import { IMenuItem } from "src/infrastructure/interfaces/IMenuItem";

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.css'],
})
export class AppHeaderComponent implements OnInit {
  @Input() menuItems: IMenuItem[] = [];
  @Input() isLoggedIn: boolean = false;
  menuOpened: boolean;
  menuOpenedSmall: boolean;
  currentLanguage = null;

  constructor(public translate: TranslateService,
    public configuration: Configuration,
    private router: Router) { }

  ngOnInit(): void {
    this.currentLanguage = localStorage.getItem('currentLanguage') ?? this.configuration.defaultLanguage;
    localStorage.setItem('currentLanguage', this.currentLanguage);
    this.translate.setDefaultLang(this.currentLanguage);
    this.translate.use(this.currentLanguage);
  }

  switchLang(newLang: string) {
    this.translate.use(newLang);
    this.currentLanguage = newLang;
    localStorage.setItem('currentLanguage', this.currentLanguage);
  }

  routeToHome() {
    if (this.isLoggedIn) {
      this.router.navigate(['student']);
    } else {
      this.router.navigate(['']);
    }
  }
}
