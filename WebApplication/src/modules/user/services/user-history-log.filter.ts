import { BaseSearchFilter } from "src/infrastructure/services/base-search.filter";

export class UserHistoryLogFilter extends BaseSearchFilter {
  constructor(offset: number, limit: number) {
    super(offset, limit);
  }
}