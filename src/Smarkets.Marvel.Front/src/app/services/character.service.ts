import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Character } from '../models/character';
import { CharacterSearch } from '../models/character-search';

@Injectable()
export class CharacteService {

  public url: string = `${environment.API}/api`;

  constructor(
    private http: HttpClient
  ) { }

  search(term: string): Observable<Character[]> {
    return this.http.get<Character[]>(`${this.url}/Character?term=${term}`);
  }
}