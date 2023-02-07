import { ChangeDetectionStrategy, Component, OnInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Configuration } from 'src/infrastructure/configuration/configuration';
import { IMenuItem } from 'src/infrastructure/interfaces/IMenuItem';
import { ChangeTabService } from 'src/modules/student/services/change-tab.service';

@Component({
  selector: 'app-menu',
  templateUrl: './app-menu.component.html',
  styleUrls: ['./app-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppMenuComponent implements OnInit {
  @Input() menuItems: IMenuItem[] = [];
  @Input() isLoggedIn: boolean = false;
  currentLanguage = null;
  menuOpened: boolean;


  constructor(public translate: TranslateService,
    public configuration: Configuration,
    private changeTabService: ChangeTabService) {
  }

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

  switchTab(index: number) {
    this.changeTabService.setTabIndex(index);
  }
}
