import { Injectable } from '@angular/core';

import { HttpService } from '../common/http.service'
import { ExerciseDTO } from './exercise';
import { UserService } from '../common/user.service';
import { DataResult, Result } from '../common/Result';
import { PagedList } from '../common/pagedList';

@Injectable()
export class ExercisesService {
    constructor(private http: HttpService, private userService: UserService) { }

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

    deleteExercise(id: string): Promise<Result> {
        var userId = this.userService.getUserId();
        if (userId && id) {
            var promise = this.http.delete("api/exercises/" + id + "/user/" + userId, true).toPromise();
            return promise.then(response => {
                return { success: true } as Result;
            }).catch(reason => {
                return { success: false } as Result;
            })
        }
        return Promise.resolve({ success: false } as Result)
    }

    saveImage(image: File, exerciseId?: string, fileName?: string) {
        let formData: FormData = new FormData();
        formData.append('image', image, image.name);
        if (exerciseId) {
            formData.append('excerciseId', exerciseId);

        }
        if (!fileName) {
            fileName = image.name;
        }
        formData.append('fileName', fileName);
        return this.http.post('/api/exercises/image', formData, true).toPromise();
    }
}