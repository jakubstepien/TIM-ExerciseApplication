import { Component } from "@angular/core";

import { ExercisesService } from './exercises.service';

@Component({
    templateUrl: './exercise-detail.component.html',
})
export class ExercseDetailComponent {
    constructor(private exercisesService: ExercisesService){}

    uploadImage(event: any) {
        var file: File = event.target.files[0];
        this.exercisesService.saveImage(file, "83CBF1FC-BDC6-457B-850E-E34D56122AF6");
    }
}