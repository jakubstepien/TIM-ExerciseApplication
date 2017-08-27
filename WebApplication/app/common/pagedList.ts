export interface PagedList<T> {
    Items: T[];
    TotalCount: number;
    CurrentPage: number;
    PageSize: number;
}