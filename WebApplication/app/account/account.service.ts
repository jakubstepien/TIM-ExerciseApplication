import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Token, TokenError } from './Token';
import { Result } from '../common/Result';
import { HttpService } from '../common/http.service';
import { UserService } from '../common/user.service';

import { ModelError } from '../common/ModelError';


@Injectable()
export class AccountService {

    constructor(private http: HttpService, private userService: UserService) { };

    login(login: string, password: string): Promise<Result> {
        let body = 'grant_type=password&username=' + login + '&password=' + password;
        let headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this.http.post('/token', body, false, { headers: headers, body: body })
            .toPromise()
            .then(response => {
                this.userService.storeToken(response.json());
                return { success: true } as Result;
            })
            .catch(reason => {
                var error = this.getError(reason.json() as ModelError, 'Nieprawidłowe dane logowania.')
                return { success: false, error: error } as Result;
            });
    }

    register(login: string, password: string, passwordConfirm: string): Promise<Result> {
        return this.http.post('/api/account/register', { Email: login, Password: password, ConfirmPassword: passwordConfirm })
            .toPromise()
            .then(response => {
                return this.login(login, password);
            })
            .catch(reason => {
                var errorJson = reason.json() as ModelError;
                var error = this.getError(errorJson);
                return { success: false, error: error } as Result;
            });
    }

    private getError(modelError: ModelError, errorMessage: string = ''): string {
        if (modelError && modelError.ModelState) {
            let modelState = modelError.ModelState;
            let modelErrors = Object.keys(modelState).map(m => modelState[m]).reduce((a: Array<string>, b: Array<string>) => a.concat(b));
            return modelErrors.reduce((a: string, b: string) => a + "\r\n" + b);
        }
        return errorMessage;
    }

} 