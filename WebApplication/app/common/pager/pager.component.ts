import { Component } from '@angular/core';

@Component({
    selector: 'pager',
    inputs: ['currentPage', 'pageSize', 'lastPage', 'total', 'baseUrl'],
    templateUrl:'./pager.component.html',
})
export class PagerComponent {
 
}