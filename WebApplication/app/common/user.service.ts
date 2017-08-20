import { Injectable } from '@angular/core';

import { Token, TokenError } from '../account/Token';
import { CookieService } from 'ngx-cookie';

@Injectable()
export class UserService {
    private tokenKey = "ExerciseAppToken";

    constructor(private cookie: CookieService) { }

    public getUserId(): string {
        var tokenObj = this.getTokenObject();
        if (tokenObj) {
            return tokenObj.userId;
        }
    }

    public getToken(): string {
        var tokenObj = this.getTokenObject();
        if (tokenObj) {
            return tokenObj.access_token;
        }
    }

    public storeToken(token: Token) {
        this.cookie.putObject(this.tokenKey, token);
    }

    private getTokenObject(): Token {
        return this.cookie.getObject(this.tokenKey) as Token;
    }
}