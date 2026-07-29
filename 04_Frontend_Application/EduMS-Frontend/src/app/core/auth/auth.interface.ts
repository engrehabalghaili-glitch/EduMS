export interface LoginRequest {
  username?: string;
  password?: string;
}

export interface LoginResponse {
  succeeded: boolean;
  message: string;
  data: string; // يمثل التوكن (Token)
  errors?: string[];
}
