import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/finally';
import { UserService } from '../common/user.service';


import {
    Http,
    RequestOptions,
    RequestOptionsArgs,
    Response,
    Request,
    Headers,
    XHRBackend,
    ConnectionBackend
} from '@angular/http';

export class HttpService extends Http {
    private runningRequest = new Subject<boolean>();

    get loading(): Observable<boolean> {
        return this.runningRequest;
    }

    constructor(private backend: XHRBackend, options: RequestOptions, private userService: UserService) {
        super(backend, options);
    }

    get(url: string, authorized?: boolean, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        options = this.getAuthorizedOptions(authorized, options);
        return super.get(url, options).finally(() => this.onEnd());
    }

    post(url: string, body: any, authorized?: boolean, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        options = this.getAuthorizedOptions(authorized, options);
        return super.post(url, body, options).finally(() => this.onEnd());
    }

    put(url: string, body: any, authorized?: boolean, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        options = this.getAuthorizedOptions(authorized, options);
        return super.put(url, body, options).finally(() => this.onEnd());
    }

    delete(url: string, authorized?: boolean, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        options = this.getAuthorizedOptions(authorized, options);
        return super.delete(url, options).finally(() => this.onEnd());
    }

    private getAuthorizedOptions(authorized?: boolean, options?: RequestOptionsArgs): RequestOptionsArgs {
        if (authorized) {
            if (options) {
                if (!options.headers) {
                    options.headers = new Headers();
                }
            }
            else {
                options = { headers: new Headers() }
            }
            var token = this.userService.getToken();
            if (token) {
                options.headers.append("Authorization", "bearer " + token);
            }
        }
        return options;
    }

    onStart(): void {
        this.runningRequest.next(true)
    }

    onEnd(): void {
        this.runningRequest.next(false);
    }
}