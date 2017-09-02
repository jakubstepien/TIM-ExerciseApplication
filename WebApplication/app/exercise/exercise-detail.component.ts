import { Component, OnInit } from "@angular/core";
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { ExercisesService } from './exercises.service';
import { ExerciseDTO } from './exercise';
import { NotificationService } from '../common/notification/notification.service';


@Component({
    templateUrl: './exercise-detail.component.html',
})
export class ExercseDetailComponent implements OnInit {
    constructor(private exercisesService: ExercisesService, private notificationservice: NotificationService, private activeRoute: ActivatedRoute, private location: Location, private router: Router) { }
    exercise: ExerciseDTO;
    title: string;
    show: boolean;
    imageUploading: boolean = false;
    isUpdate: boolean;

    ngOnInit() {
        this.activeRoute.paramMap.subscribe(parms => {
            var id = parms.get('id');
            if (id) {
                this.isUpdate = true;
                this.loadExercise(id);
            }
            else {
                this.isUpdate = false;
                this.title = "Dodaj cwiczenie";
                this.exercise = { CaloriesPerHour: null, Description: "", IdExercise: "", ImageName: "", Name: "", IsFavourite: false };
                this.show = true;
            }
        });
    }

    loadExercise(id: string) {
        this.exercisesService.getExercise(id).then(data => {
            if (data.success) {
                this.exercise = data.data;
                this.show = true;
                this.title = "Edytuj cwiczenie";
            } else {
                this.notificationservice.error('Błąd pobierania ćwiczenia.');
            }
        })
            .catch(reason => {
                this.notificationservice.error('Błąd pobierania ćwiczenia.');
            });
    }

    uploadImage(event: any) {
        this.imageUploading = true;
        var file: File = event.target.files[0];
        var result = this.exercisesService.saveImage(file)
            .then(response => {
                if (response.success && !this.isUpdate) {
                    this.exercise.IdExercise = response.data;
                    this.exercise.ImageName = file.name;
                }
                else {
                    this.notificationservice.error('Błąd zapisu obrazu');
                }
                this.imageUploading = false;
            })
            .catch(reaspon => {
                this.imageUploading = false;
                this.notificationservice.error('Błąd zapisu obrazu')
            });
    }

    saveExercise(form: NgForm) {
        if (this.isUpdate) {
        }
        else {
            this.addExercise();
        }
    }

    private addExercise() {
        this.exercisesService.addExercise(this.exercise)
            .then(result => {
                if (result.success) {
                    this.router.navigate(['../'], { relativeTo: this.activeRoute });
                }
                else {
                    throw new Error();
                }
            })
            .catch(reason => {
                this.notificationservice.error("Błąd zapisu ćwiczenia")
            });
    }
}