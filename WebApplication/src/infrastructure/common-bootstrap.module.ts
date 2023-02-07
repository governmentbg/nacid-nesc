import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';
import { HelpTooltipComponent } from './components/help-tooltip/help-tooltip.component';
import { SvgIconComponent } from './components/svg-icon/svg-icon.component';
import { ActionConfirmationModalComponent } from './components/action-confirmation-modal/action-confirmation-modal.component';
import { FileUploadComponent } from './components/file-upload/file-upload.component';
import { ImageSelectComponent } from './components/img-selector/image-select.component';
import { FilterPipe } from './pipes/filter.pipe';

@NgModule({
  imports: [
    NgbModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule
  ],
  declarations: [
    SvgIconComponent,
    HelpTooltipComponent,
    ActionConfirmationModalComponent,
    FileUploadComponent,
    ImageSelectComponent,
    FilterPipe
  ],
  exports: [
    HelpTooltipComponent,
    FileUploadComponent,
    ImageSelectComponent,
    SvgIconComponent,
    FilterPipe
  ],
  providers: [
  ]
})
export class CommonBootstrapModule { }
