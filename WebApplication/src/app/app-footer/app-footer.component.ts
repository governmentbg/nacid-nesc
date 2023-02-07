import { NoopScrollStrategy } from "@angular/cdk/overlay";
import { Component, Input, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { TranslateService } from "@ngx-translate/core";
import { FeedbackModalComponent } from "../feedback-modal/feedback-mdoal.component";

@Component({
  selector: 'app-footer',
  templateUrl: './app-footer.component.html',
  styleUrls: ['./app-footer.component.css'],
})
export class AppFooterComponent {
  @Input() isLoggedIn: boolean;
  @Input() currentYear: number;

  constructor(
    public dialog: MatDialog,
    public translate: TranslateService) {
  }

  openFeedbackDialog() {
    this.dialog.open(FeedbackModalComponent, { scrollStrategy: new NoopScrollStrategy() });
  }
}
