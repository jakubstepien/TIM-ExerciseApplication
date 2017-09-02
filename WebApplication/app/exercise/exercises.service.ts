import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { HttpService } from '../common/http.service'
import { ExerciseDTO } from './exercise';
import { UserService } from '../common/user.service';
import { DataResult, Result } from '../common/Result';
import { PagedList } from '../common/pagedList';

@Injectable()
export class ExercisesService {
    constructor(private http: HttpService, private userService: UserService) { }
    dataChanged: Subject<boolean> = new Subject<boolean>();
    private readonly emptyId = "00000000-0000-0000-0000-000000000000";

    getExercises(page: number, pageSize: number): Promise<DataResult<PagedList<ExerciseDTO>>> {
        var userId = this.userService.getUserId();
        if (userId) {
            var promise = this.http.get('/api/exercises/user/' + userId, true, { params: { page: page.toString(), pageSize: pageSize.toString() } }).toPromise();
            return promise.then(response => {
                return { data: response.json(), success: true } as DataResult<PagedList<ExerciseDTO>>
            })
                .catch(reason => {
                    return { success: false } as DataResult<PagedList<ExerciseDTO>>
                });
        }
        return Promise.resolve({ success: false } as DataResult<PagedList<ExerciseDTO>>);
    }

    addExercise(exercise: ExerciseDTO): Promise<Result> {
        var userId = this.userService.getUserId();
        if (!exercise.IdExercise) {
            exercise.IdExercise = this.emptyId;
        }
        if (userId) {
            return this.http.post('api/exercises/user/' + userId, exercise, true).toPromise()
                .then(response => {
                    this.dataChanged.next(true);
                    return { success: true } as Result;
                })
                .catch(reason => {
                    return { success: false } as Result;
            })
        }
        return Promise.resolve({ success: false } as Result)
    }

    getExercise(id: string): Promise<DataResult<ExerciseDTO>> {
        if (id) {
            return this.http.get('api/exercises/' + id, true).toPromise()
                .then(response => {
                    return { success: true, data: response.json() } as DataResult<ExerciseDTO>
                })
                .catch(reason => {
                    return { success: false } as DataResult<ExerciseDTO>;
                })
        }
        return Promise.resolve({ success: false } as DataResult<ExerciseDTO>)
    }

    deleteExercise(id: string): Promise<Result> {
        var userId = this.userService.getUserId();
        if (userId && id) {
            var promise = this.http.delete("api/exercises/" + id + "/user/" + userId, true).toPromise();
            return promise.then(response => {
                    this.dataChanged.next(true);
                    return { success: true } as Result;
            }).catch(reason => {
                return { success: false } as Result;
            })
        }
        return Promise.resolve({ success: false } as Result)
    }

    saveImage(image: File, exerciseId?: string, fileName?: string): Promise<DataResult<string>> {
        let formData: FormData = new FormData();
        formData.append('image', image, image.name);
        if (exerciseId) {
            formData.append('excerciseId', exerciseId);

        }
        if (!fileName) {
            fileName = image.name;
        }
        formData.append('fileName', fileName);
        return this.http.post('/api/exercises/image', formData, true).toPromise()
            .then(response => {
                var json = response.json();
                return { success: json.Id != null, data: json.Id } as DataResult<string>;
            })
            .catch(reason => {
                return { success: false } as DataResult<string>;
            });
    }
}