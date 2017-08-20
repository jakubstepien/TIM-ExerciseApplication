import { Injectable } from '@angular/core';

import { HttpService } from '../common/http.service'
import { ExerciseDTO } from './exercise';
import { UserService } from '../common/user.service';

@Injectable()
export class ExercisesService {
    constructor(private http: HttpService, private userService: UserService) { }

    getExercises() {
        var userId = this.userService.getUserId();
        if (userId) {
            var promise = this.http.get('/api/exercises/user/' + userId, true).toPromise();
            promise.then(response => console.log(response));
        }
    }
}