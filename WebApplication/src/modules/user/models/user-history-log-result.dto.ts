import { UserHistoryLogDto } from "./user-history-log.dto";

export class UserHistoryLogResultDto {

  constructor() {
    this.count = 0;
    this.historyLogs = [];
  }

  historyLogs: UserHistoryLogDto[];
  count: number;
}