import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Fanmarvel } from '../models';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { PaginatedResult } from '../models/Pagination';

@Injectable({ providedIn: 'root' })
export class FanmarvelService {
  [x: string]: any;
  apiUrl = '';

    constructor(private http: HttpClient) { }

  getAll(): Observable<PaginatedResult<Fanmarvel[]>> {
    const paginatedResult: PaginatedResult<Fanmarvel[]> = new PaginatedResult<Fanmarvel[]>();


    return this.http.get<Fanmarvel[]>(`${this.apiUrl}/fanmarvels`, { observe: 'response' })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          return paginatedResult;
        })
      );
    }

  getById(id: number): Observable<Fanmarvel> {
    return this.http.get<Fanmarvel>(`${this.apiUrl}/fanmarvels/${id}`);
    }

    create(fanmarvel: any): any {
      return this.http.post<Fanmarvel>(`${this.apiUrl}/fanmarvels`, JSON.stringify(fanmarvel))
      .pipe(
        map((obj) => obj),
        catchError((e) => this.errorHandler(e))
     );
    }

  update(fanmarvels: any): any {
    return this.http.put<Fanmarvel>(`${this.apiUrl}/fanmarvels/${fanmarvels.id}`, JSON.stringify(fanmarvels))
      .pipe(
        map((obj) => obj),
        catchError((e) => this.errorHandler(e))
     );
    }

     delete(id: number): any {
       return this.http.delete<Fanmarvel>(`${this.apiUrl}/fanmarvels/${id}`);
  }
}
