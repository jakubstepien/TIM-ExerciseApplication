import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Token, TokenError } from './Token';
import { Result } from '../common/Result';

@Injectable()
export class AccountService{
    constructor(private http: Http) { };

    login(login: string, password: string): Promise<Result> {
        let body = 'grant_type=password&username=' + login + '&password=' + password;
        let headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this.http.post('/token', body, { headers: headers, body: body })
            .toPromise()
            .then(response => {
                return { success: true } as Result;
            })
            .catch(reason => {
                return { success: false, error: "Nieprawidłowe dane logowania." } as Result;
            });
    }
} 