﻿import { Injectable } from '@angular/core';

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

    public storeToken(token: Token, remember: boolean) {
        if (remember)
            this.cookie.putObject(this.tokenKey, token, { expires: token['.expires'] });
        else
            this.cookie.putObject(this.tokenKey, token);
    }

    public isLoggedIn(): boolean {
        return this.getTokenObject() != null;
    }

    public isInRole(role: string): boolean {
        var tokenObj = this.getTokenObject();
        if (!tokenObj) {
            return false;
        }
        return tokenObj.roles.split(';').some((userRole) => userRole === role);
    }

    public logout() {
        this.cookie.remove(this.tokenKey);
    }

    private getTokenObject(): Token {
        return this.cookie.getObject(this.tokenKey) as Token;
    }
}