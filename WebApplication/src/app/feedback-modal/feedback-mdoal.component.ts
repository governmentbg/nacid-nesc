import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
import { finalize } from "rxjs";
import { RegExps } from "src/infrastructure/constants/constants";
import { LoadingIndicatorService } from "../loading-indicator/loading-indicator.service";
import { FeedbackDto } from "./dtos/feedback.dto";
import { FeedbackResource } from "./resources/feedback.resource";

@Component({
  selector: 'feedback',
  templateUrl: './feedback-modal.component.html',
  styleUrls: ['./feedback-modal.component.css']
})
export class FeedbackModalComponent {
  model: FeedbackDto = new FeedbackDto();

  emailRegex = RegExps.EMAIL_REGEX;

  constructor(
    public dialogRef: MatDialogRef<FeedbackModalComponent>,
    private resource: FeedbackResource,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private loadingIndicator: LoadingIndicatorService) {
  }


  sendEmail(): void {
    this.loadingIndicator.show();
    this.resource.sendFeedback(this.model)
      .pipe(
        finalize(() => {
          this.loadingIndicator.hide();
          this.close();
        })
      )
      .subscribe({
        complete: () => {
          this.toastrService.success(this.translateService.instant('toastrSuccess.FeedbackSent'));
        }
      });
  }

  close(): void {
    this.dialogRef.close();
  }
}
