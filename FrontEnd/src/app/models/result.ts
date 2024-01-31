export interface Result<T> {
    isSuccessful?: boolean,
    message?: string,
    data: T
}