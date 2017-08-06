export class Result {
    success: boolean;
    error: string;
}

export class DataResult<T> extends Result {
    data:T
}