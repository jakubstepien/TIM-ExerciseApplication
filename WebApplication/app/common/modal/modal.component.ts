import { Component, Input, OnDestroy } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'modal',
    templateUrl: './modal.component.html'
})
export class ModalComponent implements OnDestroy {
    @Input() header: string;
    private _show: boolean;
    @Input() set show(value: boolean) {
        this.toggleModalOpenOnBody(value);
        this._show = value;
    }
    get show() {
        return this._show;
    }

    constructor(private location: Location) { }

    close() {
        this.toggleModalOpenOnBody(false);
        this.location.back();
    }

    ngOnDestroy() {
        this.toggleModalOpenOnBody(false);
    }

    private toggleModalOpenOnBody(show: boolean) {
        if (show)
            document.body.classList.add('modal-open');
        else
            document.body.classList.remove('modal-open');
    }
}