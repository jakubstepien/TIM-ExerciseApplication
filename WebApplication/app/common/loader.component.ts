import { Component, OnInit } from '@angular/core';

import { HttpService } from './http.service';


@Component({
    selector: 'loader',
    template: `
    <div class="loader" [ngClass]="{active: active}"></div>    
`
})
export class LoaderComponent implements OnInit {
    active = false;

    constructor(private http: HttpService) { };

    ngOnInit(): void {
        this.http.loading.subscribe(next => { this.active = next });
    }

}