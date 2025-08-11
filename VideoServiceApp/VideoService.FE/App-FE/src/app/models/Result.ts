export interface Result<T> {
  value: T;
  isSuccess: boolean;
  error?: string;
}
