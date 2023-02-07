export abstract class BaseSearchFilter {
  offset: number;
  limit: number;

  constructor(offset: number, limit: number) {
    this.offset = offset;
    this.limit = limit;
  }
}