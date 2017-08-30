import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'truncate'
})
export class TruncatePipe implements PipeTransform {

    transform(value: string, args: number): string {
        if (args) {
            let limit = args;
            return value.length > limit ? value.substring(0, limit) + "..." : value;
        }
        throw new Error("Invalid parameters");
    }
}