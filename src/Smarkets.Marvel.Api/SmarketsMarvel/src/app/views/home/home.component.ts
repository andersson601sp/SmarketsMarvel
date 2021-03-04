import { HeaderService } from './../../components/template/header/header.service';
import { Component, OnInit } from '@angular/core';
import { first, map } from 'rxjs/operators';
import { Fanmarvel } from '../../models';
import { FanmarvelService } from '../../services';
import { HttpClient, HttpParams, HttpHeaders  } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loading = false;
  fanmarvel: Fanmarvel;
  fanmarvelFromApi: Fanmarvel;
  urlMarvelAPI = 'https://gateway.marvel.com:443/v1/public/characters';
  marvels: any[];
  httpOptions = {    headers: new HttpHeaders({
      'content-Type': 'application/json',
      'apikey': 'ea4ede2f789026bda7eee51848b31411'
    })
  };

  constructor(private http: HttpClient) {
    this.read();
 }

  ngOnInit(): void { }


  getAll() {
    return this.http.get(this.urlMarvelAPI, this.httpOptions)
      .pipe(map(response => response))
  }

  read(): void {
    this.getAll()
      .pipe()
      .subscribe((marvel) => {
      console.log(marvel);
      });
  }

}
