import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { UserHistoryLogResultDto } from '../../models/user-history-log-result.dto';
import { UserLogHistoryResource } from '../../resources/user-history-log.resource';
import { UserHistoryLogFilter } from '../../services/user-history-log.filter';

@Component({
  selector: 'app-user-history-log',
  templateUrl: './user-history-log-modal.component.html',
  styleUrls: ['./user-history-log-modal.component.css']
})

export class UserHistoryLogModalComponent implements OnInit {
  private readonly LIMIT: number = 10;
  private OFFSET: number = 0;

  userHistoryLogResult: UserHistoryLogResultDto;
  userHistoryLogFilter: UserHistoryLogFilter;
  hasNext: boolean;
  canOpen: boolean;

  constructor(private logHistoryResource: UserLogHistoryResource,
    public dialogRef: MatDialogRef<UserHistoryLogModalComponent>,
    public translate: TranslateService) { }

  ngOnInit() {
    this.userHistoryLogFilter = new UserHistoryLogFilter(this.OFFSET, this.LIMIT);
    this.userHistoryLogResult = new UserHistoryLogResultDto();
    this.loadMore();
  }

  close() {
    this.dialogRef.close();
    this.canOpen = false;
  }

  loadMore() {
    this.OFFSET++;
    this.userHistoryLogFilter.offset = (this.OFFSET - 1) * this.LIMIT;
    this.logHistoryResource.getLogHistory(this.userHistoryLogFilter)
      .subscribe((logResult: UserHistoryLogResultDto) => {
        this.userHistoryLogResult.historyLogs = this.userHistoryLogResult.historyLogs.concat(logResult.historyLogs);
        this.userHistoryLogResult.count = logResult.count;
        this.hasNext = logResult.count > this.OFFSET * this.LIMIT;
        this.canOpen = true;
      });
  }
}