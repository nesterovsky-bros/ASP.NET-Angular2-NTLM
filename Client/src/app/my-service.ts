import { Injectable } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs';
import "rxjs/add/operator/map";

import { environment } from "../environments/environment";

@Injectable()
export class MyService
{
  constructor(private http: Http)
  {
  }

  public add(x: number, y: number): Observable<number>
  {
    let url = environment.apiEndpoint + "my";
    let params = new URLSearchParams();

    params.set('x', x.toString());
    params.set('y', y.toString());

    return this.http.get(url, { search: params }).
      map(response => response.json());
  }
}
