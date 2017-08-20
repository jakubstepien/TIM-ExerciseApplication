export interface TokenError {
    error: string;
    error_description: string;
}

export interface Token {
    access_token: string;
    token_type: string;
    expires_in: number;
    userName: string;
    roles: string;
    ".issued": string;
    ".expires": string;
    userId: string;
}