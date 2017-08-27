export interface Result {
    success: boolean;
    error: string;
}

export interface DataResult<T> extends Result {
    data:T
}