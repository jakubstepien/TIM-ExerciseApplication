import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/finally';

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

    constructor(backend: XHRBackend, options: RequestOptions) {
        super(backend, options);
    }

    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        return super.get(url, options).finally(() => this.onEnd());
    }

    post(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        return super.post(url, body, options).finally(() => this.onEnd());
    }

    put(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        return super.put(url, body, options).finally(() => this.onEnd());
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        this.onStart();
        return super.delete(url, options).finally(() => this.onEnd());
    }

    onStart(): void {
        this.runningRequest.next(true)
    }

    onEnd(): void {
        this.runningRequest.next(false);
    }
}