import { NgModule } from '@angular/core';

import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTabsModule } from '@angular/material/tabs';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { CUSTOM_DATE_FORMATS } from './constants/custom-date.constants';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  imports: [
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    MatDatepickerModule,
    MatTabsModule,
    MatExpansionModule,
    MatTableModule,
    MatMomentDateModule,
    MatMenuModule,
    MatTooltipModule,
    MatSelectModule
  ],
  exports: [
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    MatDatepickerModule,
    MatTabsModule,
    MatExpansionModule,
    MatTableModule,
    MatMomentDateModule,
    MatMenuModule,
    MatTooltipModule,
    MatSelectModule
  ],
  providers: [
    {
      provide: MAT_DATE_LOCALE, useValue: 'bg'
    },
    {
      provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { strict: true }
    },
    {
      provide: MAT_DATE_FORMATS, useValue: CUSTOM_DATE_FORMATS
    },
    {
      provide: MAT_DATE_FORMATS, useValue: CUSTOM_DATE_FORMATS
    },
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'outline', floatLabel: 'always' }
    },
    {
      provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]
    }
  ]
})
export class CommonMaterialModule { }