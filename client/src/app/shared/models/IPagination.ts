export interface IPagination<T>
{
    pageIndex: number;
    pageSize: number;
    totalCount: number;
    data: T;
}